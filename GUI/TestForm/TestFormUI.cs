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
using GUI.TestForm;

namespace GUI.MainFormQuizApp
{
    public partial class TestFormUI : Form
    {
        private Question question;
        private int formStyle;
        public TestFormUI(int _formStyle, Question _question)
        {
            formStyle = _formStyle;
            question = _question;
            InitializeComponent();
        }

        private async void TestFormUI_Load(object sender, EventArgs e)
        {
            if (formStyle == 1)
            {
                QuestionDetailList qDL = new QuestionDetailList(question);
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
        }
    }
}
