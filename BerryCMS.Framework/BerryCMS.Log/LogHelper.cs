﻿using System;
using System.Runtime.CompilerServices;
using BerryCMS.Utils;
using log4net;

namespace BerryCMS.Log
{
    public class LogHelper
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        private static ILog _log;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="type">日志對象</param>
        public LogHelper(Type type)
        {
            _log = LogManager.GetLogger(type);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="typeName"></param>
        public LogHelper(string typeName)
        {
            _log = LogManager.GetLogger(typeName);
        }

        /// <summary>
        /// 得到日志对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ILog GetLogger(string type)
        {
            return LogManager.GetLogger(type);
        }

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理，无返回值
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="desc">描述</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public static void Logger(Type type, string desc, ErrorHandel errorHandel, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            ILog log = LogManager.GetLogger(type);
            try
            {
                //log.Debug(desc + "\r\n");

                tryHandel();
            }
            catch (Exception e)
            {
                #region 组装异常信息

                LogMessage message = new LogMessage
                {
                    OperationTime = DateTime.Now,
                    Url = e.Source,
                    Browser = NetHelper.Browser,
                    Class = type.Namespace + type.FullName,
                    Ip = NetHelper.Ip,
                    Host = NetHelper.Host,
                    ExceptionInfo = e.Message,
                    ExceptionSource = e.Source,
                    Content = desc
                };

                string msg = LogFormat.ExceptionFormat(message);
                #endregion

                log.Error(msg);

                if (catchHandel != null)
                {
                    catchHandel(e);
                }

                if (errorHandel == ErrorHandel.Throw)
                {
                    throw;
                }
            }
            finally
            {
                if (finallHandel != null)
                {
                    finallHandel();
                }
            }
        }

        public static T Logger<T>(Type type, string desc, ErrorHandel errorHandel, Func<T> tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            ILog log = LogManager.GetLogger(type);
            try
            {
                //log.Debug(desc + "\r\n");

                return tryHandel();
            }
            catch (Exception e)
            {
                #region 组装异常信息

                LogMessage message = new LogMessage
                {
                    OperationTime = DateTime.Now,
                    Url = e.Source,
                    Browser = NetHelper.Browser,
                    Class = type.Namespace + type.FullName,
                    Ip = NetHelper.Ip,
                    Host = NetHelper.Host,
                    ExceptionInfo = e.Message,
                    ExceptionSource = e.Source,
                    Content = desc
                };

                string msg = LogFormat.ExceptionFormat(message);
                #endregion

                log.Error(msg);

                if (catchHandel != null)
                {
                    catchHandel(e);
                }

                if (errorHandel == ErrorHandel.Throw)
                {
                    throw;
                }
            }
            finally
            {
                if (finallHandel != null)
                {
                    finallHandel();
                }
            }
            return default(T);
        }

        #region 1、Info
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            _log.Info(info);
        }

        /// <summary>
        /// 普通日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
        #endregion

        #region 2、Error
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        public void Error(string info)
        {
            _log.Error(info);
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="exception"></param>
        public void Error(string info, Exception exception)
        {
            _log.Error(info, exception);
        }

        /// <summary>
        /// 错误日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        #endregion

        #region 3、Debug
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="info"></param>
        public void Debug(string info)
        {
            _log.Debug(info);
        }

        /// <summary>
        /// 调试日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }
        #endregion

        #region 4、Warn
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="info"></param>
        public void Warn(string info)
        {
            _log.Warn(info);
        }

        /// <summary>
        /// 警告日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }
        #endregion
    }
}