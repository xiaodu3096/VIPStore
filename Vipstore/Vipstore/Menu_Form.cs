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
    public partial class Menu_Form : Form
    {
        UserManager userManager = new UserManager();
        public Menu_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击注册用户按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, EventArgs e)
        {
            RegisterUser ru = new RegisterUser();
            ru.ShowDialog();
        }
        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCancel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.ShowDialog();
            this.Dispose();
            this.Close();
        }
        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string where = GetWhere();
            DataTable dt = userManager.GetAllUserMessage(where);
            UserGridView.DataSource = dt;
            //UserGridView();
        }

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Form_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            string where = GetWhere();
            DataTable dt = userManager.GetAllUserMessage(where);
            UserGridView.DataSource = dt;
            UserGridView.AutoResizeColumns(
                   DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            this.UserGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        public string GetWhere()
        {
            string Flag = "1=1 ";
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                Flag += string.Format(@"AND UserName = '{0}' ", txtUserName.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                Flag += string.Format(@"AND Phone = '{0}' ", txtPhone.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtCardID.Text.Trim()))
            {
                Flag += string.Format(@"AND CardID = '{0}' ", txtCardID.Text.Trim());
            }

            return Flag;
        }

        private void UserGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(this.UserGridView["你所要获取值的列", e.RowIndex].Value.ToString());
        }

        private void UserGridView_DoubleClick(object sender, EventArgs e)
        {
            Detail detail = new Detail(UserGridView.CurrentRow);
            detail.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePass updatePass = new UpdatePass();
            updatePass.ShowDialog();
        }

        private void 费用结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.ShowDialog();
        }

        private void 用户注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterUser ru = new RegisterUser();
            ru.ShowDialog();
        }

        private void 费用结算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.ShowDialog();
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMoney saveMoney = new SaveMoney();
            saveMoney.ShowDialog();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.ShowDialog();
            this.Dispose();
            this.Close();
        }

        private void 用户菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddManager addManager = new AddManager();
            addManager.ShowDialog();
        }

        private void 查看管理员ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowManager showManager = new ShowManager();
            showManager.ShowDialog();
        }

        private void 积分兑换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopScore shopScore = new ShopScore();
            shopScore.ShowDialog();
        }

        private void 更换手机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePhoneNumber changePhoneNumber = new ChangePhoneNumber();
            changePhoneNumber.ShowDialog();
        }

        private void 更换会员卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCardNumber changeCardNumber = new ChangeCardNumber();
            changeCardNumber.ShowDialog();
        }
        private void 修改密码ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdatePass updatePass = new UpdatePass();
            updatePass.ShowDialog();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass changePass = new ChangePass();
            changePass.ShowDialog();
        }
         
    }
}
