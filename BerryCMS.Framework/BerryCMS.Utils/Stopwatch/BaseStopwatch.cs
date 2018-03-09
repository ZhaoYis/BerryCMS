using System;

namespace BerryCMS.Utils.Stopwatch
{
    public class BaseStopwatch
    {
        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        protected static string Stopwatch(Action function)
        {
            return StopwatchHelper.Stopwatch(function);
        }
    }
}