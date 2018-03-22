using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Extension;
using BerryCMS.IService.AuthorizeManage;
using BerryCMS.Service.Base;
using Chloe;

namespace BerryCMS.Service.AuthorizeManage
{
    /// <summary>
    /// 授权数据
    /// </summary>
    public class AuthorizeService : BaseService, IAuthorizeService
    {
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(OperatorEntity operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return "";
            }

            string userId = operators.UserId;
            StringBuilder whereSb = new StringBuilder(" SELECT UserId FROM Base_User WHERE 1=1 ");
            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     IsRead = 0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId = @UserId)";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId = @UserId)";
            }
            DbParam[] parameter =
            {
                DbParam.Create("@UserId",userId)
            };

            whereSb.Append(string.Format("  AND( UserId ='{0}'", userId));

            IEnumerable<AuthorizeDataEntity> listAuthorizeData = o.BllSession.AuthorizeDataBll.FindList(strAuthorData, parameter);
            foreach (AuthorizeDataEntity item in listAuthorizeData)
            {
                switch (item.AuthorizeType)
                {
                    case 0://0代表最大权限
                        return "";
                    case 2://本人及下属
                        whereSb.Append("  OR ManagerId ='{0}'");
                        break;
                    case 3://所在部门
                        whereSb.Append(@"  OR DepartmentId = (  SELECT  DepartmentId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case 4://所在公司
                        whereSb.Append(@"  OR OrganizeId = (    SELECT  OrganizeId
                                                                    FROM    Base_User
                                                                    WHERE   UserId ='{0}'
                                                                  )");
                        break;
                    case 5:
                        whereSb.Append(string.Format(@"  OR DepartmentId='{1}' OR OrganizeId='{1}'", userId, item.ResourceId));
                        break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false)
        {
            string authorSql = this.GetDataAuthor(operators, isWrite);
            if (string.IsNullOrEmpty(authorSql)) return "";

            List<UserEntity> userList = o.BllSession.UserBll.FindList(authorSql).ToList();
            StringBuilder user = new StringBuilder("");

            foreach (UserEntity item in userList)
            {
                user.Append(item.UserId);
                user.Append(",");
            }

            return user.ToString();
        }

        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        public bool ActionAuthorize(string userId, string moduleId, string action)
        {
            List<AuthorizeUrlModel> authorizeUrlList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<AuthorizeUrlModel>>("__ActionAuthorize_" + userId);
            if (authorizeUrlList == null || authorizeUrlList.Count == 0)
            {
                authorizeUrlList = this.GetUrlList(userId).ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(authorizeUrlList, "__ActionAuthorize_" + userId, DateTime.Now.AddMinutes(5));
            }

            authorizeUrlList = authorizeUrlList.FindAll(a => a.ModuleId.Equals(moduleId));
            foreach (AuthorizeUrlModel item in authorizeUrlList)
            {
                if (!string.IsNullOrEmpty(item.UrlAddress))
                {
                    string[] url = item.UrlAddress.Split('?');
                    if (item.ModuleId == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ModuleId AS AuthorizeId ,
                                    ModuleId ,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                                    AND IsMenu = 1
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  ModuleButtonId AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND ActionAddress IS NOT NULL");

            string sql = strSql.ToString().Replace("@UserId", $"'{userId}'");

            DataTable data = o.BllSession.CommonBll.FindTable(sql);
            IEnumerable<AuthorizeUrlModel> res = data.DataTableToList<AuthorizeUrlModel>();

            return res;
        }
    }
}