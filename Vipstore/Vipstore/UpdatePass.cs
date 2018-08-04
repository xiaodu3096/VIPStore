using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vipstore
{
    public partial class UpdatePass : Form
    {
        public string UserName = "";
        public UpdatePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPass = txtoldPass.Text.Trim();
            string newPass = textBox2.Text.Trim();
            string confirmPass = textBox3.Text.Trim();
            if (!string.IsNullOrEmpty(oldPass))
            {

            }
            else
            {

            }
        }
    }
}
