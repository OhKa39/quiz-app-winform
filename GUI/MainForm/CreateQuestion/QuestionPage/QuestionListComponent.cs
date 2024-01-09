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
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainForm.QuestionSet.QuestionPage
{

    public partial class QuestionListComponent : UserControl
    {
        private AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        private FilterMember filtermember;
        private string searchBox = "";
        private int isTurnOn = -1;
        public QuestionListComponent(AccountResponse _acc)
        {
            acc = _acc;
            filtermember = new FilterMember();
            InitializeComponent();
        }

        public string SearchBox { get => searchBox; set => searchBox = value; }

        #region ownmethod
        private void addDataToFlow(DataTable question)
        {
            totalPage = (int)Math.Ceiling((int)question.Rows[0]["TotalRecords"] / (double)offset);
            var tqlList = new List<TeacherQuestionList>();

            foreach (DataRow row in question.Rows)
            {
                var tql = new TeacherQuestionList
                {
                    QuestionID = (int)row["QuestionID"],
                    QuestionDetail = (row["QuestionDetail"] as string).Replace("@@@", "\n"),
                    IsOK = (bool)row["IsOK"],
                    IsTest = (bool)row["IsTest"],
                    DifficultName = row["DifficultName"] as string,
                    SubjectName = row["SubjectName"] as string,
                    UpdateAt = ((DateTime)row["UpdateAt"]).ToLocalTime()
                };

                tqlList.Add(tql);
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(tqlList.ToArray());

            guna2HtmlLabel2.Text = $"/{totalPage:00}";
        }
        public async void updateData()
        {
            try
            {
                string difficultName = filtermember.DifficultName != "--Độ khó--"
                    ? filtermember.DifficultName : "";
                string subjectName = filtermember.SubjectName != "--Chủ đề--"
                    ? filtermember.SubjectName : "";
                int? IsTest = filtermember.IsTest != "--Dạng--"
                    ? (filtermember.IsTest == "Thi" ? 1 : 0) : null;
                int? IsOK = filtermember.IsOK != "--Tình trạng--"
                    ? (filtermember.IsOK == "Đã được duyệt" ? 1 : 0) : null;


                DataTable question = await MainFormQuizAppBus
               .Instance
               .loadQuestionByUser
                (
                    acc.Username, page, offset, searchBox,
                    difficultName, subjectName, filtermember.From,
                    filtermember.To, IsTest, IsOK
                );

                if (question.Rows.Count > 0)
                {
                    addDataToFlow(question);
                    guna2HtmlLabel2.Text = $"/{totalPage:00}";
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    totalPage = 1;
                    guna2HtmlLabel2.Text = $"/{totalPage:00}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã có lỗi xảy ra: {ex.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private bool checkIsTextBoxUnchanged(int page)
        {
            if (guna2TextBox2.Text == page.ToString())
            {
                if (page != 1)
                {
                    guna2TextBox2.Text = "1";
                    return true;
                }
                updateData();
                return true;
            }
            return false;
        }
        private string checkTeacherQuestionList(
            TeacherQuestionList tql
        )
        {
            string concatString = "";
            if (tql.Choose == true)
            {
                if (tql.IsOK)
                {
                    throw new Exception(
                       "Không thể xóa câu hỏi đã được phê duyệt"
                    );
                }
                concatString = tql.QuestionID + ",";
            }
            return concatString;
        }
        #endregion

        private void QuestionListComponent_Load(object sender, EventArgs e)
        {
            PanelScrollHelper flowpan2 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar2, true
            );
            guna2TextBox2.Text = page.ToString();
            guna2TextBox3.DataBindings.Add(
                "Text", this, "SearchBox", false, DataSourceUpdateMode.OnPropertyChanged
            );
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(guna2TextBox2.Text, out int result))
            {
                page = result;
                updateData();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (page == totalPage)
                return;
            ++page;

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = page.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (page == 1)
                return;
            --page;

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = page.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            using (Filter filterControl = new Filter(filtermember))
            {
                filterControl.ShowDialog();
                filtermember = filterControl.FilterMember;
            }

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = "1";
        }

        private async void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            int delayMilliseconds = 200;
            searchBox = guna2TextBox3.Text;
            await Task.Delay(delayMilliseconds);

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = "1";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (isTurnOn == -1)
            {
                foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
                {
                    tql.Choose = true;
                }
                isTurnOn *= -1;
                guna2Button5.Text = "Bỏ chọn";
                return;
            }

            foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
            {
                tql.Choose = false;
            }
            guna2Button5.Text = "Chọn tất cả";
            isTurnOn *= -1;
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                string questionIDLists = "";
                foreach (TeacherQuestionList tql in flowLayoutPanel1.Controls)
                {
                    questionIDLists += checkTeacherQuestionList(tql);
                }

                if (questionIDLists == "")
                {
                    throw new Exception(
                        "Chưa chọn câu hỏi để xóa"
                    );
                }

                questionIDLists = questionIDLists.Substring(0, questionIDLists.Length - 1);
                int countRowsAffect = await MainFormQuizAppBus
                    .Instance
                    .deleteQuestionByQuestionID(questionIDLists);

                if (countRowsAffect > 0)
                    MessageBox.Show(
                        "Xóa câu hỏi thành công",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );

                if (checkIsTextBoxUnchanged(page))
                    return;

                guna2TextBox2.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        $"Xóa câu hỏi thất bại: {ex.Message}",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                );
            }
        }
    }
}
