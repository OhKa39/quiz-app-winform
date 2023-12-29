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

namespace GUI.MainForm.TeacherPage
{
    public partial class TeacherPage : UserControl
    {
        private AccountResponse acc;
        public TeacherPage(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            MakeQuestion mQ = new MakeQuestion(acc);
            mQ.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(mQ);
        }
    }
}
