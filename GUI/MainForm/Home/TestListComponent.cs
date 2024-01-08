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
using GUI.TestResult;

namespace GUI.MainForm.Home
{
    public partial class TestListComponent : UserControl
    {
        private AccountResponse acc;
        public TestListComponent()
        {
            InitializeComponent();
        }

        private int testSetID;
        private string testSetName;
        private int questionCount;
        private string currentStudyYear;
        private int time;
        private int alreadyDoTest = -1;
        DataTable testLog;

        #region ownmethod
        public async void checkState()
        {
            try
            {
                testLog = await MainFormQuizAppBus
                    .Instance
                    .findTestLogByTestSetID(testSetID, acc.AccountID);

                if (testLog.Rows.Count > 0)
                {
                    guna2Button1.Text = "Xem lại";
                    alreadyDoTest = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {ex.Message}. Hãy thử lại sau",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        #endregion

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            if(alreadyDoTest == 1)
            {
                try
                {
                    
                    TestResultForm trf = new TestResultForm();
                    trf.Acc = acc;
                    trf.QuestionCount = QuestionCount;
                    trf.TimeTaken = (int)testLog.Rows[0]["TimeTaken"];
                    trf.TestSetName = testSetName;
                    trf.TestLogID = (int)testLog.Rows[0]["TestLogID"];
                    trf.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Đã có lỗi xảy ra: {ex.Message}. Hãy thử lại sau",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return;
            }

            try
            {
                int? quesTionID = await MainFormQuizAppBus
                    .Instance
                    .randomQuestionSet(testSetID);
                TestFormUI tfUI = new TestFormUI(2, time, quesTionID, testSetName, questionCount);
                tfUI.TestSetManageID = TestSetID;
                tfUI.IsTest = true;
                tfUI.Acc = acc;
                tfUI.FormParentCall = this;
                tfUI.AlreadyClose = 1;
                tfUI.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {ex.Message}. Hãy thử lại sau",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void TestListComponent_Load(object sender, EventArgs e)
        {
            checkState();
        }

        public int TestSetID
        {
            get => testSetID;
            set
            {
                testSetID = value;
                guna2HtmlLabel1.Text = value.ToString();
            }
        }
        public string TestSetName
        {
            get => testSetName;
            set
            {
                testSetName = value;
                guna2HtmlLabel2.Text = value + ": ";
            }
        }
        public int QuestionCount
        {
            get => questionCount;
            set
            {
                questionCount = value;
                guna2HtmlLabel2.Text += $"{value} câu hỏi";
            }
        }
        public string CurrentStudyYear
        {
            get => currentStudyYear;
            set
            {
                currentStudyYear = value;
                guna2HtmlLabel3.Text = value;
            }
        }

        public int Time
        {
            get => time;
            set
            {
                time = value;
                guna2HtmlLabel2.Text += $"{value} phút - ";
            }
        }

        public AccountResponse Acc { get => acc; set => acc = value; }
    }
}
