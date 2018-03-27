using System;
using BerryCMS.Code.Operator;
using BerryCMS.Utils;
using Chloe.Entity;

namespace BerryCMS.Entity.BaseManage
{
    /// <summary>
    /// 用户关系
    /// </summary>
    [Table("Base_UserRelation")]
    public class UserRelationEntity : BaseEntity
    {
        #region 扩展操作
        public override void Create()
        {
            this.UserRelationId = CommonHelper.GetGuid();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.IsDefault = false;
        }
        #endregion

        /// <summary>
        /// 用户关系主键
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public string UserRelationId { get; set; }
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 分类:1-部门 2-角色 3-岗位 4-职位 5-工作组
        /// </summary>
        public int? Category { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }
        /// <summary>
        /// 默认对象
        /// </summary>
        public bool? IsDefault { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// 创建时间
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

    }
}