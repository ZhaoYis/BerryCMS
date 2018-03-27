using System.Data;
using BerryCMS.Entity;
using BerryCMS.Extension;
using BerryCMS.IDAL;
using BerryCMS.IDAL.BaseManage;
using Chloe;

namespace BerryCMS.MsSQL.BaseManage
{
    /// <summary>
    /// 公共DAL
    /// </summary>
    public partial class CommonDAL : BaseDAL<BaseEntity>,ICommonDAL
    {
        //private readonly IDbContext _context = new DBContextFactory().GetDbContext();

        ///// <summary>
        ///// 返回DataTable
        ///// </summary>
        ///// <param name="strSql">T-SQL语句</param>
        ///// <param name="type">CommandType</param>
        ///// <returns></returns>
        //public DataTable FindTable(string strSql, CommandType type)
        //{
        //    DataTable res = _context.Session.ExecuteReader(strSql, type).IDataReaderToDataTable();
        //    return res;
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
        //    DataTable res = _context.Session.ExecuteReader(strSql, type, dbParam).IDataReaderToDataTable();//.SqlQuery<T>(strSql, DbParam).ToList().ListToDataTable();
        //    return res;
        //}
    }
}