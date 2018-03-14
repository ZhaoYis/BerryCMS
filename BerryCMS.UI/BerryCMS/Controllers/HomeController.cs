using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BerryCMS.BLL.SystemManage;
using BerryCMS.Code;
using BerryCMS.Code.Operator;
using BerryCMS.Entity;
using BerryCMS.Extension;
using BerryCMS.Handler;

namespace BerryCMS.Controllers
{
    /// <summary>
    /// 后台主页
    /// </summary>
    [HandlerLogin(LoginMode.Enforce)]
    public class HomeController : Controller
    {
        private readonly LogBLL _logBll = new LogBLL();

        #region 视图
        /// <summary>
        /// 默认系统主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDefault()
        {
            return View();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleId, string moduleName, string moduleUrl)
        {
            LogEntity logEntity = new LogEntity
            {
                CategoryId = (int)CategoryType.Visit,
                OperateTypeId = ((int)OperationType.Visit).ToString(),
                OperateType = OperationType.Visit.GetEnumDescription(),
                OperateAccount = OperatorProvider.Provider.Current().Account,
                OperateUserId = OperatorProvider.Provider.Current().UserId,
                ModuleId = moduleId,
                Module = moduleName,
                ExecuteResult = 1,
                ExecuteResultJson = "访问地址：" + moduleUrl
            };

            _logBll.WriteLog(logEntity);

            return Content(moduleId);
        }

        #endregion
    }
}