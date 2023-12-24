using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.MainFormQuiz.Teacher;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainFormQuiz.TeacherComponent
{
    public partial class MakeQuestion : UserControl
    {
        private AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = -1;
        public MakeQuestion(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        #region ownmethod
        public void addDataToFlow(DataTable question)
        {
            guna2HtmlLabel2.Text = String.Format("{0:00}", page);
            TeacherQuestionList[] tql = new TeacherQuestionList[offset];
            for (int i = 0; i < offset; ++i)
            {
                tql[i] = new TeacherQuestionList();
                tql[i].QuestionID = (int)question.Rows[i]["QuestionID"];
                tql[i].QuestionDetail = question.Rows[i]["QuestionDetail"] as string;
                tql[i].IsOK = (bool)question.Rows[i]["IsOK"];
                tql[i].IsTest = (bool)question.Rows[i]["IsTest"];
                tql[i].DifficultName = question.Rows[i]["DifficultName"] as string;
                flowLayoutPanel1.Controls.Add(tql[i]);
            }
        }
        #endregion

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            if (guna2ComboBox1.Text == "--Số đáp án--")
                return;
            int numQues = Int32.Parse(guna2ComboBox1.Text);
            QuestionLists[] questionlist = new QuestionLists[numQues];

            for (int i = 0; i < numQues; ++i)
            {
                char B = (char)('A' + i);
                questionlist[i] = new QuestionLists();
                questionlist[i].Label = $"{B}";
                flowLayoutPanel2.Controls.Add(questionlist[i]);
            }
        }

        private async void MakeQuestion_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            PanelScrollHelper flowpan1 = new PanelScrollHelper(flowLayoutPanel2, guna2vScrollBar1, true);
            PanelScrollHelper flowpan2 = new PanelScrollHelper(flowLayoutPanel1, guna2vScrollBar2, true);
            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    guna2ComboBox4.Items.Add(i["BookName"]);
                }
            }

            DataTable question = await MainFormQuizAppBus.Instance.loadQuestionByUser(acc.Username, page, offset);
            if (question.Rows.Count > 0)
            {
                addDataToFlow(question);
            }
        }

        private async void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.Text == "--Sách--")
            {
                guna2ComboBox2.SelectedIndex = 0;
                return;
            }
            DataTable subject = await MainFormQuizAppBus.Instance.loadSubjectByBookName(guna2ComboBox4.Text);
            if (subject.Rows.Count > 0)
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("--Chủ đề--");
                guna2ComboBox2.SelectedIndex = 0;
                foreach (DataRow i in subject.Rows)
                {
                    guna2ComboBox2.Items.Add(i["SubjectName"]);
                }
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if (totalPage != -1)
                page = Math.Min(totalPage, page + 1);
            else
                page++;

            DataTable question = await MainFormQuizAppBus.Instance.loadQuestionByUser(acc.Username, page, offset);
            if (question.Rows.Count > 0)
            {
                addDataToFlow(question);
                return;
            }

            totalPage = page;
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            page = Math.Max(0, page - 1);
            DataTable question = await MainFormQuizAppBus.Instance.loadQuestionByUser(acc.Username, page, offset);
            if (question.Rows.Count > 0)
            {
                flowLayoutPanel1.Controls.Clear();
                addDataToFlow(question);
                return;
            }
        }
    }
}
