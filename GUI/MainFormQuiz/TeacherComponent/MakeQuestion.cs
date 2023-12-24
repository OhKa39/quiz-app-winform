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
using GUI.MainFormQuiz.Teacher;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainFormQuiz.TeacherComponent
{
    public partial class MakeQuestion : UserControl
    {
        public MakeQuestion()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            if (guna2ComboBox1.Text == "--Số đáp án--")
                return;
            int numQues = Int32.Parse(guna2ComboBox1.Text);
            QuestionLists[] questionlist = new QuestionLists[numQues];

            for (int i = 0; i < numQues; ++i)
            {
                char B = (char)('A' + i);
                questionlist[i] = new QuestionLists();
                questionlist[i].Label = $"{B}";
                flowLayoutPanel2.Controls.Add(questionlist[i]);
            }
        }

        private async void MakeQuestion_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            PanelScrollHelper flowpan = new PanelScrollHelper(flowLayoutPanel2, guna2vScrollBar1, true);
            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    guna2ComboBox4.Items.Add(i["BookName"]);
                }
            }
        }

        private async void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.Text == "--Sách--")
            {
                guna2ComboBox2.SelectedIndex = 0;
                return;
            }
            DataTable subject = await MainFormQuizAppBus.Instance.loadSubjectByBookName(guna2ComboBox4.Text);
            if (subject.Rows.Count > 0)
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("--Chủ đề--");
                guna2ComboBox2.SelectedIndex = 0;
                foreach (DataRow i in subject.Rows)
                {
                    guna2ComboBox2.Items.Add(i["SubjectName"]);
                }
            }
        }
    }
}
