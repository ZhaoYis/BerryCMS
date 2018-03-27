using System.Collections.Generic;
using System.Linq;
using BerryCMS.Entity;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Extension;
using BerryCMS.IService.BaseManage;
using BerryCMS.Service.Base;
using Newtonsoft.Json.Linq;

namespace BerryCMS.Service.BaseManage
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleService : BaseService, IRoleService
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRoleList()
        {
            var expression = LambdaExtension.True<RoleEntity>();
            expression = expression.And(t => t.Category == 1).And(t => t.EnabledMark == true).And(t => t.DeleteMark == false);

            IEnumerable<RoleEntity> res = o.BllSession.RoleBll.FindList(expression);
            res = res.OrderByDescending(r => r.CreateDate);

            return res;
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRolePageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            JObject queryParam = queryJson.ToJObject();
            if (queryParam != null)
            {
                string enCode = queryParam["EnCode"].ToString();
                string fullName = queryParam["FullName"].ToString();

                if (!string.IsNullOrEmpty(enCode))
                {
                    expression = expression.And(t => t.EnCode.Contains(enCode));
                }

                if (!string.IsNullOrEmpty(fullName))
                {
                    expression = expression.And(t => t.FullName.Contains(fullName));
                }
            }
            expression = expression.And(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true);

            IEnumerable<RoleEntity> res = o.BllSession.RoleBll.FindPageList(expression, pagination);

            return res;
        }

        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllRoleList()
        {
            IEnumerable<RoleEntity> res = o.BllSession.RoleBll.FindList(GetAllUserGroupSQL.ToString());

            return res;
        }

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetRoleEntity(string keyValue)
        {
            RoleEntity res = o.BllSession.RoleBll.FindEntity(keyValue);

            return res;
        }

        /// <summary>
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            expression = expression.And(t => t.EnCode == enCode).And(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.RoleId != keyValue);
            }
            bool hasExist = o.BllSession.RoleBll.IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 角色名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            expression = expression.And(t => t.FullName == fullName).And(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.RoleId != keyValue);
            }
            bool hasExist = o.BllSession.RoleBll.IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveRoleByKey(string keyValue)
        {
            int res = o.BllSession.RoleBll.Delete(keyValue);
        }

        /// <summary>
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        public void SaveRole(string keyValue, RoleEntity roleEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);

                int res = o.BllSession.RoleBll.Update(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.Category = 1;

                bool res = o.BllSession.RoleBll.Insert(roleEntity);
            }
        }

        #region SQL语句
        /// <summary>
        /// 用户组列表
        /// </summary>
        private const string GetAllUserGroupSQL = @"SELECT  r.RoleId ,
				                                            o.FullName AS OrganizeId ,
				                                            r.Category ,
				                                            r.EnCode ,
				                                            r.FullName ,
				                                            r.SortCode ,
				                                            r.EnabledMark ,
				                                            r.Description ,
				                                            r.CreateDate,
                                                            r.DeleteMark 
                                            FROM    Base_Role r
				                                            LEFT JOIN Base_Organize o ON o.OrganizeId = r.OrganizeId
                                            WHERE   and r.Category = 1 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";
        #endregion
    }
}