using System.Data;
using BerryCMS.Entity;
using Chloe;

namespace BerryCMS.IDAL.BaseManage
{
    /// <summary>
    /// 公共DAL
    /// </summary>
    public partial interface ICommonDAL : IBaseDAL<BaseEntity>
    {
        ///// <summary>
        ///// 返回DataTable
        ///// </summary>
        ///// <param name="strSql">T-SQL语句</param>
        ///// <param name="type">CommandType</param>
        ///// <returns></returns>
        //DataTable FindTable(string strSql, CommandType type);
        ///// <summary>
        ///// 返回DataTable
        ///// </summary>
        ///// <param name="strSql">T-SQL语句</param>
        ///// <param name="type">CommandType</param>
        ///// <param name="dbParam">DbCommand参数</param>
        ///// <returns></returns>
        //DataTable FindTable(string strSql, CommandType type, DbParam[] dbParam);
    }
}