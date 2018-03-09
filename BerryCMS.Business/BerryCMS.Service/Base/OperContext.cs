using System.Runtime.Remoting.Messaging;
using BerryCMS.IBLL;
using BerryCMS.IOC;

namespace BerryCMS.Service.Base
{
    public class OperContext
    {
        /// <summary>
        /// 务层仓储
        /// </summary>
        public IBLLSession BllSession;
        private OperContext()
        {
            BllSession = SpringHelper.GetObject<IBLLSession>("BLLSession");
        }

        /// <summary>
        /// 得到务层仓储上下文
        /// </summary>
        public static OperContext CurrentContext
        {
            get
            {
                OperContext operContext = CallContext.GetData(typeof(OperContext).Name) as OperContext;
                if (operContext == null)
                {
                    operContext = new OperContext();
                    CallContext.SetData(typeof(OperContext).Name, operContext);
                }
                return operContext;
            }
        }
    }
}