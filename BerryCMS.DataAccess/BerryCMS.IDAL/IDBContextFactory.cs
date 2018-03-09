using BerryCMS.Code;
using Chloe;

namespace BerryCMS.IDAL
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public interface IDBContextFactory
    {
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns></returns>
        IDbContext GetDbContext();
    }
}