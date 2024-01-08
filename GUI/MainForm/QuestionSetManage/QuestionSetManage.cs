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
using GUI.MainForm.QuestionSet.QuestionTestPage;
using GUI.MainForm.QuestionSetManage.QuestionSetDivPage;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;

namespace GUI.MainForm.QuestionSetManage
{
    public partial class QuestionSetManage : UserControl
    {
        private AccountResponse acc;
        public QuestionSetManage(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void QuestionSetManage_Load(object sender, EventArgs e)
        {
            MakeQuestionSet mqk = new MakeQuestionSet(acc);
            mqk.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(mqk);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MakeQuestionSet mqk = new MakeQuestionSet(acc);
            mqk.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Clear();
            guna2Panel1.Controls.Add(mqk);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            QuestionSetManageP qtmp = new QuestionSetManageP(acc);
            qtmp.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Clear();
            guna2Panel1.Controls.Add(qtmp);
        }

    }
}
