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
    public partial class AddManager : Form
    {
        public AddManager()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Password.Text.Trim() != ConfirmPass.Text.Trim())
            {
                Tip.Text = "两次密码输入不一致，请重新输入";
            }
            else
            {
                string uName = UserName.Text.Trim();
                string Pass = Password.Text.Trim();
                LoginManager loginManager = new LoginManager();
                if (loginManager.AddLoginUser(uName, Pass) > 0)
                {
                    MessageBox.Show("系统提示", "用户添加成功！");
                }
                else
                {
                    MessageBox.Show("系统提示", "用户添加失败！");
                }
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
