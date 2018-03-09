using System;
using Chloe.Entity;

namespace BerryCMS.Entity.SystemManage
{
    /// <summary>
    /// 字典详细
    /// </summary>
    [Table("Base_DataItemDetail")]
    public class DataItemDetailEntity : BaseEntity
    {
        /// <summary>
        /// 明细主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string ItemDetailId { get; set; }
        /// <summary>
        /// 分类主键
        /// </summary>
        public string ItemId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string ItemValue { get; set; }
        /// <summary>
        /// 快速查询
        /// </summary>
        public string QuickQuery { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool DeleteMark { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifyUserName { get; set; }

    }
}