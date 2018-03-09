using System.Collections.Generic;
using System.Text;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IService.AuthorizeManage;
using BerryCMS.Service.Base;
using Chloe;

namespace BerryCMS.Service.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public class ModuleButtonService : BaseService, IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @UserId ) )
                                            OR ObjectId = @UserId ) Order By SortCode");

            DbParam[] dbParam = new DbParam[]
            {
                DbParam.Create("@UserId",userId)
            };

            IEnumerable<ModuleButtonEntity> res = o.BllSession.ModuleButtonBll.FindList(strSql.ToString(), dbParam);

            return res;
        }

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_ModuleButton  Order By SortCode ASC");

            IEnumerable<ModuleButtonEntity> res = o.BllSession.ModuleButtonBll.FindList(strSql.ToString());

            return res;
        }
    }
}