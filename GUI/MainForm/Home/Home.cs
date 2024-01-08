using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI.MainForm.Home
{
    public partial class Home : UserControl
    {
        AccountResponse acc;
        public Home(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            Control uc = new TestList(acc);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }
    }
}
