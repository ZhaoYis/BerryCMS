﻿using BerryCMS.Entity;

namespace BerryCMS.IService.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public interface ILogService
    {
        #region 获取数据
        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        LogEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        void RemoveLog(int categoryId, string keepTime);
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        void WriteLog(LogEntity logEntity);
        #endregion
    }
}