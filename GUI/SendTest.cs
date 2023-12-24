using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BUS;
using DTO;
using Microsoft.IdentityModel.Tokens;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI
{
    public partial class SendTest : Form
    {
        private AccountResponse account;
        private List<Subject> subjects = new List<Subject>();
        int isEdited = 1;
        int currentQuestionID;
        public SendTest(AccountResponse _account)
        {
            account = _account;
            InitializeComponent();
        }

        #region Own Method
        public void loadQuestions()
        {
        //    List<Question> questions = new List<Question>();
        //    DataTable data = SendTestBus
        //        .Instance
        //        .loadQuestionByUser(account.Username);
        //    foreach (var row in data.Rows)
        //    {
        //        Question question = new Question((DataRow)row);
        //        questions.Add(question);
        //    }
        //    dataGridView1.DataSource = questions;
        //}

        //public void loadSubjects()
        //{
        //    DataTable data = SendTestBus
        //        .Instance
        //        .loadSubject();
        //    foreach (var row in data.Rows)
        //    {
        //        Subject subject = new Subject((DataRow)row);
        //        subjects.Add(subject);
        //    }

        //    var listOfSubjectName = from subject in subjects
        //                            select subject.SubjectName1;

        //    comboBox1.DataSource = listOfSubjectName
        //        .ToList<string>();
        }

        public bool checkIsWrite()
        {
            List<TextBox> myTextBoxes = panel2.Controls
                 .OfType<Panel>()
                 .SelectMany(panel => panel.Controls.OfType<TextBox>()
                    .Where(textbox => string.IsNullOrWhiteSpace(textbox.Text)))
                 .ToList();

            return (
                myTextBoxes.Count != 5
            );
        }

        public bool checkIsEmpty()
        {
            List<TextBox> myTextBoxes = panel2.Controls
                 .OfType<Panel>()
                 .SelectMany(panel => panel.Controls.OfType<TextBox>()
                    .Where(textbox => string.IsNullOrWhiteSpace(textbox.Text)))
                 .ToList();

            return myTextBoxes.Count > 0;
        }

        public void blankTextBox()
        {
            List<TextBox> myTextBoxes = panel2.Controls
                .OfType<Panel>()
                .SelectMany(panel => panel.Controls.OfType<TextBox>())
                .ToList();

            foreach(var i in myTextBoxes)
                i.Text = "";
        }

        public object[] questionAttribute()
        {
            string question = textBox5.Text.Trim();
            string answer1 = textBox1.Text.Trim();
            string answer2 = textBox2.Text.Trim();
            string answer3 = textBox4.Text.Trim();
            string answer4 = textBox3.Text.Trim();
            var selectSubject = from subject in subjects
                                where subject.SubjectName1 == comboBox1.Text
                                select subject.SubjectID1;

            var selectButton = panel4
                .Controls
                .OfType<System.Windows.Forms.RadioButton>()
                .FirstOrDefault(r => r.Checked).Text;

            char v = selectButton.ToString()[0];
            int questionType = comboBox2.SelectedIndex;
            int subjectChoose = selectSubject.ToList<int>()[0];
            int trueAnswer = v - 'A' + 1;
            return new object[] { 
                question, answer1, answer2, answer3,
                answer4, subjectChoose, trueAnswer, questionType
            };
        }
        #endregion


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //if(isEdited == 1)
        //{
        //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
        //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
        //    bool isOK = (bool)selectedRow.Cells["IsOK"].Value;
        //    if (isOK)
        //    {
        //        MessageBox.Show(
        //            "Không thể sửa câu hỏi này!!!",
        //            "Thông báo",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error
        //        );
        //        return;
        //    }

        //    isEdited *= -1;
        //    button2.Enabled = false;
        //    button3.Text = "Xác nhận";

        //    textBox5.Text = selectedRow.Cells["Description"].Value as string;
        //    textBox1.Text = selectedRow.Cells["Answer1"].Value as string;
        //    textBox2.Text = selectedRow.Cells["Answer2"].Value as string;
        //    textBox4.Text = selectedRow.Cells["Answer3"].Value as string;
        //    textBox3.Text = selectedRow.Cells["Answer4"].Value as string;

        //    int trueAnswer = (int)selectedRow.Cells["TrueAnswer"].Value;
        //    char v = 'A';
        //    int option = (trueAnswer - 1 + (int)v);
        //    bool questionType = (bool)selectedRow.Cells["QuestionType"].Value;
        //    currentQuestionID = (int)selectedRow.Cells["QuestionID"].Value;

        //    comboBox2.SelectedIndex = questionType ? 1 : 0;
        //    System.Windows.Forms.RadioButton selectButton = panel4
        //        .Controls
        //        .OfType<System.Windows.Forms.RadioButton>()
        //        .FirstOrDefault(r => r.Text[0] == (char)option);
        //    selectButton.Checked = true;


        //}
        //else
        //{
        //    isEdited *= -1;
        //    button2.Enabled = true;
        //    button3.Text = "Sửa";
        //    object[] data = questionAttribute();

        //    int count = SendTestBus
        //        .Instance
        //        .updateQuestion(
        //            data[0] as string,
        //            data[1] as string,
        //            data[2] as string,
        //            data[3] as string,
        //            data[4] as string,
        //            (int)data[5],
        //            (int)data[6],
        //            (int)data[7],
        //            currentQuestionID
        //        );

        //    if (count > 0)
        //    {
        //        MessageBox.Show(
        //            "Sửa câu hỏi thành công",
        //            "Thông báo",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information
        //        );
        //        blankTextBox();
        //        loadQuestions();
        //    }
        //    else
        //    {
        //        MessageBox.Show(
        //            "Sửa câu hỏi thất bại",
        //            "Thông báo",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error
        //        );
        //    }
        //    }
        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void SendTest_Load(object sender, EventArgs e)
        //{
        //    //loadQuestions();
        //    //loadSubjects();
        //    //dataGridView1.ReadOnly = true;
        //    //comboBox2.Text = "Luyện tập";
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if(!checkIsEmpty())
        //    {
        //        object[] data = questionAttribute();

        //        int count = SendTestBus
        //            .Instance
        //            .addQuestion(
        //                data[0] as string, 
        //                data[1] as string, 
        //                data[2] as string, 
        //                data[3] as string, 
        //                data[4] as string,
        //                (int)data[5],
        //                (int)data[6],
        //                (int)data[7], 
        //                account.AccountID
        //            );

        //        if (count > 0)
        //        {
        //            MessageBox.Show(
        //                "Thêm câu hỏi thành công",
        //                "Thông báo",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information
        //            );
        //            blankTextBox();
        //            loadQuestions();
        //        }
        //        else
        //        {
        //            MessageBox.Show(
        //                "Thêm câu hỏi thất bại",
        //                "Thông báo",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error
        //            );
        //        }
        //    }
        //    else
        //        MessageBox.Show(
        //                "Tồn tại trường giá trị chưa điền",
        //                "Thông báo",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error
        //            );
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //if (checkIsWrite())
        //{
        //    DialogResult dr = MessageBox.Show(
        //        "Chưa lưu câu hỏi. Bạn có muốn thoát chứ?",
        //        "Thông báo",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question
        //    );

        //    if (dr == DialogResult.Yes)
        //    {
        //        this.Hide();
        //    }
        //}
        //else
        //    this.Hide();
        //}
    }
}
