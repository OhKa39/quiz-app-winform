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
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;

namespace GUI.MainForm.ValidateManage
{
    public partial class ValidateComponent : UserControl
    {
        AccountResponse acc;
        public ValidateComponent(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void ValidateComponent_Load(object sender, EventArgs e)
        {
            QuestionSetList qsl = new QuestionSetList(acc);
            qsl.Type = 3;
            guna2Panel1.Controls.Add(qsl);

            QuestionListComponentQS qlcqs = new QuestionListComponentQS();
            qlcqs.IsEdit = -1;
            qlcqs.Type = 3;
            qlcqs.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Add(qlcqs);
        }
    }
}
