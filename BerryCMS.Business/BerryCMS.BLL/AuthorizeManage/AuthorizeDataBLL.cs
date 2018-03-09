using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.IBLL.AuthorizeManage;

namespace BerryCMS.BLL.AuthorizeManage
{
    /// <summary>
    /// 授权功能
    /// </summary>
    public partial class AuthorizeDataBLL : BaseBLL<AuthorizeDataEntity>, IAuthorizeDataBLL
    {
        protected override void SetDal()
        {
            Idal = DbSession.AuthorizeDataDal;
        }
    }
}