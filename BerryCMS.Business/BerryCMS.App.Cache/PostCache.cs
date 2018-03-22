using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 岗位缓存
    /// </summary>
    public class PostCache
    {
        private readonly PostBLL _postBll = new PostBLL();

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            List<RoleEntity> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<RoleEntity>>(_postBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _postBll.GetPostList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(cacheList, _postBll.CacheKey);
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