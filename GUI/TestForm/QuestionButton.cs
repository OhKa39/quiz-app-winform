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
using Guna.UI2.WinForms;

namespace GUI.TestForm
{
    public partial class QuestionButton : UserControl
    {
        private int index;
        private bool isCheckPoint = false;
        private bool isTrue;
        public QuestionButton()
        {
            InitializeComponent();
        }

        public bool IsCheckPoint { get => isCheckPoint; set => isCheckPoint = value; }
        public bool IsTrue { 
            get => isTrue;
            set {
                isTrue = value;
                guna2Button1.FillColor = (value == true) ? Color.Lime : Color.IndianRed;
                guna2Button1.ForeColor = Color.White;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Control convert = this;
            while (!(convert is MainFormQuizApp.TestFormUI))
                convert = convert.Parent;
            TestFormUI tfUI = (TestFormUI)convert;
            tfUI.CurrentQuestion = Index;
            tfUI.updateGUI();
        }
    }
}
