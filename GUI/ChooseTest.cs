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

namespace GUI
{
    public partial class ChooseTest : Form
    {
        private Account account;
        private List<Subject> subjects = new List<Subject>();
        public ChooseTest(Account _account)
        {
            InitializeComponent();
            account = _account;
        }

        #region OWN METHOD
        public void loadSubjects()
        {
            DataTable data = SendTestBus
                .Instance
                .loadSubject();
            foreach (var row in data.Rows)
            {
                Subject subject = new Subject((DataRow)row);
                subjects.Add(subject);
            }

            var listOfSubjectName = from subject in subjects
                                    select subject.SubjectName1;

            comboBox1.DataSource = listOfSubjectName
                .ToList<string>();
        }
        #endregion  

        private void ChooseTest_Load(object sender, EventArgs e)
        {
            loadSubjects();
            comboBox2.Text = "Luyện tập";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectSubject = from subject in subjects
                                where subject.SubjectName1 == comboBox1.Text
                                select subject.SubjectID1;
            int subjectChoose = selectSubject.ToList<int>()[0];
            int questionType = comboBox2.SelectedIndex;
            this.Hide();
            TestForm tf = new TestForm(account, subjectChoose, questionType);
            tf.ShowDialog();
            this.Show();
        }
    }
}
