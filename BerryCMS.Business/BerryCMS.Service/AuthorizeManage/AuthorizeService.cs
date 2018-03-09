using System.Collections.Generic;
using System.Data;
using System.Text;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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