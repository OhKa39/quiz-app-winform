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
        public QuestionDetailList(Question _question)
        {
            question = _question;
            InitializeComponent();
        }

        private void QuestionDetailList_Load(object sender, EventArgs e)
        {
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.Text = question.DifficultName;
            guna2ComboBox2.Items.Add(question.SubjectName);
            guna2ComboBox2.Text = question.SubjectName;
            guna2ComboBox5.SelectedIndex = question.IsTest == true ? 2 : 1;
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
            TestFormUI tfUI = (TestFormUI)this.Parent.Parent;
            string subjectName = guna2ComboBox2.Text;
            bool isTest = guna2ComboBox5.Text == "Thi" ? true : false;
            string questionDetail = tfUI.guna2TextBox1.Text;
            string difficultName = guna2ComboBox3.Text;

            string answerID = "";
            string isTrue = "";
            string answerDetail = "";
            int cnt = tfUI.flowLayoutPanel1.Controls.Count;
            foreach (AnswerDetailList adl in tfUI.flowLayoutPanel1.Controls)
            {
                answerID += adl.AnswerID + ",";
                isTrue += (adl.IsChecked == true ? 1 : 0) + ",";
                answerDetail += adl.TextBoxText + ",";
            }

            int? rowAffect = await MainFormQuizAppBus.Instance.UpdateQuestionAndAnswer(
                question.QuestionID, questionDetail, subjectName, difficultName, isTest,
                answerID, answerDetail, isTrue
            );
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
            if (rowAffect == cnt)
            {
                MessageBox.Show(
                     "Sửa câu hỏi thành công",
                     "Information",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                );
                return;
            }

            MessageBox.Show(
                    "Sửa câu hỏi thất bại",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );

        }
    }
}
