using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BerryCMS.Code;
using BerryCMS.Entity;
using BerryCMS.Extension;
using BerryCMS.Log;

namespace BerryCMS.Handler
{
    public abstract class BaseController : Controller, ILogger
    {
        #region 系统日志
        /// <summary>
        /// 系统日志 对try块进行了封装
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">描述</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null,
            ErrorHandel errorHandel = ErrorHandel.Throw)
        {
            LogHelper.Logger(type, desc, errorHandel, tryHandel, catchHandel, finallHandel);
        }
        public T Logger<T>(Type type, string desc, Func<T> tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null,
            ErrorHandel errorHandel = ErrorHandel.Throw)
        {
            return LogHelper.Logger<T>(type, desc, errorHandel, tryHandel, catchHandel, finallHandel);
        }
        #endregion

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult ToJsonResult(object data)
        {
            return Content(data.TryToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Success, Message = message }.TryToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <param name="backUrl">跳转地址</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data,string backUrl)
        {
            return Content(new BaseJsonResult<object> { Status = (int)JsonObjectStatus.Success, Message = message, Data = data,BackUrl = backUrl }.TryToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Fail, Message = message }.TryToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message, object data)
        {
            return Content(new BaseJsonResult<object> { Status = (int)JsonObjectStatus.Fail, Message = message, Data = data }.TryToJson());
        }

    }
}