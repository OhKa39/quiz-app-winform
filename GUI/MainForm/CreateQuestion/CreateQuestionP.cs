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
using GUI.MainForm.QuestionSet.QuestionPage;
using GUI.MainForm.QuestionSet.QuestionTestPage;

namespace GUI.MainForm.QuestionSet
{
    public partial class CreateQuestionP : UserControl
    {
        private AccountResponse acc;
        public CreateQuestionP(AccountResponse _acc)
        {
            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true
            );
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            acc = _acc;
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

        private void QuestionSet_Load(object sender, EventArgs e)
        {
            MakeQuestion mQ = new MakeQuestion(acc);
            mQ.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(mQ);
        }

    }
}
