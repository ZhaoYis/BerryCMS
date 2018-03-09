using System.Data;
using Chloe;

namespace BerryCMS.IBLL.BaseManage
{
    /// <summary>
    /// 公共BLL
    /// </summary>
    public partial interface ICommonBLL
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, CommandType type = CommandType.Text);
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <param name="dbParam">DbCommand参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, CommandType type, DbParam[] dbParam);

    }
}