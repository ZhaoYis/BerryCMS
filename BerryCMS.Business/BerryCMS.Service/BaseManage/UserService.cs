using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BerryCMS.Code;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Extension;
using BerryCMS.IService.BaseManage;
using BerryCMS.Service.Base;
using BerryCMS.Utils;

namespace BerryCMS.Service.BaseManage
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity user)
        {
            bool res = o.BllSession.UserBll.Insert(user);
            return res;
        }

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        public void AddUser(List<UserEntity> users)
        {
            o.BllSession.UserBll.Insert(users);
        }

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query)
        {
            List<UserEntity> res = o.BllSession.UserBll.FindList(query).ToList();
            return res;
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
            if (!string.IsNullOrEmpty(userAccount) && !string.IsNullOrEmpty(password))
            {
                //根据用户账号得到用户信息
                UserEntity user = o.BllSession.UserBll.FindEntity(u => u.Account.Equals(userAccount));
                if (user != null)
                {
                    if (user.EnabledMark)
                    {
                        string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(password, user.Secretkey));
                        if (realPassword.Equals(user.Password))
                        {
                            DateTime lastVisit = DateTime.Now;
                            int logOnCount = (user.LogOnCount).TryToInt32() + 1;

                            if (user.LastVisit != null)
                            {
                                user.PreviousVisit = user.LastVisit.TryToDateTime();
                            }

                            user.LastVisit = lastVisit;
                            user.LogOnCount = logOnCount;
                            user.UserOnLine = 1;
                            //更新登录信息
                            int isSucc = o.BllSession.UserBll.Update(user);

                            status = JsonObjectStatus.Success;
                            return user;
                        }
                        else
                        {
                            status = JsonObjectStatus.PasswordErr;
                            return user;
                        }
                    }
                    else
                    {
                        status = JsonObjectStatus.AccountNotEnabled;
                        return user;
                    }
                }
                else
                {
                    status = JsonObjectStatus.UserNotExist;
                    return null;
                }
            }

            status = JsonObjectStatus.UserNotExist;
            return null;
        }

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public UserEntity QueryUserByUserId(string userId)
        {
            UserEntity res = o.BllSession.UserBll.FindEntity(u => u.UserId.Equals(userId));
            return res;
        }

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserEntity QueryUser(Expression<Func<UserEntity, bool>> query)
        {
            UserEntity res = o.BllSession.UserBll.FindEntity(query);
            return res;
        }
    }
}