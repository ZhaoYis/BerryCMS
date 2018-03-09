using System;
using Chloe.Entity;

namespace BerryCMS.Entity.SystemManage
{
    /// <summary>
    /// 字典
    /// </summary>
    [Table("Base_DataItem")]
    public class DataItemEntity : BaseEntity
    {
        /// <summary>
        /// 分类主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string ItemId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 树型结构
        /// </summary>
        public int IsTree { get; set; }
        /// <summary>
        /// 导航标记
        /// </summary>
        public int IsNav { get; set; }
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