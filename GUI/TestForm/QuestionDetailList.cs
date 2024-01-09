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
using GUI.MainFormQuizApp;
using Guna.UI2.WinForms;

namespace GUI.TestForm
{
    public partial class QuestionDetailList : UserControl
    {
        private int stateIsEdit = -1;
        private Question question;

        public int StateIsEdit { get => stateIsEdit; set => stateIsEdit = value; }

        public QuestionDetailList(Question _question)
        {
            question = _question;
            InitializeComponent();
        }

        private void QuestionDetailList_Load(object sender, EventArgs e)
        {
            if (StateIsEdit == 1)
                guna2Button1.Enabled = false;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.Text = question.DifficultName;
            guna2ComboBox2.Items.Add(question.SubjectName);
            guna2ComboBox2.Text = question.SubjectName;
            guna2ComboBox5.SelectedIndex = question.IsTest == true ? 2 : 1;
            guna2HtmlLabel3.Text = $"Lần cập nhật gần nhất: {question.UpdateAt.ToLocalTime()}";
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            TestFormUI tfUI = (TestFormUI)this.Parent.Parent;
            tfUI.guna2TextBox1.Enabled = true;
            foreach (AnswerDetailList adl in tfUI.flowLayoutPanel1.Controls)
            {
                adl.guna2TextBox1.Enabled = true;
                adl.guna2RadioButton1.Enabled = true;
                adl.EnableEvent = -1;
            }
            guna2ComboBox4.Enabled = true;
            guna2ComboBox3.Enabled = true;
            guna2ComboBox2.Enabled = true;
            guna2ComboBox5.Enabled = true;

            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    guna2ComboBox4.Items.Add(i["BookName"]);
                }
            }
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = true;
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

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                TestFormUI tfUI = (TestFormUI)this.Parent.Parent;
                string subjectName = guna2ComboBox2.Text;
                string isTestString = guna2ComboBox5.Text;
                string questionDetail = tfUI.guna2TextBox1.Text;
                string difficultName = guna2ComboBox3.Text;

                if (subjectName == "--Chủ đề--" || isTestString == "--Dạng--"
                   || questionDetail.Trim() == "" || difficultName == "--Độ khó--")
                    throw new Exception("Không được để trống trường thông tin");

                bool isTest = isTestString == "Thi" ? true : false;
                string answerID = "";
                string isTrue = "";
                string answerDetail = "";
                int cnt = tfUI.flowLayoutPanel1.Controls.Count;

                foreach (AnswerDetailList adl in tfUI.flowLayoutPanel1.Controls)
                {
                    answerID += adl.AnswerID + ",";
                    isTrue += (adl.IsChecked == true ? 1 : 0) + ",";
                    if(adl.TextBoxText.Trim() == "")
                        throw new Exception("Không được để trống trường thông tin");
                    answerDetail += adl.TextBoxText.Trim() + ",";
                }

                int rowAffect = await MainFormQuizAppBus.Instance.UpdateQuestionAndAnswer(
                    question.QuestionID, questionDetail, subjectName, difficultName, isTest,
                    answerID, answerDetail, isTrue
                );

                if (rowAffect > 0)
                {
                    MessageBox.Show(
                         "Sửa câu hỏi thành công",
                         "Information",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information
                    );
                    guna2HtmlLabel3.Text = $"Lần cập nhật gần nhất: {DateTime.Now}";
                }

                guna2Button1.Enabled = true;
                guna2Button2.Enabled = false;

                guna2ComboBox4.Enabled = false;
                guna2ComboBox3.Enabled = false;
                guna2ComboBox2.Enabled = false;
                guna2ComboBox5.Enabled = false;
                tfUI.guna2TextBox1.Enabled = false;

                foreach (AnswerDetailList adl in tfUI.flowLayoutPanel1.Controls)
                {
                    adl.guna2TextBox1.Enabled = false;
                    adl.guna2RadioButton1.Enabled = false;
                    adl.EnableEvent = 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Sửa câu hỏi thất bại: {ex.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }    

        }
    }
}
