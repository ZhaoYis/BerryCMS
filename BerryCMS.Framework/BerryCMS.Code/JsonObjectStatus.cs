using System.ComponentModel;

namespace BerryCMS.Code
{
    #region ===========全局通用状态枚举===========
    /// <summary>
    /// 全局通用状态枚举
    /// </summary>
    public enum JsonObjectStatus
    {
        #region 系统
        /// <summary>
        /// 默认，无实际意义。
        /// </summary>
        Default = -1,

        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Description("请求(或处理)成功")]
        Success = 200,

        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Description("内部请求出错")]
        Error = 500,

        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        Fail = 408,

        /// <summary>
        /// 服务器异常
        /// </summary>
        [Description("服务器异常")]
        Exception = 409,
        #endregion

        #region Http请求
        /// <summary>
        /// 请求授权信息参数不完整或不正确
        /// </summary>
        [Description("请求授权信息参数不完整或不正确")]
        ParameterError = 400,

        /// <summary>
        /// 未授权
        /// </summary>
        [Description("未授权")]
        Unauthorized = 401,

        /// <summary>
        /// 请求Token授权信息参数【用户编号】不存在
        /// </summary>
        [Description("请求Token授权信息参数【用户编号】不存在")]
        ParameterStaffIdNotExist = 402,

        /// <summary>
        /// 请求TOKEN失效
        /// </summary>
        [Description("请求TOKEN失效")]
        TokenInvalid = 403,

        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [Description("HTTP请求类型不合法")]
        HttpMehtodError = 405,

        /// <summary>
        /// HTTP请求不合法,请求参数可能被篡改
        /// </summary>
        [Description("HTTP请求不合法，请求参数可能被篡改")]
        HttpRequestError = 406,

        /// <summary>
        /// 该URL已经失效或请求时间戳失效
        /// </summary>
        [Description("该URL已经失效或请求时间戳失效")]
        UrlExpireError = 407,
        #endregion

        #region 登录验证
        /// <summary>
        /// 账号错误
        /// </summary>
        [Description("账号错误")]
        AccountErr = 410,

        /// <summary>
        /// 密码错误
        /// </summary>
        [Description("密码错误")]
        PasswordErr = 411,

        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误")]
        ValidateCodeErr = 412,

        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        UserNotExist = 413,

        /// <summary>
        /// 记录已经存在
        /// </summary>
        [Description("记录已经存在")]
        RecordAlreadyExists = 414,

        /// <summary>
        /// 记录不存在
        /// </summary>
        [Description("记录不存在")]
        RecordNotExists = 419,
        #endregion

        #region 账号状态
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        AccountNormal = 415,
        /// <summary>
        /// 账号被锁定
        /// </summary>
        [Description("账号被锁定")]
        AccountLock = 416,
        /// <summary>
        /// 账号被禁用
        /// </summary>
        [Description("账号被禁用")]
        AccountDisable = 417,
        /// <summary>
        /// 未启用
        /// </summary>
        [Description("未启用")]
        AccountNotEnabled = 418,
        #endregion

    }
    #endregion
}