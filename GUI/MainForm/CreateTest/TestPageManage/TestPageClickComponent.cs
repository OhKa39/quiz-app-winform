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
using GUI.MainForm.QuestionSetManage.QuestionSetDivPage;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;

namespace GUI.MainForm.CreateTest.TestPageManage
{
    public partial class TestPageClickComponent : UserControl
    {
        private int testSetID;
        AccountResponse acc;
        int totalTime;
        int questionCount;
        string testSetName;
        public TestPageClickComponent(AccountResponse _acc, int _testSetID)
        {
            acc = _acc;
            testSetID = _testSetID;
            InitializeComponent();
        }

        public int TestSetID { get => testSetID; set => testSetID = value; }
        public int TotalTime { get => totalTime; set => totalTime = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public string TestSetName { get => testSetName; set => testSetName = value; }

        private async void TestPageClickComponent_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable QuestionID;
                string questionSetID = "";
                QuestionID = await MainFormQuizAppBus
                    .Instance.findAllQuestionSetIDinTestSet(testSetID);

                foreach (DataRow i in QuestionID.Rows)
                {
                    questionSetID += ((int)i["QuestionSetID"]).ToString() + ",";
                }
                if (questionSetID.Length > 0)
                {
                    questionSetID = questionSetID.Substring(0, questionSetID.Length - 1);
                }

                StudentComponent studentComponent = new StudentComponent();
                studentComponent.TestSetID = testSetID;
                studentComponent.TotalTime = totalTime;
                studentComponent.QuestionCount = questionCount;
                studentComponent.TestSetName = testSetName;
                studentComponent.Acc = acc;
                studentComponent.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(studentComponent);

                QuestionSetList qsl = new QuestionSetList(acc);
                qsl.QuestionSetID = questionSetID;
                qsl.Type = 2;
                qsl.Dock = DockStyle.Fill;
                guna2Panel2.Controls.Add(qsl);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                        $"Cập nhật dữ liệu thất bại: {Ex.Message}",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }
    }
}
