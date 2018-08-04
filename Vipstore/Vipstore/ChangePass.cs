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
    public partial class ChangePass : Form
    {
        UserManager userManager = new UserManager();
        public ChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true;
            DataTable dt = userManager.GetVIPMessagee(string.Format(@" CardID = '{0}' or Phone = '{0}'", txtCardID.Text.Trim()));
            if (dt.Rows.Count > 0 && dt != null)
            {
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    lblPass.Text = "密码不能为空！请重新输入";
                    lblConfirmPass.Text = "";
                    lblCardID.Text = "";
                    flag = false;
                }
                else if (string.IsNullOrEmpty(txtConfirmPass.Text.Trim()))
                {
                    lblConfirmPass.Text = "两次密码不一致！请重新输入";
                    lblCardID.Text = "";
                    lblPass.Text = "";
                    flag = false;
                }
                else if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
                {
                    lblConfirmPass.Text = "两次密码不一致！请重新输入";
                    lblPass.Text = "";
                    lblCardID.Text = "";
                    flag = false;
                }
                else
                {
                    if (userManager.UpdateUserMessage(txtConfirmPass.Text.Trim(), txtCardID.Text.Trim(), "修改密码") > 0)
                    {
                        MessageBox.Show("密码已更新", "系统提示");
                        this.Close();
                    }
                }
            }
            else
            {
                lblCardID.Text = "卡号或手机号不存在！请重新输入";
                flag = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
