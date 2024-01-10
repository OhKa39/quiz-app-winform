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
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;
using GUI.MainFormQuizApp;
using Microsoft.IdentityModel.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GUI.MainForm.Practice.TrainingPage
{

    public partial class trainingUC : UserControl
    {
        AccountResponse acc;
        public trainingUC(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private async void trainingUC_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;

            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    guna2ComboBox4.Items.Add(i["BookName"]);
                }
            }

            QuestionSetList uc = new QuestionSetList(acc);
            uc.Type = 4;
            guna2Panel2.Controls.Add(uc);
        }

        private async void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.Text == "--Sách--")
            {
                guna2ComboBox3.SelectedIndex = 0;
                return;
            }

            try
            {
                DataTable subject = await MainFormQuizAppBus
                               .Instance
                               .loadSubjectByBookName(guna2ComboBox4.Text);

                if (subject.Rows.Count > 0)
                {
                    guna2ComboBox3.Items.Clear();
                    guna2ComboBox3.Items.Add("--Chủ đề--");
                    guna2ComboBox3.SelectedIndex = 0;
                    foreach (DataRow i in subject.Rows)
                    {
                        guna2ComboBox3.Items.Add(i["SubjectName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {ex.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                QuestionSetList qsl = null;
                foreach (Control item in guna2Panel2.Controls)
                {
                    if (item is QuestionSetList)
                    {
                        qsl = (QuestionSetList)item;
                        break;
                    }
                }

                if (guna2CheckBox1.Checked && guna2CheckBox2.Checked)
                    throw new Exception("Chỉ được chọn 1 trong 2");

                if (!guna2CheckBox1.Checked && !guna2CheckBox2.Checked)
                    throw new Exception("Phải chọn 1 trong 2");

                if (guna2CheckBox1.Checked)
                {
                    string subjectString = guna2ComboBox3.Text;
                    string questionCountString = guna2ComboBox2.Text;
                    string timeString = guna2ComboBox1.Text;

                    if (subjectString == "--Chủ đề--"
                        || questionCountString == "--Số câu hỏi--"
                        || timeString == "--Thời gian--")
                        throw new Exception("Không được để trống trường thông tin");

                    DataTable question = await MainFormQuizAppBus
                        .Instance.loadRandomQuestionbySubject(
                            subjectString,
                            Int32.Parse(questionCountString)
                        );

                    int questionCount = Int32.Parse(questionCountString);
                    int time = Int32.Parse(timeString);

                    if (question.Rows.Count != questionCount)
                        throw new Exception
                        (
                            "Chủ đề không có đủ câu hỏi, xin hãy giảm số" +
                            " lượng câu hỏi xuống!"
                        );

                    DialogResult dr = MessageBox.Show(
                        "Bạn có chắc muốn bắt đầu làm bài chứ?",
                        "Thông báo",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                    );
                    if (dr == DialogResult.Cancel)
                        return;

                    TestFormUI tfUI = new TestFormUI
                    (
                        2, time,
                        subjectString, questionCount
                    );
                    tfUI.Questions = question;
                    tfUI.IsTest = false;
                    tfUI.Acc = acc;
                    tfUI.FormParentCall = this;
                    tfUI.ShowDialog();
                    this.Refresh();
                }

                if (guna2CheckBox2.Checked)
                {
                    QuestionSetComponent item = null;
                    foreach (QuestionSetComponent qsc in qsl.FlowlayoutPanel1.Controls)
                    {
                        if (qsc.IsChecked)
                            item = qsc;
                    }

                    if (item == null)
                        throw new Exception("Không được để trống trường thông tin");

                    DialogResult dr = MessageBox.Show(
                        "Bạn có chắc muốn bắt đầu làm bài chứ?",
                        "Thông báo",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                    );
                    if (dr == DialogResult.Cancel)
                        return;

                    TestFormUI tfUI = new TestFormUI
                    (
                        2, Int32.Parse(item.Time), item.QuestionSetID,
                        item.QuestionSetName, Int32.Parse(item.QuestionNumber)
                    );
                    tfUI.IsTest = false;
                    tfUI.Acc = acc;
                    tfUI.FormParentCall = this;
                    tfUI.ShowDialog();
                    this.Refresh();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {Ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}
