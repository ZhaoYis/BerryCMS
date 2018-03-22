using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 用户组缓存
    /// </summary>
    public class UserGroupCache
    {
        private readonly UserGroupBLL _userGroupBll = new UserGroupBLL();

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            List<RoleEntity> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<RoleEntity>>(_userGroupBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _userGroupBll.GetUserGroupList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(cacheList, _userGroupBll.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList(string organizeId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                data = data.Where(t => t.OrganizeId == organizeId);
            }
            return data;
        }
    }
}