using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.MainForm.QuestionSet;
using GUI.MainFormQuizApp;
using Guna.UI2.WinForms;

namespace GUI.TestForm
{
    public partial class AnswerDetailList : UserControl
    {
        private int enableEvent = 1;
        private string label;
        private bool isChecked = false;
        private string textBoxText;
        private int answerID;
        private int type = 1;
        public AnswerDetailList()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => label;
            set { label = value; guna2RadioButton1.Text = value; }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                guna2RadioButton1.Checked = value;
            }
        }
        public string TextBoxText
        {
            get => guna2TextBox1.Text;
            set
            {
                textBoxText = value;
                guna2TextBox1.Text = value;
            }
        }

        public int AnswerID { get => answerID; set => answerID = value; }
        public int EnableEvent { get => enableEvent; set => enableEvent = value; }
        public int Type { get => type; set => type = value; }

        private void guna2RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (enableEvent == 1)
                return;

            IsChecked = guna2RadioButton1.Checked;
            if (IsChecked)
            {
                if (Type == 2)
                {
                    Control convert = this;
                    while (!(convert is MainFormQuizApp.TestFormUI))
                        convert = convert.Parent;
                    TestFormUI tfUI = (TestFormUI)convert;
                    tfUI.UserChoices[tfUI.CurrentQuestion] = AnswerID;

                    QuestionButtonList qbl = null;
                    foreach (Control temp in tfUI.Guna2Panel1.Controls)
                        if (temp is QuestionButtonList)
                        {
                            qbl = (QuestionButtonList)temp;
                            break;
                        }
                    QuestionButton qb = (QuestionButton)qbl.FlowLayoutPanel1.Controls[tfUI.CurrentQuestion];

                    if (!tfUI.Flags[tfUI.CurrentQuestion])
                    {
                        qb.State = 2; 
                    }
                }
                foreach (AnswerDetailList fk in Parent.Controls)
                {
                    if (!fk.Equals(this))
                    {
                        if (fk.IsChecked)
                            fk.IsChecked = false;
                    }
                }
            }
        }
    }
}
