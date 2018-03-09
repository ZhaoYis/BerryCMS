using System.Collections.Generic;
using BerryCMS.Entity.AuthorizeManage;

namespace BerryCMS.IService.AuthorizeManage
{
    /// <summary>
    /// 授权功能视图
    /// </summary>
    public interface IModuleColumnService
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId);
        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList();
    }
}