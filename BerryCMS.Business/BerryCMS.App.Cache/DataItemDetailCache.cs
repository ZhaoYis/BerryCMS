using System.Collections.Generic;
using System.Linq;
using BerryCMS.BLL.SystemManage;
using BerryCMS.Entity.ViewModel;

namespace BerryCMS.App.Cache
{
    /// <summary>
    /// 数据字典明细缓存
    /// </summary>
    public class DataItemDetailCache
    {
        private readonly DataItemDetailBLL _dataItemDetailBll = new DataItemDetailBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            List<DataItemViewModel> cacheList = CacheFactory.CacheFactory.GetCacheInstance().GetCache<List<DataItemViewModel>>(_dataItemDetailBll.CacheKey);
            if (cacheList == null)
            {
                cacheList = _dataItemDetailBll.GetDataItemList().ToList();
                CacheFactory.CacheFactory.GetCacheInstance().WriteCache(_dataItemDetailBll, _dataItemDetailBll.CacheKey);
            }
            return cacheList;
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="enCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList(string enCode)
        {
            return this.GetDataItemList().Where(t => t.EnCode == enCode);
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="enCode">分类代码</param>
        /// <param name="itemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetSubDataItemList(string enCode, string itemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == enCode).ToList();
            string itemDetailId = data.First(t => t.ItemValue == itemValue).ItemDetailId;

            IEnumerable<DataItemViewModel> res = data.Where(t => t.ParentId == itemDetailId);

            return res;
        }
        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="enCode">分类代码</param>
        /// <param name="itemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string enCode, string itemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == enCode);

            string res = data.First(t => t.ItemValue == itemValue).ItemName ?? "";

            return res;
        }
    }
}