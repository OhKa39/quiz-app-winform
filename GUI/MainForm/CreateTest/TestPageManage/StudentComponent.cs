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
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainForm.CreateTest.TestPageManage
{

    public partial class StudentComponent : UserControl
    {
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        private string searchBox = "";
        private int testSetID;
        private int classID;
        private int questionCount;
        private int totalTime;
        private string testSetName;
        private AccountResponse acc;

        public int TestSetID { get => testSetID; set => testSetID = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public int TotalTime { get => totalTime; set => totalTime = value; }
        public string TestSetName { get => testSetName; set => testSetName = value; }
        public AccountResponse Acc { get => acc; set => acc = value; }

        public StudentComponent()
        {
            this.SetStyle(
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint |
                  ControlStyles.DoubleBuffer, true
            );
            InitializeComponent();
        }

        #region ownmethod
        private void addDataToFlow(DataTable question)
        {
            totalPage = (int)Math.Ceiling((int)question.Rows[0]["TotalRecords"] / (double)offset);
            var scList = new List<StudentC>();

            foreach (DataRow row in question.Rows)
            {
                var sc = new StudentC
                {
                    TestLogID = (int)row["TestLogID"],
                    FullName = row["FullName"] as string,
                    CreatedAt = (DateTime)row["CreateAt"],
                    ClassName = row["ClassName"] as string,
                    TimeTaken = (int)row["TimeTaken"],
                    QuestionCount = QuestionCount,
                    TestSetName = TestSetName,
                    Acc = Acc
                };

                scList.Add(sc);
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(scList.ToArray());

            guna2HtmlLabel2.Text = $"/{totalPage:00}";
        }

        public async void updateData()
        {
            try
            {

                DataTable question = await MainFormQuizAppBus
                    .Instance
                    .loadAllUserTestLog(
                        classID, TestSetID, searchBox, offset, page
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
        #endregion

        private async void QuestionListComponent_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable classI = await MainFormQuizAppBus
                    .Instance.loadClassInTestSetManageClass(TestSetID);
                foreach (DataRow i in classI.Rows)
                    guna2ComboBox1.Items.Add($"{(int)i["ClassID"]}:{i["ClassName"] as string}");
                guna2ComboBox1.SelectedIndex = 1;
                PanelScrollHelper flowpan2 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar2, true
                );
                guna2TextBox3.DataBindings.Add(
                    "Text", this, "SearchBox",
                    false, DataSourceUpdateMode.OnPropertyChanged
                );

                if (checkIsTextBoxUnchanged(page))
                    return;

                guna2TextBox2.Text = page.ToString();
            }
            catch (Exception ex)
            {

            }
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

        private async void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            int delayMilliseconds = 200;
            searchBox = guna2TextBox3.Text;
            await Task.Delay(delayMilliseconds);

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = "1";
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "--Lớp--")
                return;
            classID = Int32.Parse(guna2ComboBox1.Text.Split(":")[0]);
            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = page.ToString();
        }
    }
}
