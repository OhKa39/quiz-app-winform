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
using GUI.TestResult;
using Guna.UI2.WinForms;

namespace GUI.MainForm.CreateTest.TestPageManage
{
    public partial class StudentC : UserControl
    {
        public StudentC()
        {
            InitializeComponent();
        }

        private int testLogID;
        private string fullName;
        private DateTime createdAt;
        private int timeTaken;
        private string className;
        AccountResponse acc;
        private int questionCount;
        private string testSetName;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TestResultForm trf = new TestResultForm();
            trf.Acc = acc;
            trf.QuestionCount = QuestionCount;
            trf.TimeTaken = timeTaken;
            trf.TestSetName = TestSetName;
            trf.TestLogID = testLogID;
            trf.ShowDialog();
        }

        public int TestLogID
        {
            get => testLogID;
            set
            {
                guna2HtmlLabel1.Text = value.ToString();
                testLogID = value;
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                guna2HtmlLabel2.Text = $"Học sinh: {value}";
                fullName = value;
            }
        }
        public DateTime CreatedAt
        {
            get => createdAt;
            set
            {
                guna2HtmlLabel3.Text = $"CreatedAt: {value}";
                createdAt = value;
            }
        }
        public int TimeTaken
        {
            get => timeTaken;
            set
            {
                guna2HtmlLabel4.Text = String.Format
                (
                    "Thời gian làm bài: {0:00}:{1:00}p",
                    (int)(value / 60),
                    value % 60
                );
                timeTaken = value;
            }
        }
        public string ClassName
        {
            get => className;
            set
            {
                guna2HtmlLabel5.Text = $"Lớp: {value}";
                className = value;
            }
        }

        public AccountResponse Acc { get => acc; set => acc = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public string TestSetName { get => testSetName; set => testSetName = value; }
    }
}
