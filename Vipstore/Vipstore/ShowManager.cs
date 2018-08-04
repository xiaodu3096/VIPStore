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
    public partial class ShowManager : Form
    {
        public ShowManager()
        {
            InitializeComponent();
        }

        private void ShowManager_Load(object sender, EventArgs e)
        {
            LoginManager loginManager = new LoginManager();
            dataGridView1.DataSource = loginManager.GetMessage(); 
            dataGridView1.AutoResizeColumns(
                   DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
