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

namespace GUI.TestResult
{

    public partial class TestResultForm : Form
    {
        private AccountResponse acc;
        private int questionCount;
        private int testLogID;
        private string testSetName;
        private int timeTaken;
        public TestResultForm()
        {
            InitializeComponent();
        }

        public AccountResponse Acc
        {
            get => acc;
            set
            {
                acc = value;
                guna2HtmlLabel2.Text = acc.Fullname;
            }
        }
        public int QuestionCount
        {
            get => questionCount;
            set
            {
                questionCount = value;
            }
        }
        public int TestLogID { get => testLogID; set => testLogID = value; }
        public string TestSetName
        {
            get => testSetName;
            set
            {
                testSetName = value;
                guna2HtmlLabel4.Text = value;
            }
        }

        public int TimeTaken
        {
            get => timeTaken;
            set
            {
                timeTaken = value;
                guna2HtmlLabel10.Text = String.Format(
                    "{0:00}:{1:00}p",
                    (int)(value / 60),
                    value % 60
                );
            }
        }

        private async void TestResultForm_Load(object sender, EventArgs e)
        {
            int? scalar = await MainFormQuizAppBus
                .Instance.countTrueAnswerByTestLog(TestLogID);

            guna2HtmlLabel6.Text = $"{scalar}/{questionCount} câu";
            guna2HtmlLabel8.Text = $"{Math.Round((Decimal)((10 / (float)questionCount) * scalar), 2)}";
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = await MainFormQuizAppBus
                .Instance.loadAllQuestionFromTestLog(testLogID);

                TestFormUI tfUI = new TestFormUI(3);
                tfUI.QuestionCount = questionCount;
                tfUI.TestSetName = testSetName;
                foreach (DataRow dr in data.Rows)
                {
                    tfUI.Pairs.Add(new PairQuestion((int)dr["QuestionID"], dr["QuestionDetail"] as string));
                    tfUI.UserChoices.Add((int)(dr["AnswerID"]));
                }
                tfUI.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {ex.StackTrace} and {ex.Message}. Hãy thử lại sau",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
