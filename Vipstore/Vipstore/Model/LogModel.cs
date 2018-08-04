using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vipstore.Model
{
    public class LogModel
    {
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public double SaleMoney { get; set; }
        public int SaleScore { get; set; }
        public DateTime SaleData { get; set; }
    }
}
