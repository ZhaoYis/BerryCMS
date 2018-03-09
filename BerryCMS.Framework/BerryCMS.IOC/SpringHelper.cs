using System;
using Spring.Context;
using Spring.Context.Support;

namespace BerryCMS.IOC
{
    public class SpringHelper
    {
        /// <summary>
        /// Spring.Net上下文
        /// </summary>
        private static IApplicationContext SpringContext
        {
            get
            {
                try
                {
                    return ContextRegistry.GetContext();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// 使用Spring操作配置文件并转化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objName"></param>
        /// <returns></returns>
        public static T GetObject<T>(string objName) where T : class
        {
            try
            {
                return (T)SpringContext.GetObject(objName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}