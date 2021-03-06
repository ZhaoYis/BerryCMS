﻿using System;
using System.Linq.Expressions;
using BerryCMS.Entity;
using BerryCMS.Extension;
using BerryCMS.IService.SystemManage;
using BerryCMS.Service.Base;
using BerryCMS.Utils;

namespace BerryCMS.Service.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class LogService : BaseService, ILogService
    {
        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public LogEntity GetEntity(string keyValue)
        {
            LogEntity res = o.BllSession.LogBll.FindEntity(keyValue);

            return res;
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        public void RemoveLog(int categoryId, string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")//保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")//保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")//保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }

            Expression<Func<LogEntity, bool>> expression = LambdaExtension.True<LogEntity>();

            expression = expression.And(l => l.CategoryId.Equals(categoryId));
            expression = expression.And(l => l.OperateTime <= operateTime);

            int res = o.BllSession.LogBll.Delete(expression);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        public void WriteLog(LogEntity logEntity)
        {
            logEntity.LogId = CommonHelper.GetGuid().ToString();
            logEntity.OperateTime = DateTime.Now;
            logEntity.DeleteMark = false;
            logEntity.EnabledMark = true;
            logEntity.IPAddress = NetHelper.Ip;
            logEntity.Host = NetHelper.Host;
            logEntity.Browser = NetHelper.Browser;

            bool res = o.BllSession.LogBll.Insert(logEntity);
        }
    }
}