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
using GUI.MainForm.QuestionSet.QuestionPage;
using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSet.QuestionTestPage
{
    public partial class MakeQuestionSet : UserControl
    {

        private AccountResponse acc;
        public Guna2ProgressBar[] g2PB;
        public MakeQuestionSet(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
            g2PB = new Guna2ProgressBar[] { guna2ProgressBar1, guna2ProgressBar2, guna2ProgressBar3 };
        }

        private void MakeQuestionSet_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            Guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            QuestionListComponentQS qlq = new QuestionListComponentQS();
            qlq.Dock = DockStyle.Fill;
            qlq.Type = 1;
            guna2Panel2.Controls.Add(qlq);
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Guna2ComboBox2.Text == "--Số câu hỏi--")
                return;
            foreach (Guna2ProgressBar progess in g2PB)
            {
                progess.Minimum = 0;
                progess.Maximum = Int32.Parse(Guna2ComboBox2.Text);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                QuestionListComponentQS qlqs = (QuestionListComponentQS)guna2Panel2.Controls[0];
                if (guna2TextBox1.Text.Trim() == ""
                    || guna2ComboBox1.Text == "--Thời gian--"
                    || guna2ComboBox2.Text == "--Số câu hỏi--"
                    || guna2ComboBox3.Text == "--Dạng--"
                )
                {
                    throw new Exception(
                        "Không được bỏ trống bất kì trường thông tin nào"
                    );
                }

                if (Int32.Parse(guna2ComboBox2.Text) != qlqs.questionDict.Count)
                {
                    throw new Exception(
                        "Số lượng câu hỏi đã chọn không hợp lệ"
                    );
                }


                string questionID = "";
                foreach (var K in qlqs.questionDict)
                {
                    questionID += K.Key.ToString() + ",";
                }

                string questionSetName = guna2TextBox1.Text;
                int time = Int32.Parse(guna2ComboBox1.Text);
                int isTest = guna2ComboBox3.Text == "Thi" ? 1 : 0;
                int rowAffect = await MainFormQuizAppBus
                    .Instance
                    .createQuestionSet(
                        questionSetName, time, acc.AccountID, questionID, isTest
                    );
                if (rowAffect > 0)
                {
                    MessageBox.Show(
                       "Thêm bộ đề thành công",
                       "Thành công",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                     );
                }

                qlqs.questionDict.Clear();
                guna2TextBox1.Text = "";
                guna2ComboBox1.SelectedIndex = 0;
                Guna2ComboBox2.SelectedIndex = 0;
                guna2ComboBox3.SelectedIndex = 0;
                qlqs.Guna2HtmlLabel1.Text = "Số câu hỏi đã chọn: 0";
                qlqs.updateData();

                foreach (Guna2ProgressBar progess in g2PB)
                {
                    progess.Value = 0;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(
                    $"Thêm bộ đề thất bại: {er.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}
