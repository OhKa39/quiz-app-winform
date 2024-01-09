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
using GUI.TestResult;

namespace GUI.MainForm.Practice.TrainingHistoryPage
{
    public partial class TrainingHistoryComponent : UserControl
    {
        public TrainingHistoryComponent()
        {
            InitializeComponent();
        }

        private string fullName;
        private int testLogID;
        private DateTime createAt;
        private int timeTaken;
        private string className;
        private AccountResponse acc;
        private string testSetName;
        private int totalQuestion;

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                guna2HtmlLabel6.Text = $"Học sinh: {value}";
            }
        }
        public int TestLogID
        {
            get => testLogID;
            set
            {
                testLogID = value;
                guna2HtmlLabel1.Text = value.ToString();

            }
        }
        public DateTime CreateAt
        {
            get => createAt;
            set
            {
                createAt = value.ToLocalTime();
                guna2HtmlLabel5.Text = $"CreatedAt: {value.ToLocalTime()}";
            }
        }
        public int TimeTaken
        {
            get => timeTaken;
            set
            {
                timeTaken = value;
                guna2HtmlLabel3.Text = String.Format
                (
                    "Thời gian làm bài: {0:00}:{1:00}p",
                    (int)(value / 60),
                    value % 60
                ); 
            }
        }
        public string ClassName
        {
            get => className;
            set
            {
                className = value;
                guna2HtmlLabel4.Text = $"Lớp: {value}";
            }
        }

        public AccountResponse Acc { get => acc; set => acc = value; }
        public string TestSetName
        {
            get => testSetName;
            set
            {
                testSetName = value;
                guna2HtmlLabel2.Text = value;
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int? totalQuestion = await MainFormQuizAppBus
                .Instance.countAllQuestionInTestLog(TestLogID);

                TestResultForm trf = new TestResultForm();
                trf.Acc = acc;
                trf.QuestionCount = (int)totalQuestion;
                trf.TimeTaken = timeTaken;
                trf.TestSetName = TestSetName;
                trf.TestLogID = testLogID;
                trf.ShowDialog();
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
    }
}
