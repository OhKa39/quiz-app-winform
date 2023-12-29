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
using GUI.MainFormQuizApp;
using GUI.TestForm;

namespace GUI.MainForm.TeacherPage
{
    public partial class TeacherQuestionList : UserControl
    {
        private Question question;
        public TeacherQuestionList()
        {
            question = new Question();
            InitializeComponent();
        }

        private int questionID;
        private string questionDetail;
        private bool isOK;
        private bool isTest;
        private string difficultName;
        private DateTime updateAt;
        private string subjectName;
        private bool choose;

        public int QuestionID
        {
            get => questionID;
            set
            {
                questionID = value;
                guna2HtmlLabel1.Text = value.ToString();
                question.QuestionID = value;
            }
        }
        public string QuestionDetail
        {
            get => questionDetail;
            set
            {
                questionDetail = value;
                guna2HtmlLabel2.Text = value.ToString();
                question.QuestionDetail = value;
            }
        }
        public bool IsOK
        {
            get => isOK;
            set
            {
                isOK = value;
                question.IsOK = value;
                if (value == true)
                    guna2PictureBox1.Image = Properties.Resources.checked1;
                else
                    guna2PictureBox1.Image = Properties.Resources.warning;
            }
        }
        public bool IsTest
        {
            get => isTest;
            set
            {
                question.IsTest = value;
                isTest = value;
                if (value == true)
                    guna2PictureBox2.Image = Properties.Resources.checklist;
                else
                    guna2PictureBox2.Image = Properties.Resources.exercise;
            }
        }
        public string DifficultName
        {
            get => difficultName;
            set
            {
                question.DifficultName = value;
                difficultName = value;
                if (value == "Dễ")
                    guna2PictureBox3.Image = Properties.Resources.one_star;
                else if (value == "Trung bình")
                    guna2PictureBox3.Image = Properties.Resources._3_stars;
                else
                    guna2PictureBox3.Image = Properties.Resources._5stars;
                //guna2HtmlLabel3.Text = value;
            }
        }

        public DateTime UpdateAt
        {
            get => updateAt;
            set { updateAt = value; question.UpdateAt = value; }
        }
        public string SubjectName
        {
            get => subjectName;
            set { subjectName = value; question.SubjectName = value; }
        }
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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            GUI.MainFormQuizApp.TestFormUI tfUI = new GUI.MainFormQuizApp.TestFormUI(1, question);
            tfUI.ShowDialog();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            GUI.MainFormQuizApp.TestFormUI tfUI = new GUI.MainFormQuizApp.TestFormUI(1, question);
            tfUI.ShowDialog();

        }

        private void TeacherQuestionList_Click(object sender, EventArgs e)
        {
            GUI.MainFormQuizApp.TestFormUI tfUI = new GUI.MainFormQuizApp.TestFormUI(1, question);
            tfUI.ShowDialog();
        }
    }
}
