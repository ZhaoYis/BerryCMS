using System.Runtime.Remoting.Messaging;
using BerryCMS.IDAL;

namespace BerryCMS.MsSQL
{
    public class DBSessionFactory : IDBSessionFactory
    {
        public IDBSession GetDbSession()
        {
            IDBSession dbSession = CallContext.GetData(typeof(DBSessionFactory).Name) as DBSession;
            if (dbSession == null)
            {
                dbSession = new DBSession();
                CallContext.SetData(typeof(DBSessionFactory).Name, dbSession);
            }
            return dbSession;
        }
    }
}