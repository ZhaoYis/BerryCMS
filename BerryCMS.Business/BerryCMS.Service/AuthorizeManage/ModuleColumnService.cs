using System.Collections.Generic;
using System.Text;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IService.AuthorizeManage;
using BerryCMS.Service.Base;
using Chloe;

namespace BerryCMS.Service.AuthorizeManage
{
    /// <summary>
    /// 授权功能视图
    /// </summary>
    public class ModuleColumnService : BaseService, IModuleColumnService
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleColumn
                            WHERE   ModuleColumnId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 3
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId )  Order By SortCode");

            DbParam[] dbParam = new DbParam[]
            {
                DbParam.Create("@UserId",userId)
            };

            IEnumerable<ModuleColumnEntity> res = o.BllSession.ModuleColumnBll.FindList(strSql.ToString(), dbParam);

            return res;
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_ModuleColumn Order By SortCode ASC");

            IEnumerable<ModuleColumnEntity> res = o.BllSession.ModuleColumnBll.FindList(strSql.ToString());

            return res;
        }
    }
}