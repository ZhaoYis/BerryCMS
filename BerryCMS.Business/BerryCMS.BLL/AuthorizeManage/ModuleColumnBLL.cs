using System.Collections.Generic;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.Service.AuthorizeManage;

namespace BerryCMS.BLL.AuthorizeManage
{
    /// <summary>
    /// 授权视图数据
    /// </summary>
    public partial class ModuleColumnBLL : BaseBLL<ModuleColumnEntity>, IModuleColumnBLL
    {
        private ModuleColumnService moduleColumnService = new ModuleColumnService();

        protected override void SetDal()
        {
            Idal = DbSession.ModuleColumnDal;
        }

        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleColumnService.GetModuleColumnList();
            }
            else
            {
                return moduleColumnService.GetModuleColumnList(userId);
            }
        }
    }
}