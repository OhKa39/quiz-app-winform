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
using GUI.MainForm.QuestionSet;
using GUI.MainForm.QuestionSet.QuestionTestPage;
using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSetManage.QuestionSetDivPage
{
    public partial class QuestionPopUp : Form
    {
        private int questionID;
        public QuestionPopUp(int _questionID)
        {
            questionID = _questionID;
            InitializeComponent();
        }

        private async void QuestionPopUp_Load(object sender, EventArgs e)
        {
            QuestionListComponentQS qlcqs = new QuestionListComponentQS();
            qlcqs.IsEdit = -1;
            qlcqs.Type = 1;
            DataTable questionIDs = await MainFormQuizAppBus
                    .Instance
                    .findQuestionIDinQuestionSet(questionID);
            string questionIDString = "";
            foreach (DataRow dr in questionIDs.Rows)
            {
                qlcqs.questionDict.Add((int)dr["QuestionID"], "");
                questionIDString += ((int)dr["QuestionID"]).ToString() + ",";
            }
            questionIDString = questionIDString.Substring(0, questionIDString.Length - 1);
            qlcqs.QuestionID = questionIDString;
            qlcqs.updateData();
            qlcqs.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(qlcqs);
        }
    }
}
