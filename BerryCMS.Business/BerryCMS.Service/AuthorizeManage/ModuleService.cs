using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IService.AuthorizeManage;
using BerryCMS.Service.Base;
using Chloe;

namespace BerryCMS.Service.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class ModuleService : BaseService, IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
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
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");

            DbParam[] dbParam = new DbParam[]
               {
                    DbParam.Create("@UserId",userId)
               };

            IEnumerable<ModuleEntity> res = o.BllSession.ModuleBll.FindList(strSql.ToString(), dbParam).ToList();

            return res;
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_Module AND EnabledMark = 1 AND DeleteMark = 0 Order By SortCode");

            IEnumerable<ModuleEntity> res = o.BllSession.ModuleBll.FindList(strSql.ToString());

            return res;
        }
    }
}