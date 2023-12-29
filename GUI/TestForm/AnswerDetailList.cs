using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.MainForm.TeacherPage;

namespace GUI.TestForm
{
    public partial class AnswerDetailList : UserControl
    {
        private int enableEvent = 1;
        private string label;
        private bool isChecked = false;
        private string textBoxText;
        private int answerID;
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

        private void guna2RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (enableEvent == 1)
                return;
            IsChecked = guna2RadioButton1.Checked;
            if (IsChecked)
            {
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
