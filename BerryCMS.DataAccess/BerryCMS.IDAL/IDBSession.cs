
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
    }
}