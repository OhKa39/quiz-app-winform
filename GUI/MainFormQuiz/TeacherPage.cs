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
using GUI.MainFormQuiz.Teacher;
using GUI.MainFormQuiz.TeacherComponent;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainFormQuiz
{
    public partial class TeacherPage : UserControl
    {
        private AccountResponse account;
        public TeacherPage(AccountResponse _account)
        {
            account = _account;
            InitializeComponent();
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            Control uc = new MakeQuestion(account);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }
    }
}
