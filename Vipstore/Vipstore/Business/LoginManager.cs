using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Vipstore.Common;
using Vipstore.Model;
using System.Data;

namespace Vipstore.Business
{
    public class LoginManager
    {
        /// <summary>
        /// 初始化数据表
        /// </summary>
        public void CreateDatabase()
        {
            int result = SqliteHelper.ExecuteScalar("SELECT COUNT(*) FROM sqlite_master where type='table' and name='UserModel'");
            int result2 = SqliteHelper.ExecuteScalar("SELECT COUNT(*) FROM sqlite_master where type='table' and name='ManagerModel'");
            int result3 = SqliteHelper.ExecuteScalar("SELECT COUNT(*) FROM sqlite_master where type='table' and name='LogModel'");
            if (result == 0)
            {
                //创建用户表  
                SqliteHelper.ExecuteSql(@"create table [UserModel] (
                                                        ID INTEGER primary key autoincrement not null,
                                                        UserName nvarchar(100) not null, 
                                                        Phone nvarchar(100) not null,
                                                        CardID nvarchar(100) not null,
                                                        Password nvarchar(50) not null,
                                                        ReturnMoney nvarchar(100) not null,
                                                        AllScore nvarchar(100) not null
                                                    )");
            }
            if (result2 == 0)
            {
                //创建管理员表  
                SqliteHelper.ExecuteSql(@"create table [ManagerModel] (
                                                        ID INTEGER primary key autoincrement not null,
                                                        UserName nvarchar(100) not null, 
                                                        [Password] nvarchar(100) not null
                                                    )");
                int count = SqliteHelper.ExecuteSql("insert into [ManagerModel](UserName,[Password]) values ('admin','admin')");
            }

            if (result3 == 0) {
                //创建用户消费记录表
                SqliteHelper.ExecuteSql(@"create table [LogModel] (
                                                        ID INTEGER primary key autoincrement not null,
                                                        CardNumber nvarchar(100) not null,   
                                                        SaleMoney nvarchar(100) null,
                                                        SaleScore nvarchar(100) null,
                                                        SaleData date not null,
                                                        SaleType nvarchar(50) null
                                                    )");
            }
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable GetMessage(string UserName, string Password)
        {
            string sql = string.Format(@"select * from ManagerModel where Username = '{0}' and [Password] = '{1}' ", UserName, Password);
            DataSet ds = SqliteHelper.ExecDataSet(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable GetMessage(string UserName)
        {
            string sql = string.Format(@"select * from ManagerModel where Username = '{0}'", UserName);
            DataSet ds = SqliteHelper.ExecDataSet(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public int AddLoginUser(string UserName, string Password)
        {
            return SqliteHelper.ExecuteSql(string.Format(@"insert into [ManagerModel](UserName,[Password]) values ('{0}','{1}')", UserName, Password));
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataTable GetMessage()
        {
            string sql = string.Format(@"select ID as '序列号',UserName as '账号',Password as '密码' from ManagerModel ");
            DataSet ds = SqliteHelper.ExecDataSet(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}
