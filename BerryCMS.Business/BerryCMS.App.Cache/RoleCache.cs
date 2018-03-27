using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 角色缓存
    /// </summary>
    public class RoleCache
    {
        private readonly RoleBLL _roleBll = new RoleBLL();

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            List<RoleEntity> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<RoleEntity>>(_roleBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _roleBll.GetRoleList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(cacheList, _roleBll.CacheKey);
            }
            return cacheList;
        }

        /// <summary>
        /// 角色列表
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

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleEntity GetEntity(string roleId)
        {
            var data = this.GetList();
            if (!string.IsNullOrEmpty(roleId))
            {
                RoleEntity d = data.FirstOrDefault(t => t.RoleId == roleId);

                return d;
            }
            return default(RoleEntity);
        }
    }
}