using System.Data;
using BerryCMS.Entity;
using BerryCMS.IBLL.BaseManage;
using BerryCMS.Service.Base;
using Chloe;

namespace BerryCMS.BLL.BaseManage
{
    /// <summary>
    /// 公共BLL
    /// </summary>
    public class CommonBLL : BaseBLL<BaseEntity>, ICommonBLL
    {
        //private readonly CommonService _commonService = new CommonService();

        /// <summary>
        /// 初始化数据上下文
        /// </summary>
        protected override void SetDal()
        {
            Idal = DbSession.CommonDal;
        }

        ///// <summary>
        ///// 返回DataTable
        ///// </summary>
        ///// <param name="strSql">T-SQL语句</param>
        ///// <param name="type">CommandType</param>
        ///// <returns></returns>
        //public DataTable FindTable(string strSql, CommandType type = CommandType.Text)
        //{
        //    return _commonService.FindTable(strSql, type);
        //}

        ///// <summary>
        ///// 返回DataTable
        ///// </summary>
        ///// <param name="strSql">T-SQL语句</param>
        ///// <param name="type">CommandType</param>
        ///// <param name="dbParam">DbCommand参数</param>
        ///// <returns></returns>
        //public DataTable FindTable(string strSql, CommandType type, DbParam[] dbParam)
        //{
        //    throw new System.NotImplementedException();
        //}

    }
}