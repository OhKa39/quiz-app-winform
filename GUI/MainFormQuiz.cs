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
using GUI.MainForm.CreateTest;
using GUI.MainForm.Home;
using GUI.MainForm.QuestionSet;
using GUI.MainForm.QuestionSetManage;
using GUI.MainForm.ValidateManage;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GUI
{
    public partial class MainFormQuiz : Form
    {
        private AccountResponse account;
        public MainFormQuiz(AccountResponse _account)
        {
            account = _account;
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (account.RoleName == "Student")
            {
                MessageBox.Show(
                    $"Tính năng không khả dụng",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            guna2CustomGradientPanel1.Controls.Clear();
            Control uc = new CreateQuestionP(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }

        private void MainFormQuizApp_Load(object sender, EventArgs e)
        {
            Control uc = new Home(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }

        private void MainFormQuizApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (account.RoleName == "Student")
            {
                MessageBox.Show(
                    $"Tính năng không khả dụng",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            guna2CustomGradientPanel1.Controls.Clear();
            Control uc = new QuestionSetManage(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (account.RoleName == "Student")
            {
                MessageBox.Show(
                    $"Tính năng không khả dụng",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            guna2CustomGradientPanel1.Controls.Clear();
            Control uc = new CreateTestP(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel1.Controls.Clear();
            Control uc = new Home(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (account.RoleName == "Student" || account.RoleName == "Teacher")
            {
                MessageBox.Show(
                    $"Tính năng không khả dụng",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            guna2CustomGradientPanel1.Controls.Clear();
            Control uc = new ValidateManageP(account);
            uc.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(uc);
        }
    }
}
