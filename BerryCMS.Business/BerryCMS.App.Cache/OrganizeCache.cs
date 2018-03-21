using System;
using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 组织架构缓存数据
    /// </summary>
    public class OrganizeCache
    {
        private readonly OrganizeBLL _organizeBll = new OrganizeBLL();

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetList()
        {
            List<OrganizeEntity> cacheList = CacheFactory.CacheFactory.GetCache().GetCache<List<OrganizeEntity>>(_organizeBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _organizeBll.GetOrganizeList().ToList();
                CacheFactory.CacheFactory.GetCache().WriteCache(cacheList, _organizeBll.CacheKey, DateTime.Now.AddHours(12));
            }

            return cacheList;
        }

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public OrganizeEntity GetEntity(string organizeId)
        {
            List<OrganizeEntity> data = this.GetList().ToList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                OrganizeEntity organize = data.FirstOrDefault(t => t.OrganizeId == organizeId);

                return organize;
            }
            return default(OrganizeEntity);
        }
    }
}