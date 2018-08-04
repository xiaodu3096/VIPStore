using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vipstore.Common;

namespace Vipstore.Business
{
    public class LogManager
    {
        public int AddLogRecord(string CardNumber, string SaleMoney, string SaleScore, string SaleType)
        {
            return SqliteHelper.ExecuteSql(string.Format(@"insert into [LogModel](CardNumber,[SaleMoney],SaleScore,SaleData,SaleType) values ('{0}','{1}','{2}','{3}','{4}')", CardNumber, SaleMoney, SaleScore, DateTime.Now, SaleType));
        }
    }
}
