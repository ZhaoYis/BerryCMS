using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.IBLL.BaseManage;

namespace BerryCMS.IBLL
{
    /// <summary>
    /// BLLSession接口
    /// </summary>
    public interface IBLLSession
    {
        /// <summary>
        /// 系统用户
        /// </summary>
        IUserBLL UserBll { get; set; }
        /// <summary>
        /// 授权数据
        /// </summary>
        IAuthorizeBLL AuthorizeBll { get; set; }
        /// <summary>
        /// 授权功能
        /// </summary>
        IAuthorizeDataBLL AuthorizeDataBll { get; set; }
        /// <summary>
        /// 用户关系
        /// </summary>
        IUserRelationBLL UserRelationBll { get; set; }
        /// <summary>
        /// 系统视图
        /// </summary>
        IModuleColumnBLL ModuleColumnBll { get; set; }
        /// <summary>
        /// 系统按钮
        /// </summary>
        IModuleButtonBLL ModuleButtonBll { get; set; }
        /// <summary>
        /// 系统功能
        /// </summary>
        IModuleBLL ModuleBll { get; set; }
        /// <summary>
        /// 公共BLL
        /// </summary>
        ICommonBLL CommonBll { get; set; }
    }
}