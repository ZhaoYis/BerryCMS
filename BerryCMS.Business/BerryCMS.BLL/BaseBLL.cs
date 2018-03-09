using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using BerryCMS.IBLL;
using BerryCMS.IDAL;
using BerryCMS.IOC;
using Chloe;

namespace BerryCMS.BLL
{
    /// <summary>
    /// BaseBLL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected IBaseDAL<T> Idal;
        /// <summary>
        /// 初始化数据上下文
        /// </summary>
        protected abstract void SetDal();
        /// <summary>
        /// 构造
        /// </summary>
        protected BaseBLL()
        {
            SetDal();
        }

        #region 初始化仓储对象
        private IDBSession _iDbSession;
        /// <summary>
        /// 初始化仓储对象
        /// </summary>
        protected IDBSession DbSession
        {
            get
            {
                if (_iDbSession == null)
                {
                    IDBSessionFactory dbSessionFactory = SpringHelper.GetObject<IDBSessionFactory>("DBSessionFactory");
                    _iDbSession = dbSessionFactory.GetDbSession();
                }
                return _iDbSession;
            }
        }

        #endregion

        #region 执行T-SQL语句或者存储过程
        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            return Idal.ExecuteBySql(strSql);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, params DbParam[] DbParam)
        {
            return Idal.ExecuteBySql(strSql, DbParam);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            return Idal.ExecuteByProc(procName);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, DbParam[] DbParam)
        {
            return Idal.ExecuteByProc(procName, DbParam);
        }
        #endregion

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns>自增主键</returns>
        public bool Insert(T entity)
        {
            return Idal.Insert(entity);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        public void Insert(IEnumerable<T> entity)
        {
            Idal.Insert(entity);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public int Delete(T entity)
        {
            return Idal.Delete(entity);
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> condition)
        {
            return Idal.Delete(condition);
        }

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int Delete(object keyValue)
        {
            return Idal.Delete(keyValue);
        }

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        public int Delete(object[] keyValue)
        {
            return Idal.Delete(keyValue);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public int Update(T entity)
        {
            return Idal.Update(entity);
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        public int Update(IEnumerable<T> entity)
        {
            return Idal.Update(entity);
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Update(Expression<Func<T, bool>> condition)
        {
            return Idal.Update(condition);
        }

        /// <summary>
        /// 根据条件更新指定字段
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update(T modelModifyProps, Expression<Func<T, bool>> condition)
        {
            return Idal.Update(modelModifyProps, condition);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T FindEntity(object keyValue)
        {
            return Idal.FindEntity(keyValue);
        }

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity(Expression<Func<T, bool>> condition)
        {
            return Idal.FindEntity(condition);
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        public IQuery<T> IQueryable()
        {
            return Idal.IQueryable();
        }

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQuery<T> IQueryable(Expression<Func<T, bool>> condition)
        {
            return Idal.IQueryable(condition);
        }

        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(Expression<Func<T, object>> orderby)
        {
            return Idal.FindList(orderby);
        }

        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(Expression<Func<T, bool>> condition)
        {
            return Idal.FindList(condition);
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(string strSql)
        {
            return Idal.FindList(strSql);
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(string strSql, DbParam[] DbParam)
        {
            return Idal.FindList(strSql, DbParam);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql)
        {
            return Idal.FindTable(strSql);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParam[] DbParam)
        {
            return Idal.FindTable(strSql, DbParam);
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderby">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList(Expression<Func<T, object>> orderby, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            return Idal.FindPageList(orderby, isAsc, pageSize, pageIndex, out total);
        }
        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList(Expression<Func<T, bool>> condition, Expression<Func<T, object>> orderby, bool isAsc, int pageSize, int pageIndex,
            out int total)
        {
            return Idal.FindPageList(condition, orderby, isAsc, pageSize, pageIndex, out total);
        }
        /// <summary>
        /// 根据T-SQL获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList(string strSql, int pageSize, int pageIndex, out int total)
        {
            return Idal.FindPageList(strSql, pageSize, pageIndex, out total);
        }
        /// <summary>
        /// 根据T-SQL获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList(string strSql, DbParam[] DbParam, int pageSize, int pageIndex, out int total)
        {
            return Idal.FindPageList(strSql, DbParam, pageSize, pageIndex, out total);
        } 
        #endregion
    }
}