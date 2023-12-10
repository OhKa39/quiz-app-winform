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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class TestForm : Form
    {
        private Account account;
        private int subjectChoose;
        private int questionType;
        private List<QuestionTest> questions = new List<QuestionTest>();
        private const int NUMBER_QUESTION = 2;
        private List<int> answer = new List<int>(NUMBER_QUESTION);
        private int page = 1;
        private int timeCount = 60 * 120;

        public TestForm(Account _account, int subjectChoose, int questionType)
        {
            InitializeComponent();
            account = _account;
            this.subjectChoose = subjectChoose;
            this.questionType = questionType;
        }

        #region OWN METHOD
        private void AutoBreakLineLabel(Label e, Panel panel)
        {
            // Calculate the number of lines needed based on the width of the panel
            int panelWidth = panel.ClientSize.Width;
            SizeF textSize = TextRenderer.MeasureText(e.Text, e.Font);
            int numLines = (int)Math.Ceiling(textSize.Width / panelWidth);

            // Adjust the label to break lines if needed
            e.Height = (int)Math.Ceiling(textSize.Height) * numLines;
        }

        public void loadQuestions()
        {
            DataTable data = TestFormBus
                .Instance
                .loadQuestionsTest(
                    NUMBER_QUESTION, 1, subjectChoose, questionType
                );

            if (data.Rows.Count < NUMBER_QUESTION)
            {
                MessageBox.Show(
                        "Kho dữ liệu chưa cập nhật. Hãy quay lại sau nhé",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );
                this.Hide();
                return;
            }

            foreach (var row in data.Rows)
            {
                QuestionTest question = new QuestionTest((DataRow)row);
                questions.Add(question);
            }
        }

        public void updateCurrentPage(int pageNum)
        {
            int pageNumber = pageNum - 1;
            label1.Text = questions[pageNumber].Description;
            label2.Text = questions[pageNumber].Answer1;
            label3.Text = questions[pageNumber].Answer2;
            label4.Text = questions[pageNumber].Answer3;
            label5.Text = questions[pageNumber].Answer4;

            //int trueAnswer = questions[pageNumber].TrueAnswer;
            //char v = 'A';
            //int option = (trueAnswer - 1 + (int)v);
            //System.Windows.Forms.RadioButton selectButton = panel3
            //        .Controls
            //        .OfType<System.Windows.Forms.RadioButton>()
            //        .FirstOrDefault(r => r.Text[0] == (char)option);
            //selectButton.Checked = true;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCount--;
            label6.Text = String.Format("{0:00}:{1:00}", timeCount / 60, timeCount % 60);
            if (timeCount <= 0)
            {
                timer1.Stop();
                MessageBox.Show(
                        "Đã hết thời gian làm bài. Bài làm sẽ tự động được lưu",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );
                this.Hide();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_SizeChanged(object sender, EventArgs e)
        {
            Label label = sender as Label;
            AutoBreakLineLabel(label, (Panel)label.Parent);
        }

        private void label2_SizeChanged(object sender, EventArgs e)
        {
            Label label = sender as Label;
            AutoBreakLineLabel(label, (Panel)label.Parent);
        }

        private void label3_SizeChanged(object sender, EventArgs e)
        {
            Label label = sender as Label;
            AutoBreakLineLabel(label, (Panel)label.Parent);
        }

        private void label4_SizeChanged(object sender, EventArgs e)
        {
            Label label = sender as Label;
            AutoBreakLineLabel(label, (Panel)label.Parent);
        }

        private void label5_SizeChanged(object sender, EventArgs e)
        {
            Label label = sender as Label;
            AutoBreakLineLabel(label, (Panel)label.Parent);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            label6.Text = String.Format("{0:00}:{1:00}", timeCount / 60, timeCount % 60);
            int labelX = (panel8.Width - label6.Width) / 2;
            int labelY = (panel8.Height - label6.Height) / 2 + 10;

            // Set the position of the label
            label6.Location = new System.Drawing.Point(labelX, labelY);
            timer1.Start();
            loadQuestions();
            updateCurrentPage(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                --page;
                updateCurrentPage(page);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page < NUMBER_QUESTION)
            {
                ++page;
                updateCurrentPage(page);
                return;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
