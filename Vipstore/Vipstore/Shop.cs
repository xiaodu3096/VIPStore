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
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogManager logManager = new LogManager();
            DataTable dt = userManager.GetVIPMessagee(string.Format(@" 1=1 and (CardID = '{0}' or Phone = '{0}' )", txtCardNumber.Text.Trim()));
            DataTable dt2 = userManager.GetVIPMessagee(string.Format(@" 1=1 and (CardID = '{0}' or Phone = '{0}' ) and Password = '{1}' ", txtCardNumber.Text.Trim(), txtPass.Text.Trim()));
            if (dt != null && dt.Rows.Count > 0)
            {
                string money = txtMoney.Text.Trim();
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    if (double.Parse(money) > double.Parse(dt.Rows[0]["ReturnMoney"].ToString()))
                    {
                        MessageBox.Show("账户余额不足，卡内余额为:" + dt.Rows[0]["ReturnMoney"] + "！", "系统提示");
                    }
                    else
                    {
                        int SaleScore = (int)double.Parse(txtMoney.Text);
                        int AllScore = int.Parse(dt.Rows[0]["AllScore"].ToString()) + SaleScore;
                        double ReturnMoney = double.Parse(dt.Rows[0]["ReturnMoney"].ToString()) - double.Parse(money);
                        int count = userManager.UpdateScore(txtCardNumber.Text.Trim(), AllScore, ReturnMoney.ToString("0.00"), txtPass.Text.Trim());
                        if (count > 0)
                        {
                            int LogCount = logManager.AddLogRecord(txtCardNumber.Text.Trim(), money.ToString(), SaleScore.ToString(), "消费");
                            if (LogCount > 0)
                            {
                                MessageBox.Show("结算成功,卡内余额为:" + ReturnMoney .ToString("0.00")+ ",卡内积分为:" + AllScore + "", "系统提示");
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("账号或密码错误！", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("卡号或手机号不存在", "系统提示");
            }
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = userManager.GetVIPMessagee(string.Format(@" CardID = '{0}' or Phone = '{0}' ", txtCardNumber.Text.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtReturnMoney.Text = dt.Rows[0]["ReturnMoney"].ToString();
                }
                else
                {
                    MessageBox.Show("卡号不存在", "系统提示");
                }
            }
        }
    }
}
