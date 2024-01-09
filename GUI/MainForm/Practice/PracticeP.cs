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
using GUI.MainForm.Practice.TrainingHistoryPage;
using GUI.MainForm.Practice.TrainingPage;
using Guna.UI2.WinForms;

namespace GUI.MainForm.Practice
{
    public partial class PracticeP : UserControl
    {
        AccountResponse acc;
        public PracticeP(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void PracticeP_Load(object sender, EventArgs e)
        {
            Control uc = new trainingUC(acc);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            Control uc = new trainingUC(acc);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            Control uc = new TrainingHistory(acc);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }
    }
}
