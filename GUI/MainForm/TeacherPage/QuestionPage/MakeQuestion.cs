using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.MainForm.TeacherPage
{
    public partial class MakeQuestion : UserControl
    {
        private AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        private FilterMember filtermember;
        private string searchBox = "";
        private int isTurnOn = -1;

        public string SearchBox { get => searchBox; set => searchBox = value; }

        public MakeQuestion(AccountResponse _acc)
        {
            acc = _acc;
            filtermember = new FilterMember();
            InitializeComponent();
        }

        #region ownmethod
        private void addDataToFlow(DataTable question)
        {
            flowLayoutPanel1.Controls.Clear();
            totalPage = (int)Math.Ceiling((int)question.Rows[0]["TotalRecords"] / (double)offset);
            TeacherQuestionList[] tql = new TeacherQuestionList[offset];
            for (int i = 0; i < question.Rows.Count; ++i)
            {
                tql[i] = new TeacherQuestionList();
                tql[i].QuestionID = (int)question.Rows[i]["QuestionID"];
                tql[i].QuestionDetail = question.Rows[i]["QuestionDetail"] as string;
                tql[i].IsOK = (bool)question.Rows[i]["IsOK"];
                tql[i].IsTest = (bool)question.Rows[i]["IsTest"];
                tql[i].DifficultName = question.Rows[i]["DifficultName"] as string;
                tql[i].SubjectName = question.Rows[i]["SubjectName"] as string;
                tql[i].UpdateAt = (DateTime)question.Rows[i]["UpdateAt"];

                flowLayoutPanel1.Controls.Add(tql[i]);
            }
        }

        private async void updateData()
        {
            string difficultName = filtermember.DifficultName != "--Độ khó--" ? filtermember.DifficultName : "";
            string subjectName = filtermember.SubjectName != "--Chủ đề--" ? filtermember.SubjectName : "";
            int? IsTest = filtermember.IsTest != "--Dạng--" ? (filtermember.IsTest == "Thi" ? 1 : 0) : null;
            int? IsOK = filtermember.IsOK != "--Tình trạng--" ? (filtermember.IsOK == "Đã được duyệt" ? 1 : 0) : null;
            DataTable question = await MainFormQuizAppBus
                .Instance
                .loadQuestionByUser(acc.Username, page, offset, searchBox, difficultName, subjectName, filtermember.From, filtermember.To, IsTest, IsOK);
            if (question.Rows.Count > 0)
            {
                await Task.Run(() =>
                {
                    this.Invoke(new Action(() => addDataToFlow(question)));
                });
                guna2HtmlLabel2.Text = String.Format("/{0:00}", totalPage);
                return;
            }
            flowLayoutPanel1.Controls.Clear();
            totalPage = 1;
            guna2HtmlLabel2.Text = String.Format("/{0:00}", totalPage);
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
            guna2TextBox2.Text = page.ToString();
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox5.SelectedIndex = 0;
            guna2TextBox3.DataBindings.Add("Text", this, "SearchBox", false, DataSourceUpdateMode.OnPropertyChanged);
            PanelScrollHelper flowpan1 = new PanelScrollHelper(
                    flowLayoutPanel2, guna2vScrollBar1, true
                );
            PanelScrollHelper flowpan2 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar2, true
                );
            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    guna2ComboBox4.Items.Add(i["BookName"]);
                }
            }
        }

        private async void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.Text == "--Sách--")
            {
                guna2ComboBox2.SelectedIndex = 0;
                return;
            }
            DataTable subject = await MainFormQuizAppBus
                .Instance
                .loadSubjectByBookName(guna2ComboBox4.Text);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (page == totalPage)
                return;
            ++page;
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return;
                }
                updateData();
                return;
            }
            guna2TextBox2.Text = page.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (page == 1)
                return;
            --page;
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return;
                }
                updateData();
                return;
            }
            guna2TextBox2.Text = page.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            using (Filter filterControl = new Filter(filtermember))
            {
                filterControl.ShowDialog();
                filtermember = filterControl.FilterMember;
            }
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return;
                }
                updateData();
                return;
            }
            guna2TextBox2.Text = "1";
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            searchBox = guna2TextBox3.Text;
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return;
                }
                updateData();
                return;
            }
            guna2TextBox2.Text = "1";
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            string questionDetail = guna2TextBox1.Text;
            string subjectName = guna2ComboBox2.SelectedItem as string;
            string difficultName = guna2ComboBox3.SelectedItem as string;
            string isTest = guna2ComboBox5.SelectedItem as string;
            int? questionID = await MainFormQuizAppBus
                .Instance
                .createQuestionByUserID(
                    questionDetail, subjectName, difficultName, isTest, acc.AccountID
                );

            string answerDetail = "";
            string isTrue = "";
            foreach (QuestionLists control in flowLayoutPanel2.Controls)
            {
                answerDetail = answerDetail + control.TextBoxText + ",";
                isTrue = isTrue + (control.IsChecked == true ? "1" : "0") + ",";
            }
            int? count = await MainFormQuizAppBus
                .Instance
                .createAnswerByQuestionID(
                    questionID, answerDetail, isTrue
                );
            if (count != flowLayoutPanel2.Controls.Count)
            {
                MessageBox.Show("Error");
                return;
            }

            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox5.SelectedIndex = 0;
            guna2TextBox1.Text = "";
            MessageBox.Show("Success");
            updateData();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (isTurnOn == -1)
            {
                foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
                {
                    tql.Choose = true;
                }
                isTurnOn *= -1;
                guna2Button5.Text = "Bỏ chọn";
                return;
            }

            foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
            {
                tql.Choose = false;
            }
            guna2Button5.Text = "Chọn tất cả";
            isTurnOn *= -1;
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            string questionIDLists = "";
            foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
            {
                if (tql.Choose == true)
                {
                    if (tql.IsOK)
                    {
                        MessageBox.Show(
                           "Không được chọn câu hỏi đã được phê duyệt",
                           "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error
                       );
                        return;
                    }
                    questionIDLists += tql.QuestionID + ",";
                }

            }
            if (questionIDLists == "")
            {
                MessageBox.Show(
                    "Chưa chọn câu hỏi để xóa",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }
            questionIDLists = questionIDLists.Substring(0, questionIDLists.Length - 1);
            int countRowsAffect = await MainFormQuizAppBus.Instance.deleteQuestionByQuestionID(questionIDLists);
            if (countRowsAffect > 0)
                MessageBox.Show(
                    "Thêm câu hỏi thành công",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return;
                }
                updateData();
                return;
            }
            guna2TextBox2.Text = "1";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(guna2TextBox2.Text, out int result))
            {
                // Update the int value if parsing is successful
                page = result;
                updateData();
            }
        }
    }
}
