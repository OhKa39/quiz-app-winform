using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using GUI.MainForm.QuestionSet.QuestionTestPage;

namespace GUI.MainForm.CreateTest.TestPageManage
{
    public partial class TestPageButtonComponent : UserControl
    {

        public TestPageButtonComponent()
        {
            InitializeComponent();
        }

        private int accountID;
        private string accountName;
        private int testSetID;
        private string testSetName;
        private DateTime createdAt;
        private int totalQuestion;
        private int time;
        private int hasInDict = -1;
        private bool choose;
        private AccountResponse acc;

        private void TestPageButtonComponent_Load(object sender, EventArgs e)
        {
            guna2CheckBox1.Checked = HasInDict == 1 ? true : false;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ManageTest mt = (ManageTest)Parent.Parent;

            if (guna2CheckBox1.Checked)
            {
                if (HasInDict == 1)
                    return;
                mt.TestSetDict.Add(testSetID, testSetName);
                mt.Guna2HtmlLabel1.Text = $"Số câu hỏi đã chọn: {mt.TestSetDict.Count}";
                HasInDict = 1;
                return;
            }
            else
            {
                mt.TestSetDict.Remove(testSetID);
                mt.Guna2HtmlLabel1.Text = $"Số câu hỏi đã chọn: {mt.TestSetDict.Count}";
                HasInDict = -1;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (TestPageClick tpc = new TestPageClick(Acc, TestSetID))
            {
                tpc.QuestionCount = totalQuestion;
                tpc.TotalTime = time;
                tpc.TestSetName = testSetName;
                tpc.ShowDialog();
            }
        }

        public int AccountID { get => accountID; set => accountID = value; }
        public string AccountName
        {
            get => accountName;
            set
            {
                accountName = value;
                guna2HtmlLabel6.Text = $"Được tạo bởi: {value}";
            }
        }
        public string TestSetName
        {
            get => testSetName;
            set
            {
                testSetName = value;
                guna2HtmlLabel2.Text = $"Bài thi: {value}";
            }
        }
        public DateTime CreatedAt
        {
            get => createdAt;
            set
            {
                createdAt = value;
                guna2HtmlLabel5.Text = $"Tạo vào: {value}";
            }
        }
        public int TotalQuestion
        {
            get => totalQuestion;
            set
            {
                totalQuestion = value;
                guna2HtmlLabel4.Text = $"Tổng số câu hỏi: {value}";
            }
        }
        public int Time
        {
            get => time;
            set
            {
                time = value;
                guna2HtmlLabel3.Text = String.Format
                (
                    "Thời gian: {0:00}p",
                    value
                ); ;
            }
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

        public int HasInDict { get => hasInDict; set => hasInDict = value; }
        public bool Choose
        {
            get
            {
                return guna2CheckBox1.Checked;
            }
            set
            {
                choose = value;
                guna2CheckBox1.Checked = value;
            }
        }

        public AccountResponse Acc { get => acc; set => acc = value; }
    }
}
