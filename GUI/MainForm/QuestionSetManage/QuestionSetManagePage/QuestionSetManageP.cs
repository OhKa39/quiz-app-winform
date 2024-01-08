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

namespace GUI.MainForm.QuestionSetManage.QuestionSetManagePage
{
    public partial class QuestionSetManageP : UserControl
    {
        AccountResponse acc;
        public QuestionSetManageP(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void QuestionTestManageP_Load(object sender, EventArgs e)
        {
            QuestionListComponentQS qlcqs = new QuestionListComponentQS();
            qlcqs.IsEdit = -1;
            qlcqs.Type = 2;
            qlcqs.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Add(qlcqs);
            
            QuestionSetList qsl = new QuestionSetList(acc);
            qsl.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(qsl);

            
        }
    }
}
