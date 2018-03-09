using System.Collections.Generic;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;

namespace BerryCMS.IBLL.AuthorizeManage
{
    /// <summary>
    /// 系统视图
    /// </summary>
    public partial interface IModuleColumnBLL : IBaseBLL<ModuleColumnEntity>
    {
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId);
    }
}