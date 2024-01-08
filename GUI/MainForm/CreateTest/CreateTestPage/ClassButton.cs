using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MainForm.QuestionSetManage.QuestionSetManagePage
{
    public partial class ClassButton : UserControl
    {
        public ClassButton()
        {
            InitializeComponent();
        }

        private int classID;
        private string className;
        private bool isChecked;

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        public int ClassID
        {
            get => classID;
            set => classID = value;
        }
        public string ClassName
        {
            get => className;
            set
            {
                className = value;
                guna2Button1.Text = value;
            }
        }

        public bool IsChecked { 
            get { 
               return guna2Button1.Checked; 
            } 
            set => isChecked = value; 
        }
    }
}
