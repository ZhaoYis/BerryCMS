using System.Collections.Generic;
using BerryCMS.Entity.AuthorizeManage;

namespace BerryCMS.IService.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public interface IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId);

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList();
    }
}