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

namespace GUI.MainForm.CreateTest.TestPageManage
{
    public partial class TestPageClick : Form
    {
        private int testSetID;
        AccountResponse acc;
        int questionCount;
        int totalTime;
        string testSetName;
        public TestPageClick(AccountResponse _acc, int _testSetID)
        {
            acc = _acc;
            testSetID = _testSetID;
            InitializeComponent();
        }

        public int TestSetID { get => testSetID; set => testSetID = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public int TotalTime { get => totalTime; set => totalTime = value; }
        public string TestSetName { get => testSetName; set => testSetName = value; }

        private void TestPageClick_Load(object sender, EventArgs e)
        {
            TestPageClickComponent tpcc = new TestPageClickComponent(acc, testSetID);
            tpcc.TotalTime = totalTime;
            tpcc.QuestionCount = questionCount;
            tpcc.TestSetName = testSetName;
            tpcc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(tpcc);
        }
    }
}
