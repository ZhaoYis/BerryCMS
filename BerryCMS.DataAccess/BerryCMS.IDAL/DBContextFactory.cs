using System;
using BerryCMS.Code;
using BerryCMS.Utils;
using Chloe;
using Chloe.Infrastructure.Interception;
using Chloe.MySql;
using Chloe.SqlServer;

namespace BerryCMS.IDAL
{
    public class DBContextFactory : IDBContextFactory
    {
        /// <summary>
        /// 得到数据库操作上下文
        /// </summary>
        /// <returns></returns>
        public IDbContext GetDbContext()
        {
            DatabaseType dbType = GetDatabaseType();

            string connString = GetConnectionString(dbType);

            IDbContext context = CreateDbContext(dbType, connString);

            return context;
        }

        /// <summary>
        /// 创建DbContext
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static IDbContext CreateDbContext(DatabaseType dbType, string connectionString)
        {
            IDbContext context = null;
            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    context = new MsSqlContext(new DefaultDbConnectionFactory(connectionString));
                    break;
                case DatabaseType.MySql:
                    context = new MySqlContext(new DefaultDbConnectionFactory(connectionString));
                    break;
                default:
                    throw new Exception("在工厂 DbContextFactory 中试图创建 IDbContext 时，发现数据库类型不明确（考虑遗漏了类型）");
            }

            //IDbCommandInterceptor interceptor = new DbCommandInterceptor();
            //// 全局拦截器
            ////DbInterception.Add(interceptor);

            //// 单个DbContext拦截器
            //if (context != null)
            //{
            //    context.Session.AddInterceptor(interceptor);
            //}

            return context;
        }

        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        private static string GetConnectionString(DatabaseType dbType)
        {
            string connectionString = "";
            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    connectionString = ConfigHelper.GetConnectionString("MsSQLConnectionString");
                    break;
                case DatabaseType.MySql:
                    connectionString = ConfigHelper.GetConnectionString("MySQLConnectionString");
                    break;
                default:
                    throw new Exception("在工厂 DbContextFactory 中试图创建 IDbContext 时，发现数据库类型不明确（考虑遗漏了类型）");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception(string.Format(@"基于 {0} 数据库的连接字符串为空，需进行配置", dbType.ToString()));
            }
            return connectionString;
        }

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        private static DatabaseType GetDatabaseType()
        {
            string dbTypeName = ConfigHelper.GetValue("DefaultDb");

            if (string.IsNullOrEmpty(dbTypeName))
            {
                throw new Exception("需配置默认数据库类型 DefaultDb ");
            }

            DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbTypeName, true);

            return dbType;
        }
    }
}