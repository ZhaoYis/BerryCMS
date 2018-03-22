using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using BerryCMS.Entity;
using Chloe;

namespace BerryCMS.IDAL
{
    /// <summary>
    /// 操作数据库基础接口
    /// </summary>
    public interface IBaseDAL<T> where T : class, new()
    {
        #region 执行T-SQL语句或者存储过程
        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql);
        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, params DbParam[] DbParam);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        int ExecuteByProc(string procName);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        int ExecuteByProc(string procName, DbParam[] DbParam);
        #endregion

        #region 新增
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns>自增主键</returns>
        bool Insert(T entity);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        void Insert(IEnumerable<T> entity);
        #endregion

        #region 删除
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> condition);
        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        int Delete(object keyValue);
        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        int Delete(object[] keyValue);
        #endregion

        #region 更新

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        int Update(IEnumerable<T> entity);
        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        int Update(Expression<Func<T, bool>> condition);
        /// <summary>
        /// 根据条件更新指定字段
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        int Update(T modelModifyProps, Expression<Func<T, bool>> condition);
        #endregion

        #region 查询
        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        T FindEntity(object keyValue);
        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T FindEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        IQuery<T> IQueryable();
        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQuery<T> IQueryable(Expression<Func<T, bool>> condition);
        
        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <param name="orderby">排序条件</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, object>> orderby);
        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition);
        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql);
        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, DbParam[] DbParam);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        DataTable FindTable(string strSql);
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="DbParam">DbCommand参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, DbParam[] DbParam);
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
        IEnumerable<T> FindPageList(Expression<Func<T, bool>> orderby, bool isAsc, int pageSize, int pageIndex, out int total);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderby">排序条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindPageList(Expression<Func<T, bool>> orderby, PaginationEntity pagination);

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
        IEnumerable<T> FindPageList(Expression<Func<T, bool>> condition, Expression<Func<T, object>> orderby, bool isAsc, int pageSize, int pageIndex, out int total);
        /// <summary>
        /// 根据T-SQL获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        IEnumerable<T> FindPageList(string strSql, int pageSize, int pageIndex, out int total);
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
        IEnumerable<T> FindPageList(string strSql, DbParam[] DbParam, int pageSize, int pageIndex, out int total);


        #endregion
    }
}