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
    public partial class SaveMoney : Form
    {
        UserManager userManager = new UserManager();
        LogManager logManager = new LogManager();
        public SaveMoney()
        {
            InitializeComponent();
            CardNumber.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = userManager.GetVIPMessagee(string.Format(@" CardID = '{0}' or Phone = '{0}' ", CardNumber.Text.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    ReturnMoney.Text = dt.Rows[0]["ReturnMoney"].ToString();
                    AllScore.Text = dt.Rows[0]["AllScore"].ToString();
                }
                else {
                    MessageBox.Show("卡号不存在", "系统提示");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Money = double.Parse(ReturnMoney.Text) + double.Parse(txtSaveMoney.Text.Trim());
            int count = userManager.UpdateMoney(CardNumber.Text.Trim(), Money);
            int LogCount = logManager.AddLogRecord(CardNumber.Text.Trim(), txtSaveMoney.ToString(), AllScore.Text, "充值");
            if (count > 0 && LogCount > 0)
            {
                MessageBox.Show("充值成功", "系统提示");
                this.Close();
            }
        }

        private void SaveMoney_Activated(object sender, EventArgs e)
        {
            CardNumber.Focus();
        }
    }
}
