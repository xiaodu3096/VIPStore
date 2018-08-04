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
    public partial class ChangePhoneNumber : Form
    {
        UserManager userManager = new UserManager();
        LogManager logManager = new LogManager();
        public ChangePhoneNumber()
        {
            InitializeComponent();
        }

        private void OldPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt = userManager.GetVIPMessagee(string.Format(@" Phone = '{0}' ", OldPhoneNumber.Text.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    ReturnMoney.Text = dt.Rows[0]["ReturnMoney"].ToString();
                    AllScore.Text = dt.Rows[0]["AllScore"].ToString();
                }
                else
                {
                    MessageBox.Show("手机号不存在", "系统提示");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPhoneNumber.Text.Trim()))
            {
                DataTable dt = userManager.GetVIPMessagee(string.Format(@" CardID = '{0}' or Phone = '{0}' ", OldPhoneNumber.Text.Trim()));
                if (dt.Rows.Count > 0 && dt != null)
                {
                    int count = userManager.UpdateUserMessage(OldPhoneNumber.Text.Trim(), txtNewPhoneNumber.Text.Trim(), "更换手机号");
                    if (count > 0)
                    {
                        MessageBox.Show("新手机号更新成功", "系统提示"); 
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("原手机号不存在", "系统提示");
                }
            }
            else
            {
                MessageBox.Show("新手机号不能为空", "系统提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
