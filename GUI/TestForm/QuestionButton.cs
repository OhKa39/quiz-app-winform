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
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;
using GUI.MainFormQuizApp;
using Guna.UI2.WinForms;

namespace GUI.TestForm
{
    public partial class QuestionButton : UserControl
    {
        private int index;
        private bool isCheckPoint = false;
        private bool isTrue;
        private bool isChecked;
        private int isAnswer = -1;
        private int state = 1;
        public QuestionButton()
        {
            InitializeComponent();
        }

        public bool IsCheckPoint { get => isCheckPoint; set => isCheckPoint = value; }
        public bool IsTrue
        {
            get => isTrue;
            set
            {
                isTrue = value;
                guna2Button1.FillColor = (value == true) ? Color.Lime : Color.IndianRed;
                Guna2Button1.ForeColor = Color.White;
            }
        }
        public int Index
        {
            get => index;
            set
            {
                index = value;
                guna2Button1.Text = (value + 1).ToString();
            }
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
                if (guna2Button1.Checked != value)
                    guna2Button1.Checked = value;
            }
        }

        public int State { get => state; set => state = value; }
        public int IsAnswer { get => isAnswer; set => isAnswer = value; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Control convert = this;
            while (!(convert is MainFormQuizApp.TestFormUI))
                convert = convert.Parent;
            TestFormUI tfUI = (TestFormUI)convert;
            tfUI.CurrentQuestion = Index;
            tfUI.updateGUI();
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            IsChecked = guna2Button1.Checked;
            if (IsChecked)
            {
                Control convert = this;
                while (!(convert is MainFormQuizApp.TestFormUI))
                    convert = convert.Parent;
                TestFormUI tfUI = (TestFormUI)convert;
                tfUI.CurrentQuestion = Index;
                tfUI.updateGUI();

                foreach (QuestionButton fk in Parent.Controls)
                {
                    if (!fk.Equals(this))
                    {
                        if (fk.IsChecked)
                        {
                            fk.IsChecked = false;

                            if (isAnswer == 1)
                                return;

                            switch (fk.State)
                            {
                                case 1:
                                    fk.Guna2Button1.FillColor = Color.White;
                                    fk.Guna2Button1.ForeColor = Color.Black;
                                    break;
                                case 2:
                                    fk.Guna2Button1.FillColor = Color.Lime;
                                    fk.Guna2Button1.ForeColor = Color.White;
                                    break;
                                case 3:
                                    fk.Guna2Button1.FillColor = Color.IndianRed;
                                    fk.Guna2Button1.ForeColor = Color.White;
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
