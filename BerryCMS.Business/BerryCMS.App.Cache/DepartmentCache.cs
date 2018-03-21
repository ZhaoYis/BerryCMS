using System;
using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.BaseManage;
using BerryCMS.Entity.BaseManage;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 部门缓存
    /// </summary>
    public class DepartmentCache
    {
        private readonly DepartmentBLL _departmentBll = new DepartmentBLL();

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetList()
        {
            List<DepartmentEntity> cacheList = CacheFactory.CacheFactory.GetCache().GetCache<List<DepartmentEntity>>(_departmentBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _departmentBll.GetDepartmentList().ToList();
                CacheFactory.CacheFactory.GetCache().WriteCache(cacheList, _departmentBll.CacheKey, DateTime.Now.AddHours(12));
            }

            return cacheList;
        }

        /// <summary>
        /// 组织列表
        /// </summary>
        /// <param name="organizeId">公司Id</param>
        /// <returns></returns>
        public DepartmentEntity GetEntity(string organizeId)
        {
            List<DepartmentEntity> data = this.GetList().ToList();
            if (!string.IsNullOrEmpty(organizeId))
            {
                DepartmentEntity organize = data.FirstOrDefault(t => t.OrganizeId == organizeId);

                return organize;
            }
            return default(DepartmentEntity);
        }
    }
}