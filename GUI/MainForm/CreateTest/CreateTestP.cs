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
using GUI.MainForm.CreateTest.TestPageManage;
using GUI.MainForm.QuestionSetManage.QuestionSetDivPage;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;

namespace GUI.MainForm.CreateTest
{
    public partial class CreateTestP : UserControl
    {
        private AccountResponse acc;
        public CreateTestP(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void QuestionSetManage_Load(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            QuestionSetDiv qsd = new QuestionSetDiv(acc);
            qsd.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(qsd);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            QuestionSetDiv qsd = new QuestionSetDiv(acc);
            qsd.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(qsd);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            ManageTest mt = new ManageTest(acc);
            mt.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(mt);
        }
    }
}
