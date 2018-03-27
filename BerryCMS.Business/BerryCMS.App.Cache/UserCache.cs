using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 用户信息缓存
    /// </summary>
    public class UserCache
    {
        private readonly UserBLL _userBll = new UserBLL();

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetList()
        {
            List<UserEntity> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<UserEntity>>(_userBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _userBll.GetUserList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(cacheList, _userBll.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetList(string departmentId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(departmentId))
            {
                data = data.Where(t => t.DepartmentId == departmentId);
            }
            return data;
        }
    }
}