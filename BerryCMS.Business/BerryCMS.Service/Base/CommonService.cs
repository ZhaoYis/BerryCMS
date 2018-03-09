using System.Data;
using BerryCMS.IService.BaseManage;

namespace BerryCMS.Service.Base
{
    /// <summary>
    /// 公共服务
    /// </summary>
    public class CommonService : BaseService, ICommonService
    {
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, CommandType type)
        {
            DataTable data = o.BllSession.CommonBll.FindTable(strSql, type);

            return data;
        }
    }
}