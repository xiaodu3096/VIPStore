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
    public class UserManager
    {
        public DataTable GetAllUserMessage(string Where)
        {
            string sql = string.Format(@"select ID as  '序号', UserName as '会员姓名',Phone as '手机号码',CardID as '会员卡号',ReturnMoney as '余额', AllScore as '积分' from UserModel where {0}", Where);
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

        public int AddUser(UserModel user)
        {
            int count = 0;
            count = SqliteHelper.ExecuteSql(string.Format(@"insert into [UserModel](UserName,Phone,CardID,ReturnMoney,AllScore,[Password]) values ('{0}','{1}','{2}','{3}','{4}','{5}')", user.UserName, user.Phone, user.CardID, user.ReturnMoney, user.AllScore, user.Password));
            return count;
        }

        public DataTable GetVIPMessagee(string Where)
        {
            string sql = string.Format(@"select ID, UserName,Phone,CardID,ReturnMoney,AllScore from UserModel where {0}", Where);
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
        /// 修改积分和剩余金额
        /// </summary>
        /// <param name="CardID"></param>
        /// <param name="Score"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        public int UpdateScore(string CardID, int Score, string Money, string Password)
        {
            string sql = string.Format(@"Update UserModel set ReturnMoney = {0},AllScore={1} where (CardID = '{2}' or Phone = '{2}' ) and Password = '{3}' ", Money, Score, CardID, Password);
            return SqliteHelper.ExecuteSql(sql);
        }

        public int UpdateMoney(string CardID, double Money)
        {
            string sql = string.Format(@"Update UserModel set ReturnMoney = {0} where CardID = '{1}' or Phone = '{1}' ", Money, CardID);
            return SqliteHelper.ExecuteSql(sql);
        }

        public int UpdateUserMessage(string OldMessage, string Message, string Mark)
        {
            string sql = string.Empty;
            if (Mark == "更换手机号")
            {
                sql = string.Format(@"Update UserModel set Phone = '{0}' where Phone = '{1}' ", Message, OldMessage);
                return SqliteHelper.ExecuteSql(sql);
            }
            else if (Mark == "更改卡号")
            {
                sql = string.Format(@"Update UserModel set CardID = '{0}' where CardID = '{1}' ", Message, OldMessage);
                return SqliteHelper.ExecuteSql(sql);
            }
            else
            {
                sql = string.Format(@"Update UserModel set Password = '{0}' where CardID = '{1}' or Phone = '{1}' ", OldMessage, Message);
                return SqliteHelper.ExecuteSql(sql);
            }
        }
    }
}
