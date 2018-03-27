using System.Collections.Generic;
using System.Linq;
using BerryCMS.Entity.SystemManage;
using BerryCMS.Extension;
using BerryCMS.IService.SystemManage;
using BerryCMS.Service.Base;

namespace BerryCMS.Service.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemService : BaseService, IDataItemService
    {
        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            IEnumerable<DataItemEntity> res = o.BllSession.DataItemBll
                .FindList(d => d.DeleteMark == false && d.EnabledMark == true).OrderByDescending(d => d.CreateDate).ToList();

            return res;
        }

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByKey(string keyValue)
        {
            DataItemEntity res = o.BllSession.DataItemBll.FindEntity(keyValue);

            return res;
        }

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string itemCode)
        {
            var expression = LambdaExtension.True<DataItemEntity>();
            if (!string.IsNullOrEmpty(itemCode))
            {
                expression = expression.And(t => t.ItemCode == itemCode);
            }

            expression = expression.And(d => d.DeleteMark == false && d.EnabledMark == true);

            DataItemEntity res = o.BllSession.DataItemBll.FindEntity(expression);

            return res;
        }

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemCode(string itemCode, string keyValue)
        {
            var expression = LambdaExtension.True<DataItemEntity>();
            expression = expression.And(t => t.ItemCode == itemCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ItemId != keyValue);
            }

            bool isExit = o.BllSession.DataItemBll.IQueryable(expression).Any();

            return isExit;
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            var expression = LambdaExtension.True<DataItemEntity>();
            expression = expression.And(t => t.ItemName == itemName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ItemId != keyValue);
            }

            bool isExit = o.BllSession.DataItemBll.IQueryable(expression).Any();

            return isExit;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemByKey(string keyValue)
        {
            o.BllSession.DataItemBll.Delete(keyValue);
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveDataItem(string keyValue, DataItemEntity dataItemEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                dataItemEntity.Modify(keyValue);
                o.BllSession.DataItemBll.Update(dataItemEntity);
            }
            else
            {
                dataItemEntity.Create();
                o.BllSession.DataItemBll.Insert(dataItemEntity);
            }
        }
    }
}