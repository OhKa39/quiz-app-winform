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

namespace GUI.MainForm.QuestionSet.QuestionPage
{
    public partial class MakeQuestion : UserControl
    {
        private AccountResponse acc;


        public MakeQuestion(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

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

            questionlist[0].IsChecked = true;
        }

        private async void MakeQuestion_Load(object sender, EventArgs e)
        {
            QuestionListComponent qlq = new QuestionListComponent(acc);
            qlq.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Add(qlq);
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox5.SelectedIndex = 0;
            PanelScrollHelper flowpan1 = new PanelScrollHelper(
                    flowLayoutPanel2, guna2vScrollBar1, true
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

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string questionDetail = guna2TextBox1.Text.Trim();
                string subjectName = guna2ComboBox2.SelectedItem as string;
                string difficultName = guna2ComboBox3.SelectedItem as string;
                string isTest = guna2ComboBox5.SelectedItem as string;
                if
                (
                   questionDetail == "" || subjectName == "--Chủ đề--"
                   || difficultName == "--Độ khó--" || isTest == "--Dạng--"
                )
                {
                    throw new Exception(
                         "Không được bỏ trống bất kì trường thông tin nào"
                    );
                }

                string answerDetail = "";
                string isTrue = "";
                foreach (QuestionLists control in flowLayoutPanel2.Controls)
                {
                    if (control.TextBoxText.Trim() == "")
                    {
                        throw new Exception(
                         "Không được bỏ trống bất kì trường thông tin nào"
                        );
                    }
                    answerDetail = answerDetail + control.TextBoxText.Trim() + ",";
                    isTrue = isTrue + (control.IsChecked == true ? "1" : "0") + ",";
                }

                int count = await MainFormQuizAppBus
                .Instance
                .createQuestionAndAnswerByUserID(
                    questionDetail, subjectName, difficultName,
                    isTest, acc.AccountID, answerDetail, isTrue
                );

                if (count > 0)
                {
                    MessageBox.Show(
                         $"Thêm câu hỏi thành công",
                         "Thành công",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information
                    );

                    guna2ComboBox1.SelectedIndex = 0;
                    guna2ComboBox4.SelectedIndex = 0;
                    guna2ComboBox3.SelectedIndex = 0;
                    guna2ComboBox2.SelectedIndex = 0;
                    guna2ComboBox5.SelectedIndex = 0;
                    guna2TextBox1.Text = "";


                    foreach (var i in guna2Panel2.Controls)
                    {
                        QuestionListComponent qlq = (QuestionListComponent)i;
                        qlq.updateData();
                        break;
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(
                    $"Thêm câu hỏi thất bại: {er.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

    }
}
