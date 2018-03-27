using BerryCMS.BLL.AuthorizeManage;
using BerryCMS.BLL.BaseManage;
using BerryCMS.BLL.SystemManage;
using BerryCMS.IBLL;
using BerryCMS.IBLL.AuthorizeManage;
using BerryCMS.IBLL.BaseManage;
using BerryCMS.IBLL.SystemManage;

namespace BerryCMS.BLL
{
    public partial class BLLSession : IBLLSession
    {
        #region 01、业务接口 IUserBLL
        private IUserBLL _iUserBll;
        public IUserBLL UserBll
        {
            get
            {
                return _iUserBll ?? (_iUserBll = new UserBLL());
            }
            set
            {
                _iUserBll = value;
            }
        }
        #endregion

        #region 02、业务接口 IAuthorizeBLL
        private IAuthorizeBLL _iAuthorizeBll;
        public IAuthorizeBLL AuthorizeBll
        {
            get
            {
                return _iAuthorizeBll ?? (_iAuthorizeBll = new AuthorizeBLL());
            }
            set
            {
                _iAuthorizeBll = value;
            }
        }
        #endregion

        #region 03、业务接口 IAuthorizeDataBLL
        private IAuthorizeDataBLL _iAuthorizeDataBll;
        public IAuthorizeDataBLL AuthorizeDataBll
        {
            get
            {
                return _iAuthorizeDataBll ?? (_iAuthorizeDataBll = new AuthorizeDataBLL());
            }
            set
            {
                _iAuthorizeDataBll = value;
            }
        }
        #endregion

        #region 04、业务接口 IUserRelationBLL
        private IUserRelationBLL _iUserRelationBll;
        public IUserRelationBLL UserRelationBll
        {
            get
            {
                return _iUserRelationBll ?? (_iUserRelationBll = new UserRelationBLL());
            }
            set
            {
                _iUserRelationBll = value;
            }
        }
        #endregion

        #region 05、业务接口 IModuleColumnBLL
        private IModuleColumnBLL _iModuleColumnBll;
        public IModuleColumnBLL ModuleColumnBll
        {
            get
            {
                return _iModuleColumnBll ?? (_iModuleColumnBll = new ModuleColumnBLL());
            }
            set
            {
                _iModuleColumnBll = value;
            }
        }
        #endregion

        #region 06、业务接口 IModuleButtonBLL
        private IModuleButtonBLL _iModuleButtonBll;
        public IModuleButtonBLL ModuleButtonBll
        {
            get
            {
                return _iModuleButtonBll ?? (_iModuleButtonBll = new ModuleButtonBLL());
            }
            set
            {
                _iModuleButtonBll = value;
            }
        }
        #endregion

        #region 07、业务接口 IModuleBLL
        private IModuleBLL _iModuleBll;
        public IModuleBLL ModuleBll
        {
            get
            {
                return _iModuleBll ?? (_iModuleBll = new ModuleBLL());
            }
            set
            {
                _iModuleBll = value;
            }
        }
        #endregion

        #region 08、公共业务接口 ICommonBLL
        private ICommonBLL _iCommonBll;
        public ICommonBLL CommonBll
        {
            get
            {
                return _iCommonBll ?? (_iCommonBll = new CommonBLL());
            }
            set
            {
                _iCommonBll = value;
            }
        }
        #endregion

        #region 09、系统日志业务接口 ILogBLL
        private ILogBLL _iLogBll;
        public ILogBLL LogBll
        {
            get
            {
                return _iLogBll ?? (_iLogBll = new LogBLL());
            }
            set
            {
                _iLogBll = value;
            }
        }
        #endregion

        #region 10、系统机构管理业务接口 IOrganizeBLL
        private IOrganizeBLL _iOrganizeBll;
        public IOrganizeBLL OrganizeBll
        {
            get
            {
                return _iOrganizeBll ?? (_iOrganizeBll = new OrganizeBLL());
            }
            set
            {
                _iOrganizeBll = value;
            }
        }
        #endregion

        #region 11、系统部门管理业务接口 IDepartmentBLL
        private IDepartmentBLL _iDepartmentBll;
        public IDepartmentBLL DepartmentBll
        {
            get
            {
                return _iDepartmentBll ?? (_iDepartmentBll = new DepartmentBLL());
            }
            set
            {
                _iDepartmentBll = value;
            }
        }
        #endregion

        #region 12、系统用户组管理业务接口 IUserGroupBLL
        private IUserGroupBLL _iUserGroupBll;
        public IUserGroupBLL UserGroupBll
        {
            get
            {
                return _iUserGroupBll ?? (_iUserGroupBll = new UserGroupBLL());
            }
            set
            {
                _iUserGroupBll = value;
            }
        }
        #endregion
        
        #region 13、系统岗位管理业务接口 IPostBLL
        private IPostBLL _iPostBll;
        public IPostBLL PostBll
        {
            get
            {
                return _iPostBll ?? (_iPostBll = new PostBLL());
            }
            set
            {
                _iPostBll = value;
            }
        }
        #endregion
        
        #region 14、系统角色管理业务接口 IRoleBLL
        private IRoleBLL _iRoleBll;
        public IRoleBLL RoleBll
        {
            get
            {
                return _iRoleBll ?? (_iRoleBll = new RoleBLL());
            }
            set
            {
                _iRoleBll = value;
            }
        }
        #endregion
        
        #region 15、系统数据字典分类管理业务接口 IDataItemBLL
        private IDataItemBLL _iDataItemBll;
        public IDataItemBLL DataItemBll
        {
            get
            {
                return _iDataItemBll ?? (_iDataItemBll = new DataItemBLL());
            }
            set
            {
                _iDataItemBll = value;
            }
        }
        #endregion

        #region 16、系统数据字典明细管理业务接口 IDataItemDetailBLL
        private IDataItemDetailBLL _iDataItemDetailBll;
        public IDataItemDetailBLL DataItemDetailBll
        {
            get
            {
                return _iDataItemDetailBll ?? (_iDataItemDetailBll = new DataItemDetailBLL());
            }
            set
            {
                _iDataItemDetailBll = value;
            }
        }
        #endregion
    }
}