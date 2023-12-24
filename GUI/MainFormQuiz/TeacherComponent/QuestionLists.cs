using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.MainFormQuiz.Teacher
{
    public partial class QuestionLists : UserControl
    {
        private string label;
        private bool isChecked = false;
        private string textBoxText;
        public QuestionLists()
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
            get => guna2TextBox1.Text; set => textBoxText = value;
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            IsChecked = guna2RadioButton1.Checked;
            if (IsChecked)
            {
                foreach (QuestionLists fk in Parent.Controls)
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
