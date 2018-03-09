using BerryCMS.Entity.BaseManage;
using BerryCMS.IBLL.BaseManage;

namespace BerryCMS.BLL.BaseManage
{
    /// <summary>
    /// 用户关系
    /// </summary>
    public partial class UserRelationBLL : BaseBLL<UserRelationEntity>, IUserRelationBLL
    {
        protected override void SetDal()
        {
            Idal = DbSession.UserRelationDal;
        }
    }
}