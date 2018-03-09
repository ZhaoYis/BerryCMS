using System.Collections.Generic;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.Service.AuthorizeManage;

namespace BerryCMS.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public partial class ModuleButtonBLL : BaseBLL<ModuleButtonEntity>,IModuleButtonBLL
    {
        private ModuleButtonService moduleButtonService = new ModuleButtonService();

        protected override void SetDal()
        {
            Idal = DbSession.ModuleButtonDal;
        }

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleButtonService.GetModuleButtonList();
            }
            else
            {
                return moduleButtonService.GetModuleButtonList(userId);
            }
        }
    }
}