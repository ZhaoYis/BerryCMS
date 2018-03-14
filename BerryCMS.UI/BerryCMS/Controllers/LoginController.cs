using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BerryCMS.BLL.AuthorizeManage;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Code;
using BerryCMS.Code.Operator;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Extension;
using BerryCMS.Handler;
using BerryCMS.Utils;

namespace BerryCMS.Controllers
{
    /// <summary>
    /// 系统登录
    /// </summary>
    public class LoginController : BaseController
    {
        #region 实例
        private readonly UserBLL _userBll = new UserBLL();
        private readonly PermissionBLL _permissionBll = new PermissionBLL();
        private readonly AuthorizeBLL _authorizeBll = new AuthorizeBLL();
        #endregion

        /// <summary>
        /// 登录主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileContentResult VerifyCode()
        {
            return File(VerifyCodeHelper.GetVerifyCode(), @"image/Gif");
        }
         
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifycode">验证码</param>
        /// <param name="autologin">下次自动登录</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly(false)]
        public ActionResult CheckLogin(string username, string password, string verifycode, int autologin)
        {
            ActionResult res = null;
            Logger(this.GetType(), "登录验证-CheckLogin", () =>
            {
                #region 验证码验证
                string code = Md5Helper.Md5(verifycode.ToLower());
                string sessionCode = SessionHelper.GetSession<string>("session_verifycode");
                if (string.IsNullOrEmpty(sessionCode) || code != sessionCode)
                {
                    res = Error("验证码错误，请重新输入");
                }
                #endregion

                #region 账户验证
                else
                {
                    JsonObjectStatus status;
                    UserEntity user = _userBll.CheckLogin(username, password, out status);
                    if (status != JsonObjectStatus.Success || user == null)
                    {
                        res = Error(status.GetEnumDescription());
                    }
                    else
                    {
                        string objId = _permissionBll.GetObjectString(user.UserId);

                        OperatorEntity operators = new OperatorEntity
                        {
                            UserId = user.UserId,
                            Code = user.EnCode,
                            Account = user.Account,
                            UserName = user.RealName ?? user.NickName,
                            Password = user.Password,
                            Secretkey = user.Secretkey,
                            CompanyId = user.OrganizeId,
                            DepartmentId = user.DepartmentId,
                            IPAddress = NetHelper.Ip,
                            IPAddressName = NetHelper.GetAddressByIP(NetHelper.Ip),
                            ObjectId = objId,
                            LoginTime = DateTime.Now,
                            Token = DESEncryptHelper.Encrypt(CommonHelper.GetGuid(), user.Secretkey)
                        }; 

                        //写入当前用户数据权限
                        AuthorizeDataModel dataAuthorize = new AuthorizeDataModel
                        {
                            ReadAutorize = _authorizeBll.GetDataAuthor(operators),
                            ReadAutorizeUserId = _authorizeBll.GetDataAuthorUserId(operators),
                            WriteAutorize = _authorizeBll.GetDataAuthor(operators, true),
                            WriteAutorizeUserId = _authorizeBll.GetDataAuthorUserId(operators, true)
                        };
                        operators.DataAuthorize = dataAuthorize;
                        //判断是否系统管理员
                        operators.IsSystem = user.Account == "System";

                        //写入登录信息
                        OperatorProvider.Provider.AddCurrent(operators);

                        res = Success("登录成功", user, "/Home/AdminDefault");
                    }
                }
                #endregion

            }, e =>
            {
                res = Error("系统异常：" + e.Message);
            }, () =>
            {
                SessionHelper.RemoveSession("session_verifycode");
            });
            return res;
        }
    }
}