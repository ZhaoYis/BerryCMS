﻿using BerryCMS.IDAL;
using BerryCMS.IDAL.AuthorizeManage;
using BerryCMS.IDAL.BaseManage;
using BerryCMS.MsSQL.AuthorizeManage;
using BerryCMS.MsSQL.BaseManage;

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
    }
}