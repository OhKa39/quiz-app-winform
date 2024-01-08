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
using GUI.MainForm.Home;
using GUI.TestForm;
using Guna.UI2.WinForms;

namespace GUI.MainFormQuizApp
{
    public partial class TestFormUI : Form
    {
        private Question question;
        private AccountResponse acc;
        private int formStyle;
        private int isEdit = -1;
        private int timeTaken;
        private int? testSetManageID = null;
        private int? questionsetID;
        private string testSetName;
        private int questionCount;
        private int timeConst;
        private List<int> userChoices;
        private List<PairQuestion> pairs = new List<PairQuestion>();
        private List<List<Answer>> answerOfAnswer = new List<List<Answer>>();
        private List<bool> flags;
        private int currentQuestion = 0;
        private int forceSent = -1;
        private bool isTest = false;
        private int alreadyClose = -1;
        private UserControl formParentCall;

        public TestFormUI(int _formStyle, Question _question)
        {
            FormStyle = _formStyle;
            question = _question;
            InitializeComponent();
        }

        public TestFormUI(
            int _formStyle, int _timeTaken, int? _questionsetID,
            string _testsetName, int _questionCount
        )
        {
            formStyle = _formStyle;
            timeTaken = _timeTaken * 60;
            questionsetID = _questionsetID;
            TestSetName = _testsetName;
            questionCount = _questionCount;
            InitializeComponent();
        }

        public TestFormUI(int _formStyle)
        {
            userChoices = new List<int>();
            FormStyle = _formStyle;
            InitializeComponent();
        }

