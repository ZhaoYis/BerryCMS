using System;
using Chloe.Entity;

namespace BerryCMS.Entity.BaseManage
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Table("Base_Role")]
    public class RoleEntity : BaseEntity
    {
        /// <summary>
        /// 角色主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string RoleId { get; set; }
        /// <summary>
        /// 机构主键
        /// </summary>
        public string OrganizeId { get; set; }
        /// <summary>
        /// 分类1-角色2-岗位3-职位4-工作组
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 公共角色
        /// </summary>
        public int IsPublic { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime OverdueTime { get; set; }
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