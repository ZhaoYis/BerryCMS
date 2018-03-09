using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IBLL.AuthorizeManage;

namespace BerryCMS.BLL.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public partial class ModuleBLL : BaseBLL<ModuleEntity>, IModuleBLL
    {
        protected override void SetDal()
        {
            Idal = DbSession.ModuleDal;
        }
    }
}