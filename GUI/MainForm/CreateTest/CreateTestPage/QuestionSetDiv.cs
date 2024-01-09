using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.MainForm.QuestionSet.QuestionPage;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;
using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSetManage.QuestionSetDivPage
{
    public partial class QuestionSetDiv : UserControl
    {
        AccountResponse acc;
        public QuestionSetDiv(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void QuestionSetDiv_Load(object sender, EventArgs e)
        {
            QuestionSetList qsl = new QuestionSetList(acc);
            qsl.Type = 2;
            guna2Panel1.Controls.Add(qsl);

            QuestionSetDivControl qsdv = new QuestionSetDivControl(acc);
            qsdv.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Add(qsdv);


        }
    }
}
