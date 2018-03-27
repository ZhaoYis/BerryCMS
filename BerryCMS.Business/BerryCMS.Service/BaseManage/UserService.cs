using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using BerryCMS.Code;
using BerryCMS.Code.Operator;
using BerryCMS.Entity;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Extension;
using BerryCMS.IService.BaseManage;
using BerryCMS.Service.Base;
using BerryCMS.Utils;
using Newtonsoft.Json.Linq;

namespace BerryCMS.Service.BaseManage
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            var expression = LambdaExtension.True<UserEntity>();
            expression = expression.And(t => t.Account == account).And(t => t.DeleteMark == false && t.EnabledMark == true);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.UserId != keyValue);
            }
            bool hasExist = o.BllSession.UserBll.IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity userEntity)
        {
            bool res = o.BllSession.UserBll.Insert(userEntity);

            if (res)
            {
                #region 添加角色、岗位、职位信息
                //删除历史用户角色关系
                o.BllSession.UserRelationBll.Delete(u => u.IsDefault == true && u.UserId.Equals(userEntity.UserId));
                //用户关系
                List<UserRelationEntity> userRelation = new List<UserRelationEntity>();
                //角色
                if (!string.IsNullOrEmpty(userEntity.RoleId))
                {
                    userRelation.Add(new UserRelationEntity
                    {
                        Category = 2,
                        UserRelationId = CommonHelper.GetGuid(),
                        UserId = userEntity.UserId,
                        ObjectId = userEntity.RoleId,
                        CreateDate = DateTime.Now,
                        CreateUserId = OperatorProvider.Provider.Current().UserId,
                        CreateUserName = OperatorProvider.Provider.Current().UserName,
                        IsDefault = true
                    });
                }
                //岗位
                if (!string.IsNullOrEmpty(userEntity.DutyId))
                {
                    userRelation.Add(new UserRelationEntity
                    {
                        Category = 3,
                        UserRelationId = CommonHelper.GetGuid(),
                        UserId = userEntity.UserId,
                        ObjectId = userEntity.DutyId,
                        CreateDate = DateTime.Now,
                        CreateUserId = OperatorProvider.Provider.Current().UserId,
                        CreateUserName = OperatorProvider.Provider.Current().UserName,
                        IsDefault = true
                    });
                }
                //职位
                if (!string.IsNullOrEmpty(userEntity.PostId))
                {
                    userRelation.Add(new UserRelationEntity
                    {
                        Category = 3,
                        UserRelationId = CommonHelper.GetGuid(),
                        UserId = userEntity.UserId,
                        ObjectId = userEntity.PostId,
                        CreateDate = DateTime.Now,
                        CreateUserId = OperatorProvider.Provider.Current().UserId,
                        CreateUserName = OperatorProvider.Provider.Current().UserName,
                        IsDefault = true
                    });
                }
                //保持用户角色关系
                o.BllSession.UserRelationBll.Insert(userRelation);

                #endregion
            }

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
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public bool AddUser(string keyValue, UserEntity userEntity)
        {
            bool isSucc = false;
            if (!string.IsNullOrEmpty(keyValue))
            {
                //更新操作
                userEntity.Modify(keyValue);
                int res = o.BllSession.UserBll.Update(userEntity);
                isSucc = res > 0;
            }
            else
            {
                //新增操作
                userEntity.Create();
                bool res = o.BllSession.UserBll.Insert(userEntity);
                isSucc = res;
            }

            #region 添加角色、岗位、职位信息
            //删除历史用户角色关系
            o.BllSession.UserRelationBll.Delete(u => u.IsDefault == true && u.UserId.Equals(userEntity.UserId));
            //用户关系
            List<UserRelationEntity> userRelation = new List<UserRelationEntity>();
            //角色
            if (!string.IsNullOrEmpty(userEntity.RoleId))
            {
                userRelation.Add(new UserRelationEntity
                {
                    Category = 2,
                    UserRelationId = CommonHelper.GetGuid(),
                    UserId = userEntity.UserId,
                    ObjectId = userEntity.RoleId,
                    CreateDate = DateTime.Now,
                    CreateUserId = OperatorProvider.Provider.Current().UserId,
                    CreateUserName = OperatorProvider.Provider.Current().UserName,
                    IsDefault = true
                });
            }
            //岗位
            if (!string.IsNullOrEmpty(userEntity.DutyId))
            {
                userRelation.Add(new UserRelationEntity
                {
                    Category = 3,
                    UserRelationId = CommonHelper.GetGuid(),
                    UserId = userEntity.UserId,
                    ObjectId = userEntity.DutyId,
                    CreateDate = DateTime.Now,
                    CreateUserId = OperatorProvider.Provider.Current().UserId,
                    CreateUserName = OperatorProvider.Provider.Current().UserName,
                    IsDefault = true
                });
            }
            //职位
            if (!string.IsNullOrEmpty(userEntity.PostId))
            {
                userRelation.Add(new UserRelationEntity
                {
                    Category = 3,
                    UserRelationId = CommonHelper.GetGuid(),
                    UserId = userEntity.UserId,
                    ObjectId = userEntity.PostId,
                    CreateDate = DateTime.Now,
                    CreateUserId = OperatorProvider.Provider.Current().UserId,
                    CreateUserName = OperatorProvider.Provider.Current().UserName,
                    IsDefault = true
                });
            }
            //保持用户角色关系
            o.BllSession.UserRelationBll.Insert(userRelation);

            #endregion

            return isSucc;
        }

        /// <summary>
        /// 删除用户，逻辑删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserByKey(string keyValue)
        {
            o.BllSession.UserBll.Update(u => u.DeleteMark == true && u.EnabledMark == false);
        }

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        /// <param name="secretkey">密钥</param>
        public void RevisePassword(string keyValue, string password, string secretkey)
        {
            UserEntity user = new UserEntity
            {
                UserId = keyValue,
                Password = password,
                Secretkey = secretkey
            };

            o.BllSession.UserBll.Update(user);
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动 0-禁用</param>
        public void UpdateUserState(string keyValue, int state)
        {
            UserEntity user = new UserEntity
            {
                UserId = keyValue,
                EnabledMark = state == 1
            };

            o.BllSession.UserBll.Update(user);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateUserInfo(UserEntity userEntity)
        {
            o.BllSession.UserBll.Update(userEntity);
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
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<UserEntity>();
            JObject queryParam = queryJson.ToJObject();
            if (queryParam != null)
            {
                //公司主键
                if (!string.IsNullOrEmpty(queryParam["organizeId"].ToString()))
                {
                    string organizeId = queryParam["organizeId"].ToString();
                    expression = expression.And(t => t.OrganizeId.Equals(organizeId));
                }
                //部门主键
                if (!string.IsNullOrEmpty(queryParam["departmentId"].ToString()))
                {
                    string departmentId = queryParam["departmentId"].ToString();
                    expression = expression.And(t => t.DepartmentId.Equals(departmentId));
                }
                //查询条件
                if (!string.IsNullOrEmpty(queryParam["condition"].ToString()) && !string.IsNullOrEmpty(queryParam["keyword"].ToString()))
                {
                    string condition = queryParam["condition"].ToString();
                    string keyord = queryParam["keyword"].ToString();
                    switch (condition)
                    {
                        case "Account"://账户
                            expression = expression.And(t => t.Account.Contains(keyord));
                            break;
                        case "RealName"://姓名
                            expression = expression.And(t => t.RealName.Contains(keyord));
                            break;
                        case "Mobile"://手机
                            expression = expression.And(t => t.Mobile.Contains(keyord));
                            break;
                    }
                }
            }
            IEnumerable<UserEntity> res = o.BllSession.UserBll.FindPageList(expression, pagination);

            return res;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.*,
                                    d.FullName AS DepartmentName 
                            FROM    Base_User u
                                    LEFT JOIN Base_Department d ON d.DepartmentId = u.DepartmentId
                            WHERE   1 = 1");
            strSql.Append(" AND u.UserId <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark = 0");

            DataTable data = o.BllSession.UserBll.FindTable(strSql.ToString());

            return data;
        }

        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.UserId ,
                                    u.EnCode ,
                                    u.Account ,
                                    u.RealName ,
                                    u.Gender ,
                                    u.Birthday ,
                                    u.Mobile ,
                                    u.Manager ,
                                    u.OrganizeId,
                                    u.DepartmentId,
                                    o.FullName AS OrganizeName ,
                                    d.FullName AS DepartmentName ,
                                    u.RoleId ,
                                    u.DutyName ,
                                    u.PostName ,
                                    u.EnabledMark ,
                                    u.CreateDate,
                                    u.Description
                            FROM    Base_User u
                                    LEFT JOIN Base_Organize o ON o.OrganizeId = u.OrganizeId
                                    LEFT JOIN Base_Department d ON d.DepartmentId = u.DepartmentId
                            WHERE   1 = 1");
            strSql.Append(" AND u.UserId <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark = 0 order by o.FullName,d.FullName,u.RealName");

            DataTable data = o.BllSession.UserBll.FindTable(strSql.ToString());

            return data;
        }

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT u.[Account]
                                  ,u.[RealName]
                                  ,CASE WHEN Gender = 1 THEN '男' ELSE '女' END AS Gender
                                  ,u.[Birthday]
                                  ,u.[Mobile]
                                  ,u.[Telephone]
                                  ,u.[Email]
                                  ,u.[WeChat]
                                  ,u.[MSN]
                                  ,u.[Manager]
                                  ,o.FullName AS Organize
                                  ,d.FullName AS Department
                                  ,u.[Description]
                                  ,u.[CreateDate]
                                  ,u.[CreateUserName]
                              FROM Base_User u
                              INNER JOIN Base_Department d ON u.DepartmentId = d.DepartmentId
                              INNER JOIN Base_Organize o ON u.OrganizeId = o.OrganizeId");

            DataTable data = o.BllSession.UserBll.FindTable(strSql.ToString());

            return data;
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
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserList()
        {
            var expression = LambdaExtension.True<UserEntity>();
            expression = expression.And(t => t.UserId != "System").And(t => t.EnabledMark == true).And(t => t.DeleteMark == false);

            IEnumerable<UserEntity> res = o.BllSession.UserBll.IQueryable(expression).OrderByDesc(u => u.CreateDate).ToList();

            return res;
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