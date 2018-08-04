using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vipstore.Business;

namespace Vipstore
{
    public partial class Detail : Form
    {
        public DataGridViewRow dgvr;
        public Detail(DataGridViewRow dataGridViewRow)
        {
            InitializeComponent();
            dgvr = dataGridViewRow;
            getValue();
        }
        public void getValue()
        {
            string CardID = dgvr.Cells[0].Value.ToString();
            UserManager userManager = new UserManager();
            DataTable dt = userManager.GetVIPMessagee(string.Format(@"1=1 AND ID = {0}", CardID));
            if (dt != null && dt.Rows.Count > 0)
            {
                CardNumber.Text = dt.Rows[0]["CardID"].ToString();
                Iphone.Text = dt.Rows[0]["Phone"].ToString();
                Score.Text = dt.Rows[0]["AllScore"].ToString();
                ReturnMoney.Text = dt.Rows[0]["ReturnMoney"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
