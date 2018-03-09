namespace BerryCMS.IDAL
{
    /// <summary>
    /// 提取仓储对象的工厂
    /// </summary>
    public interface IDBSessionFactory
    {
        IDBSession GetDbSession();
    }
}