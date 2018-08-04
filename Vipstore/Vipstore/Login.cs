using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vipstore.Business;
using Vipstore.Common;
using Vipstore.Model;

namespace Vipstore
{
    public partial class Login : Form
    {
        LoginManager loginmanager = new LoginManager();
        public Login()
        {
            InitializeComponent();
        }

        private void ButLogin_Click(object sender, EventArgs e)
        {
            if (loginmanager.GetMessage(txtUserName.Text.Trim()).Rows.Count == 0)
            {
                lblMessage.Text = "您输入的账号有误！请重新输入";
            }
            else if (loginmanager.GetMessage(txtUserName.Text.Trim(), txtPassword.Text.Trim()).Rows.Count == 0)
            {
                lblpassMessage.Text = "您输入的密码不匹配！请重新输入";
            }
            else
            {
                Menu_Form mef = new Menu_Form();
                this.Visible = false;
                mef.ShowDialog();
                this.Dispose();
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loginmanager.CreateDatabase();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblpassMessage.Text = string.Empty;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.ButLogin_Click(sender, e);//触发button事件  
            }
        }
    }
}
