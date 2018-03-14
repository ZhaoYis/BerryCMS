using System.Collections.Generic;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.IService.AuthorizeManage;
using BerryCMS.Service.AuthorizeManage;

namespace BerryCMS.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public partial class ModuleBLL : BaseBLL<ModuleEntity>, IModuleBLL
    {
        private readonly IModuleService _moduleService = new ModuleService();

        protected override void SetDal()
        {
            Idal = DbSession.ModuleDal;
        }

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return _moduleService.GetModuleList();
            }
            else
            {
                return _moduleService.GetModuleList(userId);
            }
        }
    }
}