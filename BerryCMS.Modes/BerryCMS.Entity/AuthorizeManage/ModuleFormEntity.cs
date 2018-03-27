using System;
using Chloe.Entity;

namespace BerryCMS.Entity.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    [Table("Base_ModuleForm")]
    public class ModuleFormEntity : BaseEntity
    {
        /// <summary>
        /// 表单主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string FormId { get; set; }
        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 表单控件Json
        /// </summary>
        public string FormJson { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 删除标记
        /// 有效标志
        /// </summary>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
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
        public DateTime? ModifyDate { get; set; }
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