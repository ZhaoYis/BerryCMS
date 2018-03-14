using System;
using System.Web.Mvc;
using BerryCMS.Code;
using BerryCMS.Code.Operator;
using BerryCMS.Utils;

namespace BerryCMS.Handler
{
    /// <summary>
    /// 登陆认证
    /// </summary>
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        private readonly LoginMode _loginMode;

        public HandlerLoginAttribute(LoginMode loginMode)
        {
            this._loginMode = loginMode;
        }

        /// <summary>
        /// 响应前执行登录验证,查看当前用户是否有效 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //登录拦截是否忽略
            if (_loginMode == LoginMode.Ignore)
            {
                return;
            }

            //登录是否过期
            if (OperatorProvider.Provider.IsOverdue())
            {
                CookieHelper.WriteCookie("__login_error__", "Overdue");//登录已超时,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }

            //是否已登录
            int onLine = OperatorProvider.Provider.IsOnLine();
            if (onLine == 0)
            {
                CookieHelper.WriteCookie("__login_error__", "OnLine");//您的帐号已在其它地方登录,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            else if (onLine == -1)
            {
                CookieHelper.WriteCookie("__login_error__", "-1");//缓存已超时,请重新登录
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
        }
    }
}