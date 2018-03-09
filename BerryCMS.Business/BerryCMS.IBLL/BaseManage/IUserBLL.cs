using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BerryCMS.Code;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.IBLL.BaseManage
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public partial interface IUserBLL : IBaseBLL<UserEntity>
    {
        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        bool AddUser(UserEntity user);

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        void AddUser(List<UserEntity> users);

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="password">密码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        UserEntity CheckLogin(string userAccount, string password, out JsonObjectStatus status);

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        UserEntity QueryUserByUserId(string userId);

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        UserEntity QueryUser(Expression<Func<UserEntity, bool>> query);

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query);
    }
}