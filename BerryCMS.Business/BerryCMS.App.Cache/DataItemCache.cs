using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.SystemManage;
using BerryCMS.Entity.SystemManage;
using BerryCMS.Entity.ViewModel;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 数据字典分类缓存
    /// </summary>
    public class DataItemCache
    {
        private readonly DataItemBLL _dataItemBll = new DataItemBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            List<DataItemEntity> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<DataItemEntity>>(_dataItemBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _dataItemBll.GetDataItemList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(cacheList, _dataItemBll.CacheKey);
            }

            return cacheList;
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="itemCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList(string itemCode)
        {
            return this.GetDataItemList().Where(t => t.ItemCode == itemCode);
        }
        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="itemCode">分类代码</param>
        /// <param name="itemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string itemCode, string itemValue)
        {
            var data = this.GetDataItemList().Where(t => t.ItemCode == itemCode);
            return data.First(t => t.ItemName == itemValue).ItemName;
        }
    }
}