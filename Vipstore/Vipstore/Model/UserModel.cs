using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vipstore.Model
{
    public class UserModel
    { 
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string CardID { get; set; }
        public string Password { get; set; }
        public string ReturnMoney { get; set; }
        public string AllScore { get; set; }
    }
}
