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
    public partial class ShopScore : Form
    {
        UserManager userManager = new UserManager();
        public ShopScore()
        {
            InitializeComponent();
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = userManager.GetVIPMessagee(string.Format(@" CardID = '{0}' or Phone = '{0}' ", txtCardNumber.Text.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtScore.Text = dt.Rows[0]["AllScore"].ToString();
                }
                else
                {
                    MessageBox.Show("卡号不存在", "系统提示");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogManager logManager = new LogManager();
            DataTable dt = userManager.GetVIPMessagee(string.Format(@" 1=1 and (CardID = '{0}' or Phone = '{0}' )", txtCardNumber.Text.Trim()));
            DataTable dt2 = userManager.GetVIPMessagee(string.Format(@" 1=1 and (CardID = '{0}' or Phone = '{0}' ) and Password = '{1}' ", txtCardNumber.Text.Trim(), txtPass.Text.Trim()));
            if (dt != null && dt.Rows.Count > 0)
            { 
                int Score = (int)double.Parse(txtAllScore.Text);
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    if (Score > int.Parse(dt.Rows[0]["AllScore"].ToString()))
                    {
                        MessageBox.Show("账户积分不足，卡内积分为:" + dt.Rows[0]["AllScore"] + "！", "系统提示");
                    }
                    else
                    {
                        int SaleScore = int.Parse(txtAllScore.Text);
                        double Money = double.Parse(dt.Rows[0]["ReturnMoney"].ToString());
                        int ReturnScore = int.Parse(dt.Rows[0]["AllScore"].ToString()) - Score;
                        int count = userManager.UpdateScore(txtCardNumber.Text.Trim(), ReturnScore, Money.ToString(), txtPass.Text.Trim());
                        if (count > 0)
                        {
                            int LogCount = logManager.AddLogRecord(txtCardNumber.Text.Trim(), "0", SaleScore.ToString(), "消费");
                            if (LogCount > 0)
                            {
                                MessageBox.Show("兑换成功,卡内生于积分为:" + ReturnScore + "", "系统提示");
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
    }
}
