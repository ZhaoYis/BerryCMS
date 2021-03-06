﻿using System;
using System.Collections.Generic;

namespace BerryCMS.Entity
{
    #region 标准Json基类 不带分页
    /// <summary>
    /// 基类Json 非分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BaseJsonResult<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 跳转地址
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public string ExecutionTime { get; set; }
    }
    #endregion

    #region 标准Json基类 带分页
    /// <summary>
    /// 基类Json 带分页
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public class BaseJsonResult4Page<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public PageData<T> Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 跳转地址
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public string ExecutionTime { get; set; }
    }

    /// <summary>
    /// 分页数据,Rows为实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRow { get; set; }

        /// <summary>
        /// 数据行
        /// </summary>
        public List<T> Rows { get; set; }
    }
    #endregion
}