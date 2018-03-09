using System;
using BerryCMS.Extension;
using BerryCMS.Utils;

namespace BerryCMS.Code.Operator
{
    public class OperatorProvider : IOperatorProvider
    {
        #region 静态实例
        /// <summary>
        /// 当前提供者
        /// </summary>
        public static IOperatorProvider Provider => new OperatorProvider();
        #endregion

        /// <summary>
        /// 秘钥
        /// </summary>
        private string LoginUserKey = "__LoginUserKey";
        /// <summary>
        /// 登陆提供者模式:Session、Cookie 
        /// </summary>
        private readonly string _loginProvider = ConfigHelper.GetValue("LoginProvider");

        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        public virtual void AddCurrent(OperatorEntity user)
        {
            try
            {
                if (_loginProvider == "Cookie")
                {
                    #region 解决cookie时，设置数据权限较多时无法登陆的bug 
                    CacheFactory.CacheFactory.GetCache().WriteCache(user.DataAuthorize, LoginUserKey, user.LoginTime.AddHours(12));
                    user.DataAuthorize = null;
                    #endregion

                    CookieHelper.WriteCookie(LoginUserKey, DESEncryptHelper.Encrypt(user.TryToJson()));
                }
                else
                {
                    SessionHelper.AddSession(LoginUserKey, DESEncryptHelper.Encrypt(user.TryToJson()));
                }
                CacheFactory.CacheFactory.GetCache().WriteCache(user.Token, user.UserId, user.LoginTime.AddHours(12));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public virtual OperatorEntity Current()
        {
            try
            {
                OperatorEntity user = new OperatorEntity();
                if (_loginProvider == "Cookie")
                {
                    user = DESEncryptHelper.Decrypt(CookieHelper.GetCookie(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();

                    #region 解决cookie时，设置数据权限较多时无法登陆的bug
                    AuthorizeDataModel dataAuthorize = CacheFactory.CacheFactory.GetCache().GetCache<AuthorizeDataModel>(LoginUserKey);
                    user.DataAuthorize = dataAuthorize;
                    #endregion
                }
                else
                {
                    user = DESEncryptHelper.Decrypt(SessionHelper.GetSession<string>(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 删除登录信息
        /// </summary>
        public virtual void EmptyCurrent()
        {
            if (_loginProvider == "Cookie")
            {
                CookieHelper.DelCookie(LoginUserKey.Trim());

                #region 解决cookie时，设置数据权限较多时无法登陆的bug
                CacheFactory.CacheFactory.GetCache().RemoveCache(LoginUserKey);
                #endregion
            }
            else
            {
                SessionHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue()
        {
            try
            {
                object str = "";
                AuthorizeDataModel dataAuthorize = null;
                if (_loginProvider == "Cookie")
                {
                    str = CookieHelper.GetCookie(LoginUserKey);

                    #region 解决cookie时，设置数据权限较多时无法登陆的bug
                    dataAuthorize = CacheFactory.CacheFactory.GetCache().GetCache<AuthorizeDataModel>(LoginUserKey);

                    if (dataAuthorize == null)
                    {
                        return true;
                    }
                    #endregion
                }
                else
                {
                    str = SessionHelper.GetSession<string>(LoginUserKey);
                }
                if (str != null && str.ToString() != "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public virtual int IsOnLine()
        {
            OperatorEntity user = new OperatorEntity();
            if (_loginProvider == "Cookie")
            {
                user = DESEncryptHelper.Decrypt(CookieHelper.GetCookie(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();

                #region 解决cookie时，设置数据权限较多时无法登陆的bug
                AuthorizeDataModel dataAuthorize = CacheFactory.CacheFactory.GetCache().GetCache<AuthorizeDataModel>(LoginUserKey);
                user.DataAuthorize = dataAuthorize;
                #endregion
            }
            else
            {
                user = DESEncryptHelper.Decrypt(SessionHelper.GetSession<string>(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();
            }
            object token = CacheFactory.CacheFactory.GetCache().GetCache<string>(user.UserId);
            if (token == null)
            {
                return -1;//过期
            }
            if (user.Token == token.ToString())
            {
                return 1;//正常
            }
            else
            {
                return 0;//已登录
            }
        }
    }
}