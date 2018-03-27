using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.IBLL.BaseManage;
using BerryCMS.IBLL.SystemManage;

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
        /// <summary>
        /// 系统日志
        /// </summary>
        ILogBLL LogBll { get; set; }
        /// <summary>
        /// 机构
        /// </summary>
        IOrganizeBLL OrganizeBll { get; set; }
        /// <summary>
        /// 部门管理
        /// </summary>
        IDepartmentBLL DepartmentBll { get; set; }
        /// <summary>
        /// 用户组管理
        /// </summary>
        IUserGroupBLL UserGroupBll { get; set; }
        /// <summary>
        /// 岗位管理
        /// </summary>
        IPostBLL PostBll { get; set; }
        /// <summary>
        /// 角色管理
        /// </summary>
        IRoleBLL RoleBll { get; set; }
        /// <summary>
        /// 数据字典分类
        /// </summary>
        IDataItemBLL DataItemBll { get; set; }
        /// <summary>
        /// 数据字典明细
        /// </summary>
        IDataItemDetailBLL DataItemDetailBll { get; set; }
    }
}