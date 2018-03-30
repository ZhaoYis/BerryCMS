using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BerryCMS.BLL.SystemManage;
using BerryCMS.Code;
using BerryCMS.Entity.SystemManage;
using BerryCMS.Extension;
using BerryCMS.Handler;
using BerryCMS.WebControl;
using BerryCMS.WebControl.GridTree;
using BerryCMS.WebControl.Tree;

namespace BerryCMS.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemController : BaseController
    {
        private readonly DataItemBLL _dataItemBll = new DataItemBLL();

        #region 视图功能
        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分类表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 分类列表 
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTreeJson(string keyword)
        {
            var data = _dataItemBll.GetDataItemList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.ItemName.Contains(keyword), "");
            }
            var treeList = new List<TreeEntity>();
            foreach (DataItemEntity item in data)
            {
                bool hasChildren = data.Count(t => t.ParentId == item.ItemId) != 0;
                TreeEntity tree = new TreeEntity
                {
                    Id = item.ItemId,
                    Text = item.ItemName,
                    Value = item.ItemCode,
                    ParentId = item.ParentId,
                    Isexpand = true,
                    Complete = true,
                    Attribute = "isTree",
                    AttributeValue = item.IsTree.ToString(),
                    HasChildren = hasChildren
                };
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回树形列表Json</returns>
        [HttpGet]
        public ActionResult GetTreeListJson(string keyword)
        {
            var data = _dataItemBll.GetDataItemList().ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.ItemName.Contains(keyword), "");
            }

            var treeList = new List<TreeGridEntity>();
            foreach (DataItemEntity item in data)
            {
                bool hasChildren = data.Count(t => t.ParentId == item.ItemId) != 0;
                TreeGridEntity tree = new TreeGridEntity
                {
                    Id = item.ItemId,
                    ParentId = item.ParentId,
                    Expanded = true,
                    HasChildren = hasChildren,
                    EntityJson = item.TryToJson()
                };
                treeList.Add(tree);
            }
            return Content(treeList.TreeJson());
        }
        /// <summary>
        /// 分类实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = _dataItemBll.GetEntityByKey(keyValue);
            return Content(data.TryToJson());
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemCode(string itemCode, string keyValue)
        {
            bool isOk = _dataItemBll.ExistItemCode(itemCode, keyValue);
            return Content(isOk.ToString());
        }
        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistItemName(string itemName, string keyValue)
        {
            bool isOk = _dataItemBll.ExistItemName(itemName, keyValue);
            return Content(isOk.ToString());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            _dataItemBll.RemoveDataItemByKey(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DataItemEntity dataItemEntity)
        {
            _dataItemBll.SaveDataItem(keyValue, dataItemEntity);
            return Success("操作成功。");
        }
        #endregion
    }
}