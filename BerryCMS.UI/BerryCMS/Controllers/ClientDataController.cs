using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BerryCMS.App.Cache;
using BerryCMS.BLL.AuthorizeManage;
using BerryCMS.Code;
using BerryCMS.Entity.AuthorizeManage;
using BerryCMS.Entity.BaseManage;
using BerryCMS.Entity.ViewModel;
using BerryCMS.Handler;
using BerryCMS.Utils;

namespace BerryCMS.Controllers
{
    /// <summary>
    /// 客户端基础数据
    /// </summary>
    public class ClientDataController : BaseController
    {
        private readonly ModuleBLL _moduleBll = new ModuleBLL();
        private readonly ModuleButtonBLL _moduleButtonBll = new ModuleButtonBLL();
        private readonly ModuleColumnBLL _moduleColumnBll = new ModuleColumnBLL();

        private readonly OrganizeCache _organizeCache = new OrganizeCache();
        private readonly DepartmentCache _departmentCache = new DepartmentCache();
        private readonly UserGroupCache _userGroupCache = new UserGroupCache();
        private readonly PostCache _postCache = new PostCache();
        private readonly RoleCache _roleCache = new RoleCache();
        private readonly UserCache _userCache = new UserCache();
        private readonly DataItemDetailCache _dataItemDetailCache = new DataItemDetailCache();

        #region 获取数据
        /// <summary>
        /// 批量加载数据给客户端（把常用数据全部加载到浏览器中 这样能够减少数据库交互）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetClientDataJson()
        {
            var jsonData = new
            {
                organize = this.GetOrganizeData(),              //公司
                department = this.GetDepartmentData(),          //部门
                post = this.GetPostData(),                      //岗位
                role = this.GetRoleData(),                      //角色
                userGroup = this.GetUserGroupData(),            //用户组
                user = this.GetUserData(),                      //用户
                dataItem = this.GetDataItem(),                  //字典
                authorizeMenu = this.GetModuleData(),           //导航菜单
                authorizeButton = this.GetModuleButtonData(),   //功能按钮
                authorizeColumn = this.GetModuleColumnData(),   //功能视图
            };
            return ToJsonResult(jsonData);
        }
        #endregion

        #region 处理基础数据
        /// <summary>
        /// 获取公司数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetOrganizeData()
        {
            var data = _organizeCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (OrganizeEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.OrganizeId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetDepartmentData()
        {
            var data = _departmentCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DepartmentEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName,
                    OrganizeId = item.OrganizeId
                };
                dictionary.Add(item.DepartmentId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取用户组数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetUserGroupData()
        {
            var data = _userGroupCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetPostData()
        {
            var data = _postCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetRoleData()
        {
            var data = _roleCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.RoleId, fieldItem);
            }
            return dictionary;
        }
        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetUserData()
        {
            var data = _userCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    Account = item.Account,
                    RealName = item.RealName,
                    OrganizeId = item.OrganizeId,
                    DepartmentId = item.DepartmentId
                };
                dictionary.Add(item.UserId, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetDataItem()
        {
            var dataList = _dataItemDetailCache.GetDataItemList().ToList();

            var dataSort = dataList.Distinct(new ComparintTools<DataItemViewModel>("EnCode"));
            Dictionary<string, object> dictionarySort = new Dictionary<string, object>();
            foreach (DataItemViewModel itemSort in dataSort)
            {
                var dataItemList = dataList.Where(t => t.EnCode.Equals(itemSort.EnCode)).ToList();
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();

                foreach (DataItemViewModel itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemValue, itemList.ItemName);
                }

                foreach (DataItemViewModel itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemDetailId, itemList.ItemName);
                }

                dictionarySort.Add(itemSort.EnCode, dictionaryItemList);
            }
            return dictionarySort;
        }
        #endregion

        #region 处理授权数据
        /// <summary>
        /// 获取功能数据
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ModuleEntity> GetModuleData()
        {
            return _moduleBll.GetModuleList(SystemInfo.CurrentUserId);
        }

        /// <summary>
        /// 获取功能按钮数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetModuleButtonData()
        {
            var data = _moduleButtonBll.GetModuleButtonList(SystemInfo.CurrentUserId).ToList();
            var dataModule = data.Distinct(new ComparintTools<ModuleButtonEntity>("ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (ModuleButtonEntity item in dataModule)
            {
                var buttonList = data.Where(t => t.ModuleId.Equals(item.ModuleId));
                dictionary.Add(item.ModuleId, buttonList);
            }

            return dictionary;
        }

        /// <summary>
        /// 获取功能视图数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetModuleColumnData()
        {
            var data = _moduleColumnBll.GetModuleColumnList(SystemInfo.CurrentUserId).ToList();
            var dataModule = data.Distinct(new ComparintTools<ModuleColumnEntity>("ModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (ModuleColumnEntity item in dataModule)
            {
                var columnList = data.Where(t => t.ModuleId.Equals(item.ModuleId));
                dictionary.Add(item.ModuleId, columnList);
            }
            return dictionary;
        }
        #endregion
    }
}