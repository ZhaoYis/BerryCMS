using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using BerryCMS.Entity;
using BerryCMS.Extension;
using BerryCMS.IDAL;
using Chloe;

namespace BerryCMS.MsSQL
{
    /// <summary>
    /// 基类DAL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDAL<T> : IBaseDAL<T> where T : class, new()
    {
        private readonly IDbContext _context = new DBContextFactory().GetDbContext();

        #region 执行T-SQL语句或者存储过程
        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            int res = _context.Session.ExecuteNonQuery(strSql, CommandType.Text);
            return res;
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, params DbParam[] DbParam)
        {
            int res = _context.Session.ExecuteNonQuery(strSql, DbParam);

            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            int res = _context.Session.ExecuteNonQuery(procName, CommandType.StoredProcedure);

            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, DbParam[] DbParam)
        {
            int res = _context.Session.ExecuteNonQuery(procName, CommandType.StoredProcedure, DbParam);

            return res;
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
            T o = (T)_context.Insert(entity);

            return o != null;
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        public void Insert(IEnumerable<T> entity)
        {
            _context.InsertRange(entity.ToList());
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
            int res = _context.Delete(entity);
            return res;
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> condition)
        {
            int res = _context.Delete(condition);
            return res;
        }

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int Delete(object keyValue)
        {
            int res = _context.DeleteByKey<object>(keyValue);
            return res;
        }

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        public int Delete(object[] keyValue)
        {
            int res = 0;
            foreach (object o in keyValue)
            {
                res = _context.DeleteByKey<object>(o);
            }
            return res;
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
            int res = _context.Update(entity);
            return res;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        public int Update(IEnumerable<T> entity)
        {
            int res = 0;
            foreach (T t in entity)
            {
                res = _context.Update(t);
            }
            return res;
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Update(Expression<Func<T, bool>> condition)
        {
            int res = _context.Update(condition);
            return res;
        }

        /// <summary>
        /// 根据条件更新指定字段
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update(T modelModifyProps, Expression<Func<T, bool>> condition)
        {
            int res = _context.Update(condition, m => modelModifyProps);
            return res;
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
            T res = _context.QueryByKey<T>(keyValue);
            return res;
        }

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity(Expression<Func<T, bool>> condition)
        {
            T res = _context.Query<T>().Where(condition).FirstOrDefault();
            return res;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        public IQuery<T> IQueryable()
        {
            IQuery<T> res = _context.Query<T>();
            return res;
        }

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQuery<T> IQueryable(Expression<Func<T, bool>> condition)
        {
            IQuery<T> res = _context.Query<T>().Where(condition);
            return res;
        }

        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(Expression<Func<T, object>> orderby)
        {
            IEnumerable<T> res = _context.Query<T>().OrderBy(orderby).ToList();
            return res;
        }

        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> res = _context.Query<T>().Where(condition).ToList();
            return res;
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(string strSql)
        {
            IEnumerable<T> res = _context.SqlQuery<T>(strSql);
            return res;
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(string strSql, DbParam[] DbParam)
        {
            IEnumerable<T> res = _context.SqlQuery<T>(strSql, DbParam);
            return res;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, CommandType type)
        {
            DataTable res = _context.Session.ExecuteReader(strSql, type).IDataReaderToDataTable();
            //SqlQuery<T>(strSql).ToList().ListToDataTable();
            //_context.Session.ExecuteReader(strSql, type).IDataReaderToDataTable();
            return res;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="type">CommandType</param>
        /// <param name="dbParam">DbCommand参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, CommandType type, DbParam[] dbParam)
        {
            DataTable res = _context.Session.ExecuteReader(strSql, type, dbParam).IDataReaderToDataTable();
            //.SqlQuery<T>(strSql, dbParam).ToList().ListToDataTable();
            return res;
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
        public IEnumerable<T> FindPageList(Expression<Func<T, bool>> orderby, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            IEnumerable<T> res;

            IQuery<T> query = _context.Query<T>();
            if (isAsc)
            {
                res = query.OrderBy(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            else
            {
                res = query.OrderByDesc(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            total = query.Count();

            return res;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderby">排序条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindPageList(Expression<Func<T, bool>> orderby, PaginationEntity pagination)
        {
            if (pagination == null)
            {
                pagination = new PaginationEntity
                {
                    PageSize = 20,
                    PageIndex = 1
                };
            }

            bool isAsc = pagination.Sord.ToLower().Equals("asc");
            int pageSize = pagination.PageSize;
            int pageIndex = pagination.PageIndex;

            IEnumerable<T> res;

            IQuery<T> query = _context.Query<T>();
            if (isAsc)
            {
                res = query.OrderBy(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            else
            {
                res = query.OrderByDesc(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            int total = query.Count();
            pagination.TotalRecords = total;

            return res;
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
        public IEnumerable<T> FindPageList(Expression<Func<T, bool>> condition, Expression<Func<T, object>> orderby, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            IEnumerable<T> res;

            IQuery<T> query = _context.Query<T>().Where(condition);
            if (isAsc)
            {
                res = query.OrderBy(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            else
            {
                res = query.OrderByDesc(orderby).TakePage(pageIndex, pageSize).ToList();
            }
            total = query.Count();

            return res;
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
            IEnumerable<T> query = _context.SqlQuery<T>(strSql).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            total = query.Count();

            return query;
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
        public IEnumerable<T> FindPageList(string strSql, DbParam[] DbParam, int pageSize,
            int pageIndex, out int total)
        {
            IEnumerable<T> query = _context.SqlQuery<T>(strSql, DbParam).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            total = query.Count();

            return query;
        }

        #endregion
    }
}