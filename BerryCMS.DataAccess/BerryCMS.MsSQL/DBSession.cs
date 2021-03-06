﻿using BerryCMS.IDAL;
using BerryCMS.IDAL.AuthorizeManage;
using BerryCMS.IDAL.BaseManage;
using BerryCMS.IDAL.SystemManage;
using BerryCMS.MsSQL.AuthorizeManage;
using BerryCMS.MsSQL.BaseManage;
using BerryCMS.MsSQL.SystemManage;

namespace BerryCMS.MsSQL
{
    public partial class DBSession : IDBSession
    {
        #region 01、数据接口 IUserDAL
        private IUserDAL _iUserDal;
        public IUserDAL UserDal
        {
            get
            {
                return _iUserDal ?? (_iUserDal = new UserDAL());
            }
            set
            {
                _iUserDal = value;
            }
        }
        #endregion

        #region 02、数据接口 IAuthorizeDAL
        private IAuthorizeDAL _iAuthorizeDal;
        public IAuthorizeDAL AuthorizeDal
        {
            get
            {
                return _iAuthorizeDal ?? (_iAuthorizeDal = new AuthorizeDAL());
            }
            set
            {
                _iAuthorizeDal = value;
            }
        }
        #endregion

        #region 03、数据接口 IAuthorizeDataDAL
        private IAuthorizeDataDAL _iAuthorizeDataDal;
        public IAuthorizeDataDAL AuthorizeDataDal
        {
            get
            {
                return _iAuthorizeDataDal ?? (_iAuthorizeDataDal = new AuthorizeDataDAL());
            }
            set
            {
                _iAuthorizeDataDal = value;
            }
        }
        #endregion

        #region 04、数据接口 IUserRelationDAL
        private IUserRelationDAL _iUserRelationDal;
        public IUserRelationDAL UserRelationDal
        {
            get
            {
                return _iUserRelationDal ?? (_iUserRelationDal = new UserRelationDAL());
            }
            set
            {
                _iUserRelationDal = value;
            }
        }
        #endregion

        #region 05、数据接口 IModuleColumnDAL
        private IModuleColumnDAL _iModuleColumnDal;
        public IModuleColumnDAL ModuleColumnDal
        {
            get
            {
                return _iModuleColumnDal ?? (_iModuleColumnDal = new ModuleColumnDAL());
            }
            set
            {
                _iModuleColumnDal = value;
            }
        }
        #endregion

        #region 06、数据接口 IModuleButtonDAL
        private IModuleButtonDAL _iModuleButtonDal;
        public IModuleButtonDAL ModuleButtonDal
        {
            get
            {
                return _iModuleButtonDal ?? (_iModuleButtonDal = new ModuleButtonDAL());
            }
            set
            {
                _iModuleButtonDal = value;
            }
        }
        #endregion

        #region 07、数据接口 IModuleDAL
        private IModuleDAL _iModuleDal;
        public IModuleDAL ModuleDal
        {
            get
            {
                return _iModuleDal ?? (_iModuleDal = new ModuleDAL());
            }
            set
            {
                _iModuleDal = value;
            }
        }
        #endregion

        #region 08、公共数据接口 ICommonDAL
        private ICommonDAL _iCommonDal;
        public ICommonDAL CommonDal
        {
            get
            {
                return _iCommonDal ?? (_iCommonDal = new CommonDAL());
            }
            set
            {
                _iCommonDal = value;
            }
        }
        #endregion

        #region 09、系统日志接口 ILogDAL
        private ILogDAL _iLogDal;
        public ILogDAL LogDal
        {
            get
            {
                return _iLogDal ?? (_iLogDal = new LogDAL());
            }
            set
            {
                _iLogDal = value;
            }
        }
        #endregion

        #region 10、系统机构管理接口 IOrganizeDAL
        private IOrganizeDAL _iOrganizeDal;
        public IOrganizeDAL OrganizeDal
        {
            get
            {
                return _iOrganizeDal ?? (_iOrganizeDal = new OrganizeDAL());
            }
            set
            {
                _iOrganizeDal = value;
            }
        }
        #endregion

        #region 11、系统部门管理接口 IDepartmentDAL
        private IDepartmentDAL _iDepartmentDal;
        public IDepartmentDAL DepartmentDal
        {
            get
            {
                return _iDepartmentDal ?? (_iDepartmentDal = new DepartmentDAL());
            }
            set
            {
                _iDepartmentDal = value;
            }
        }
        #endregion

        #region 12、系统用户组管理接口 IUserGroupDAL
        private IUserGroupDAL _iUserGroupDal;
        public IUserGroupDAL UserGroupDal
        {
            get
            {
                return _iUserGroupDal ?? (_iUserGroupDal = new UserGroupDAL());
            }
            set
            {
                _iUserGroupDal = value;
            }
        }
        #endregion

        #region 13、系统岗位管理接口 IPostDAL
        private IPostDAL _iPostDal;
        public IPostDAL PostDal
        {
            get
            {
                return _iPostDal ?? (_iPostDal = new PostDAL());
            }
            set
            {
                _iPostDal = value;
            }
        }
        #endregion

        #region 14、系统角色管理接口 IRoleDAL
        private IRoleDAL _iRoleDal;
        public IRoleDAL RoleDal
        {
            get
            {
                return _iRoleDal ?? (_iRoleDal = new RoleDAL());
            }
            set
            {
                _iRoleDal = value;
            }
        }
        #endregion

        #region 15、系统数据字典分类管理接口 IDataItemDAL
        private IDataItemDAL _iDataItemDal;
        public IDataItemDAL DataItemDal
        {
            get
            {
                return _iDataItemDal ?? (_iDataItemDal = new DataItemDAL());
            }
            set
            {
                _iDataItemDal = value;
            }
        }
        #endregion

        #region 16、系统数据字典明细管理接口 IDataItemDetailDAL
        private IDataItemDetailDAL _iDataItemDetailDal;
        public IDataItemDetailDAL DataItemDetailDal
        {
            get
            {
                return _iDataItemDetailDal ?? (_iDataItemDetailDal = new DataItemDetailDAL());
            }
            set
            {
                _iDataItemDetailDal = value;
            }
        }
        #endregion
    }
}