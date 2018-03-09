using System.Runtime.Remoting.Messaging;
using BerryCMS.IBLL;

namespace BerryCMS.BLL
{
    /// <summary>
    /// BLLSession工厂类
    /// </summary>
    public class BLLSessionFactory : IBLLSessionFactory
    {
        /// <summary>
        /// 获取BLLSession
        /// </summary>
        /// <returns></returns>
        public IBLLSession GetBllSession()
        {
            IBLLSession bllSession = CallContext.GetData(typeof(BLLSessionFactory).Name) as BLLSession;
            if (bllSession == null)
            {
                bllSession = new BLLSession();
                CallContext.SetData(typeof(BLLSessionFactory).Name, bllSession);
            }
            return bllSession;
        }
    }
}