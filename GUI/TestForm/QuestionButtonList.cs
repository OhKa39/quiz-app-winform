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
using Guna.UI2.WinForms.Helpers;
using Microsoft.Identity.Client;

namespace GUI.TestForm
{
    public partial class QuestionButtonList : UserControl
    {
        private int questionCount;
        private int isTest = -1;
        private List<int> userChoices;
        private List<List<Answer>> answerOfAnswer = new List<List<Answer>>();
        public QuestionButtonList()
        {
            InitializeComponent();
        }

        private DialogResult guna2Button1DialogResult;

        public DialogResult Guna2Button1DialogResult
        {
            get { return guna2Button1DialogResult; }
            private set { guna2Button1DialogResult = value; }
        }

        private void AddButtonBelowLastItem()
        {
            Control lastItem = flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1];

            int panelCenterX = this.Width / 2;

            int distance = 75;
            int buttonX = panelCenterX - (guna2Button1.Width / 2);
            int buttonY = Math.Min(lastItem.Bottom + distance, 595);

            guna2Button1.Location = new System.Drawing.Point(buttonX, buttonY);
        }

        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public List<int> UserChoices { get => userChoices; set => userChoices = value; }
        public List<List<Answer>> AnswerOfAnswer { get => answerOfAnswer; set => answerOfAnswer = value; }
        public int IsTest { get => isTest; set => isTest = value; }

        private void QuestionButtonList_Load(object sender, EventArgs e)
        {
            if (IsTest == 1)
                guna2Button1.Visible = false;

            PanelScrollHelper flowpan1 = new PanelScrollHelper(
                        flowLayoutPanel1, guna2vScrollBar1, true
            );
            List<QuestionButton> btnList = new List<QuestionButton>();
            for (int i = 0; i < questionCount; ++i)
            {
                bool isOK = false;
                if (IsTest == 1)
                {
                    int numAnswerIndex0 = answerOfAnswer[i].Count;
                    for (int j = 0; j < numAnswerIndex0; ++j)
                        if (answerOfAnswer[i][j].AnswerID == userChoices[i] && answerOfAnswer[i][j].IsTrue)
                        {
                            isOK = true;
                            break;
                        }
                }

                var questionbtn = new QuestionButton()
                {
                    Index = i,
                };
                if (IsTest == 1)
                    questionbtn.IsTrue = isOK;
                btnList.Add(questionbtn);
            }

            flowLayoutPanel1.Controls.AddRange(btnList.ToArray());
            AddButtonBelowLastItem();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            Control convert = this;
            while (!(convert is MainFormQuizApp.TestFormUI))
                convert = convert.Parent;
            TestFormUI tfUI = (TestFormUI)convert;

            string userAnswer = "";
            bool isFullFill = true;

            foreach (int choice in tfUI.UserChoices)
            {
                if (choice == 0)
                {
                    isFullFill = false;
                }

                userAnswer += choice.ToString() + ",";
            }

            foreach (bool flag in tfUI.Flags)
            {
                if (flag)
                {
                    isFullFill = false;
                    break;
                }
            }

            bool ok = false;

            if (tfUI.ForceSent != 1)
            {
                if (!isFullFill)
                {
                    Guna2Button1DialogResult =
                       MessageBox.Show(
                           "Bạn còn câu hỏi chưa làm hoặc đang cắm cờ. Bạn chắc chắn muốn nộp bài chứ?",
                           "Confirmation",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Information
                       );

                    if (Guna2Button1DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    if (Guna2Button1DialogResult == DialogResult.OK)
                    {
                        ok = true;
                    }
                }

                if (!ok)
                {
                    Guna2Button1DialogResult =
                           MessageBox.Show(
                               "Bạn chắc chắn muốn nộp bài chứ?",
                               "Confirmation",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Information
                           );

                    if (Guna2Button1DialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            try
            {
                int? testSetManageID = tfUI.TestSetManageID;
                bool isTest = tfUI.IsTest;
                int accoutID = tfUI.Acc.AccountID;
                int timeTaken = tfUI.TimeConst - tfUI.TimeTaken;

                string questionID = "";
                foreach (var item in tfUI.Pairs)
                {
                    questionID += item.QuestionID.ToString() + ",";
                }

                int? rowAffect = await MainFormQuizAppBus
                    .Instance
                    .createTestLog(accoutID, isTest, userAnswer, questionID, timeTaken, testSetManageID);

                if (rowAffect != null)
                {
                    int testLogID = (int)rowAffect;
                    TestResultForm trf = new TestResultForm();
                    trf.Acc = tfUI.Acc;
                    trf.FullName = tfUI.Acc.Fullname;
                    trf.QuestionCount = QuestionCount;
                    trf.TimeTaken = timeTaken;
                    trf.TestSetName = tfUI.TestSetName;
                    trf.TestLogID = testLogID;
                    tfUI.AlreadyClose = 1;
                    tfUI.Close();
                    trf.Show();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra khi nộp bài: {ex.StackTrace}. Hãy thử lại sau",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
