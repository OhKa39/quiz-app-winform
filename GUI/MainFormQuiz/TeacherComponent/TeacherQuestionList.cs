using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MainFormQuiz.TeacherComponent
{
    public partial class TeacherQuestionList : UserControl
    {
        public TeacherQuestionList()
        {
            InitializeComponent();
        }

        private int questionID;
        private string questionDetail;
        private bool isOK;
        private bool isTest;
        private string difficultName;

        public int QuestionID
        {
            get => questionID;
            set
            {
                questionID = value;
                guna2HtmlLabel1.Text = value.ToString();
            }
        }
        public string QuestionDetail
        {
            get => questionDetail;
            set
            {
                questionDetail = value;
                guna2HtmlLabel2.Text = value.ToString();
            }
        }
        public bool IsOK
        {
            get => isOK;
            set
            {
                isOK = value;
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
                isTest = value;
                if (value == true)
                    guna2PictureBox2.Image = Properties.Resources.test1;
                else
                    guna2PictureBox2.Image = Properties.Resources.exercise1;
            }
        }
        public string DifficultName
        {
            get => difficultName;
            set
            {
                difficultName = value;
                guna2HtmlLabel3.Text = value;
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