        public int IsEdit { get => isEdit; set => isEdit = value; }
        public int TimeTaken { get => timeTaken; set => timeTaken = value * 60; }
        public int? QuestionsetID { get => questionsetID; set => questionsetID = value; }
        public AccountResponse Acc { get => acc; set => acc = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public int FormStyle { get => formStyle; set => formStyle = value; }
        public List<int> UserChoices { get => userChoices; set => userChoices = value; }
        public int CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public List<bool> Flags { get => flags; set => flags = value; }
        public int ForceSent { get => forceSent; set => forceSent = value; }
        public bool IsTest { get => isTest; set => isTest = value; }
        public int? TestSetManageID { get => testSetManageID; set => testSetManageID = value; }
        public int TimeConst { get => timeConst; set => timeConst = value; }
        public int AlreadyClose { get => alreadyClose; set => alreadyClose = value; }
        public string TestSetName { get => testSetName; set => testSetName = value; }
        public List<PairQuestion> Pairs { get => pairs; set => pairs = value; }
        public UserControl FormParentCall { get => formParentCall; set => formParentCall = value; }

        #region ownmethod
        public void updateGUI()
        {
            flowLayoutPanel1.Controls.Clear();
            int numAnswerIndex0 = answerOfAnswer[CurrentQuestion].Count;
            AnswerDetailList[] adl = new AnswerDetailList[numAnswerIndex0];
            guna2TextBox1.Text = Pairs[CurrentQuestion].QuestionName;

            int checkIndex = -1;
            for (int i = 0; i < numAnswerIndex0; ++i)
            {
                adl[i] = new AnswerDetailList();
                adl[i].TextBoxText = answerOfAnswer[CurrentQuestion][i].AnswerDetail;
                char B = (char)('A' + i);
                adl[i].Label = $"{B}";
                if(formStyle == 2)
                {
                    if (UserChoices[CurrentQuestion] == answerOfAnswer[CurrentQuestion][i].AnswerID)
                        checkIndex = i;
                    adl[i].guna2RadioButton1.Enabled = true;
                    adl[i].EnableEvent = -1;
                    adl[i].Type = 2;
                }            
                adl[i].AnswerID = answerOfAnswer[CurrentQuestion][i].AnswerID;
                if(formStyle == 3)
                {
                    adl[i].guna2RadioButton1.Enabled = false;
                    if (userChoices[CurrentQuestion] == answerOfAnswer[CurrentQuestion][i].AnswerID && userChoices[CurrentQuestion] != 0)
                    {
                        adl[i].guna2TextBox1.DisabledState.FillColor = Color.MistyRose;
                    }
                    if (answerOfAnswer[CurrentQuestion][i].IsTrue)
                    {
                        Color abc = Color.FromArgb(221, 255, 221);
                        adl[i].IsChecked = true;
                        adl[i].guna2TextBox1.DisabledState.FillColor = abc;
                    }
                }
            }

            flowLayoutPanel1.Controls.AddRange(adl);

            if (checkIndex != -1)
                adl[checkIndex].IsChecked = true;
        }

        private void centerLabelInPanel()
        {
            int centerX1 = guna2Panel2.Width / 2 - guna2HtmlLabel2.Width / 2;
            int centerY1 = 0;
            guna2HtmlLabel2.Location = new System.Drawing.Point(centerX1, centerY1);
            int gap = 5;
            int centerX2 = guna2Panel2.Width / 2 - guna2HtmlLabel3.Width / 2;
            int centerY2 = centerY1 + guna2HtmlLabel3.Height + gap;

            guna2HtmlLabel3.Location = new System.Drawing.Point(centerX2, centerY2);
        }
        #endregion

        private async void TestFormUI_Load(object sender, EventArgs e)
        {
            if (FormStyle == 1)
            {
                QuestionDetailList qDL = new QuestionDetailList(question);
                qDL.StateIsEdit = IsEdit;
                qDL.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(qDL);
                guna2TextBox1.Text = question.QuestionDetail;
                DataTable dt = await MainFormQuizAppBus.Instance.loadAnswerByQuestionID(question.QuestionID);
                int numAnswer = dt.Rows.Count;
                AnswerDetailList[] adl = new AnswerDetailList[numAnswer];
                for (int i = 0; i < numAnswer; ++i)
                {
                    adl[i] = new AnswerDetailList();
                    adl[i].IsChecked = (bool)dt.Rows[i]["IsTrue"];
                    adl[i].TextBoxText = dt.Rows[i]["AnswerDetail"] as string;
                    char B = (char)('A' + i);
                    adl[i].Label = $"{B}";
                    adl[i].AnswerID = (int)dt.Rows[i]["AnswerID"];
                    //adl[i].guna2RadioButton1.Enabled = false;
                    flowLayoutPanel1.Controls.Add(adl[i]);
                }
            }

            if (FormStyle == 2)
            {
                TimeConst = timeTaken;
                UserChoices = new List<int>(new int[questionCount]);
                Flags = new List<bool>(new bool[questionCount]);
                timer1.Start();
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
                guna2Button1.Visible = true;
                guna2Panel2.Visible = true;
                guna2HtmlLabel1.Text = TestSetName;
                QuestionButtonList uc = new QuestionButtonList();
                uc.QuestionCount = questionCount;
                uc.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(uc);

                DataTable questions = await MainFormQuizAppBus
                    .Instance
                    .loadAllQuestionInQuestionSet(QuestionsetID);

                foreach (DataRow dr in questions.Rows)
                {
                    PairQuestion pq = new PairQuestion(dr);
                    Pairs.Add(pq);
                }

                Random random = new Random();
                int n = Pairs.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    PairQuestion value = Pairs[k];
                    Pairs[k] = Pairs[n];
                    Pairs[n] = value;
                }

                foreach (var pair in Pairs)
                {
                    List<Answer> ans = new List<Answer>();
                    DataTable answers = await MainFormQuizAppBus
                        .Instance.loadAnswerByQuestionID(pair.QuestionID);

                    foreach (DataRow dr in answers.Rows)
                    {
                        Answer ansobj = new Answer(dr);
                        ans.Add(ansobj);
                    }

                    //n = ans.Count;
                    //while (n > 1)
                    //{
                    //    n--;
                    //    int k = random.Next(n + 1);
                    //    Answer value = ans[k];
                    //    ans[k] = ans[n];
                    //    ans[n] = value;
                    //}

                    answerOfAnswer.Add(ans);
                }

                updateGUI();
            }

            if(FormStyle == 3)
            {
                foreach (var pair in Pairs)
                {
                    List<Answer> ans = new List<Answer>();
                    DataTable answers = await MainFormQuizAppBus
                        .Instance.loadAnswerByQuestionID(pair.QuestionID);

                    foreach (DataRow dr in answers.Rows)
                    {
                        Answer ansobj = new Answer(dr);
                        ans.Add(ansobj);
                    }
                    answerOfAnswer.Add(ans);
                }
                guna2Button3.Visible = true;
                guna2Button1.Visible = true;
                guna2HtmlLabel1.Text = TestSetName;
                QuestionButtonList uc = new QuestionButtonList();
                uc.IsTest = 1;
                uc.QuestionCount = questionCount;
                uc.UserChoices = UserChoices;
                uc.AnswerOfAnswer = answerOfAnswer;
                uc.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(uc);
                updateGUI();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CurrentQuestion == questionCount - 1)
                return;
            ++CurrentQuestion;

            updateGUI();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (CurrentQuestion == 0)
                return;
            --CurrentQuestion;

            updateGUI();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeTaken <= 0)
            {
                timer1.Stop();
                forceSent = 1;
                return;
            }
            --timeTaken;
            guna2HtmlLabel3.Text = String.Format("{0:00}:{1:00}", (int)(timeTaken / 60), timeTaken % 60);
            centerLabelInPanel();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            QuestionButtonList qbl = (QuestionButtonList)guna2Panel1.Controls[1];
            QuestionButton qb = (QuestionButton)qbl.FlowLayoutPanel1.Controls[currentQuestion];
            if (!Flags[currentQuestion])
            {
                Flags[currentQuestion] = true;
                qb.Guna2Button1.FillColor = Color.IndianRed;
                qb.Guna2Button1.ForeColor = Color.White;
                return;
            }

            Flags[currentQuestion] = false;
            if (userChoices[currentQuestion] != 0)
            {
                qb.Guna2Button1.FillColor = Color.Lime;
                qb.Guna2Button1.ForeColor = Color.White;
                return;
            }

            qb.Guna2Button1.FillColor = Color.White;
            qb.Guna2Button1.ForeColor = Color.Black;
        }

        private void TestFormUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (formStyle != 2)
                return;
            if (AlreadyClose == 1)
            {
                ((TestListComponent)FormParentCall).checkState();
                return;
            }

            ((TestListComponent)FormParentCall).checkState();
            QuestionButtonList qbl = (QuestionButtonList)guna2Panel1.Controls[1];
            qbl.Guna2Button1.PerformClick();

            if(forceSent == -1)
                if (qbl.Guna2Button1DialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            timer1.Stop();
        }
    }
}
