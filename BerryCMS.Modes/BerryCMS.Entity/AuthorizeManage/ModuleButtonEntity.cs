using Chloe.Entity;

namespace BerryCMS.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    [Table("Base_ModuleButton")]
    public class ModuleButtonEntity : BaseEntity
    {
        /// <summary>
        /// 按钮主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string ModuleButtonId { get; set; }
        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Action地址
        /// </summary>
        public string ActionAddress { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

    }
}