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
using Vipstore.Model;

namespace Vipstore
{
    public partial class RegisterUser : Form
    {
        UserManager loginManager = new UserManager();
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void butReg_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                lblUserMessage.Text = "用户名不能为空！请重新输入";
                flag = false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                lblPhoneMessage.Text = "电话不能为空！请重新输入";
                flag = false;
            }

            if (string.IsNullOrEmpty(txtCardNumber.Text))
            {
                lblCardMessage.Text = "卡号不能为空！请重新输入";
                flag = false;
            }

            if (string.IsNullOrEmpty(txtpassword.Text.Trim()))
            {
                lblPassword.Text = "密码不能为空！请重新输入";
                flag = false;
            }

            if (!string.IsNullOrEmpty(txtMoney.Text))
            {
                double Money = Convert.ToDouble(txtMoney.Text.Trim());
                if (Money < 0)
                {
                    lblMoneyMessage.Text = "充值金额不能小于0！请重新输入";
                    flag = false;
                }
            }
            if (flag)
            {
                DataTable dt = loginManager.GetAllUserMessage(string.Format(@" 1=1 and CardID = '{0}'  ", txtCardNumber.Text.Trim()));
                DataTable dt2 = loginManager.GetAllUserMessage(string.Format(@" 1=1 and Phone = '{0}' ", txtPhone.Text.Trim()));

                if (dt.Rows.Count != 0 && dt != null)
                {
                    MessageBox.Show("该卡号已存在！", "系统提示");
                }
                else if (dt2.Rows.Count != 0 && dt2 != null)
                {
                    MessageBox.Show("该手机号已存在！", "系统提示");
                }
                else
                {
                    UserModel um = new UserModel()
                    {
                        AllScore = "0",
                        UserName = txtUserName.Text.Trim(),
                        CardID = txtCardNumber.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Password = txtpassword.Text.Trim(),
                        ReturnMoney = !string.IsNullOrEmpty(txtMoney.Text.Trim()) ? Convert.ToDouble(txtMoney.Text.Trim()).ToString() : "0.0"
                    };
                    int count = loginManager.AddUser(um);
                    if (count > 0)
                    {
                        MessageBox.Show("用户添加成功！", "系统提示");
                        this.Visible = false;
                        this.Dispose();
                        this.Close();
                        Menu_Form menu_Form = new Menu_Form();
                        menu_Form.BindData();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
            this.Close();
        }
    }
}
