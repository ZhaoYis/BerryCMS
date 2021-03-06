﻿using Chloe.Entity;

namespace BerryCMS.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    [Table("Base_ModuleFormInstance")]
    public class ModuleFormInstanceEntity : BaseEntity
    {
        /// <summary>
        /// 表单实例主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string FormInstanceId { get; set; }
        /// <summary>
        /// 表单主键
        /// </summary>
        public string FormId { get; set; }
        /// <summary>
        /// 表单实例Json
        /// </summary>
        public string FormInstanceJson { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

    }
}