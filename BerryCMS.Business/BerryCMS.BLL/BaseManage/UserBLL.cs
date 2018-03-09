using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BerryCMS.Code;
using BerryCMS.Entity.BaseManage;
using BerryCMS.IBLL.BaseManage;
using BerryCMS.Service.BaseManage;

namespace BerryCMS.BLL.BaseManage
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public partial class UserBLL : BaseBLL<UserEntity>, IUserBLL
    {
        private UserService userService = new UserService();

        protected override void SetDal()
        {
            Idal = DbSession.UserDal;
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity user)
        {
            return userService.AddUser(user);
        }

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        public void AddUser(List<UserEntity> users)
        {
            userService.AddUser(users);
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="password">密码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public UserEntity CheckLogin(string userAccount, string password, out JsonObjectStatus status)
        {
            return userService.CheckLogin(userAccount, password, out status);
        }

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public UserEntity QueryUserByUserId(string userId)
        {
            return userService.QueryUserByUserId(userId);
        }

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserEntity QueryUser(Expression<Func<UserEntity, bool>> query)
        {
            return userService.QueryUser(query);
        }

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query)
        {
            return userService.QueryUserList(query);
        }
    }
}