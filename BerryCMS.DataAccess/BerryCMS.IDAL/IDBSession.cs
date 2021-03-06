﻿
using BerryCMS.IDAL.AuthorizeManage;
using BerryCMS.IDAL.BaseManage;
using BerryCMS.IDAL.SystemManage;

namespace BerryCMS.IDAL
{
    /// <summary>
    /// DBSession工厂类接口
    /// </summary>
    public partial interface IDBSession
    {
        #region 通用
        /// <summary>
        /// 公共DAL
        /// </summary>
        ICommonDAL CommonDal { get; set; }
        /// <summary>
        /// 系统日志
        /// </summary>
        ILogDAL LogDal { get; set; }
        #endregion

        /// <summary>
        /// 系统用户
        /// </summary>
        IUserDAL UserDal { get; set; }
        /// <summary>
        /// 授权功能
        /// </summary>
        IAuthorizeDAL AuthorizeDal { get; set; }
        /// <summary>
        /// 授权数据范围
        /// </summary>
        IAuthorizeDataDAL AuthorizeDataDal { get; set; }
        /// <summary>
        /// 用户关系
        /// </summary>
        IUserRelationDAL UserRelationDal { get; set; }
        /// <summary>
        /// 系统视图
        /// </summary>
        IModuleColumnDAL ModuleColumnDal { get; set; }
        /// <summary>
        /// 系统功能按钮
        /// </summary>
        IModuleButtonDAL ModuleButtonDal { get; set; }
        /// <summary>
        /// 系统功能
        /// </summary>
        IModuleDAL ModuleDal { get; set; }
        /// <summary>
        /// 机构管理
        /// </summary>
        IOrganizeDAL OrganizeDal { get; set; }
        /// <summary>
        /// 部门管理
        /// </summary>
        IDepartmentDAL DepartmentDal { get; set; }
        /// <summary>
        /// 用户组管理
        /// </summary>
        IUserGroupDAL UserGroupDal { get; set; }
        /// <summary>
        /// 岗位管理
        /// </summary>
        IPostDAL PostDal { get; set; }
        /// <summary>
        /// 角色管理
        /// </summary>
        IRoleDAL RoleDal { get; set; }
        /// <summary>
        /// 数据字典分类
        /// </summary>
        IDataItemDAL DataItemDal { get; set; }
        /// <summary>
        /// 数据字典明细
        /// </summary>
        IDataItemDetailDAL DataItemDetailDal { get; set; }
    }
}