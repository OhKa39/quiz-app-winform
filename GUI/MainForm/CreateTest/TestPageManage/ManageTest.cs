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
using Guna.UI2.WinForms.Helpers;
using Guna.UI2.WinForms;
using BUS;
using GUI.MainForm.QuestionSet.QuestionPage;

namespace GUI.MainForm.CreateTest.TestPageManage
{
    public partial class ManageTest : UserControl
    {
        AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        private string searchBox = "";
        private int isTurnOn = -1;
        private Dictionary<int, string> testSetDict = new Dictionary<int, string>();

        public Dictionary<int, string> TestSetDict { get => testSetDict; set => testSetDict = value; }
        public string SearchBox { get => searchBox; set => searchBox = value; }

        public ManageTest(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        #region ownmethod
        private void addDataToFlow(DataTable testList)
        {
            totalPage = (int)Math.Ceiling((int)testList.Rows[0]["TotalRecords"] / (double)offset);
            var tpcList = new List<TestPageButtonComponent>();

            foreach (DataRow row in testList.Rows)
            {
                var tpc = new TestPageButtonComponent
                {
                    TestSetID = (int)row["TestSetManageID"],
                    TestSetName = row["TestSetManageName"] as string,
                    AccountID = (int)row["AccountID"],
                    AccountName = row["UserName"] as string,
                    CreatedAt = ((DateTime)row["CreateAt"]).ToLocalTime(),
                    TotalQuestion = (int)row["TotalQuestion"],
                    Time = (int)row["Time"],
                    HasInDict = testSetDict.ContainsKey((int)row["TestSetManageID"]) ? 1 : -1,
                    Acc = acc
                };

                tpcList.Add(tpc);
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(tpcList.ToArray());

            guna2HtmlLabel2.Text = $"/{totalPage:00}";
        }

        public async void updateData()
        {
            try
            {
                guna2HtmlLabel1.Text = $"Số câu hỏi đã chọn: {testSetDict.Count}";
                int? accountID = acc.RoleName == "Admin" ? null : acc.AccountID;

                DataTable testSet = await MainFormQuizAppBus
                    .Instance
                    .getAllTestSet(
                        accountID, SearchBox, offset, page
                );

                if (testSet.Rows.Count > 0)
                {
                    addDataToFlow(testSet);
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

        private void ManageTest_Load(object sender, EventArgs e)
        {
            PanelScrollHelper flowpan2 = new PanelScrollHelper(
                flowLayoutPanel1, guna2vScrollBar1, true
            );
            guna2TextBox1.DataBindings.Add(
                "Text", this, "SearchBox",
                false, DataSourceUpdateMode.OnPropertyChanged
            );
            guna2TextBox2.Text = page.ToString();
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

        private async void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            int delayMilliseconds = 200;
            SearchBox = guna2TextBox1.Text;
            await Task.Delay(delayMilliseconds);

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = "1";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (isTurnOn == -1)
            {
                foreach (TestPageButtonComponent tpb in flowLayoutPanel1.Controls)
                {
                    tpb.Choose = true;
                }
                isTurnOn *= -1;
                guna2Button5.Text = "Bỏ chọn";
                return;
            }

            foreach (TestPageButtonComponent tpb in flowLayoutPanel1.Controls)
            {
                tpb.Choose = false;
            }
            guna2Button5.Text = "Chọn tất cả";
            isTurnOn *= -1;
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                string testSetIDLists = "";
                foreach (var item in testSetDict)
                {
                    testSetIDLists += item.Key.ToString() + ",";
                }

                if (testSetIDLists == "")
                {
                    throw new Exception(
                        "Chưa chọn bài thi để xóa"
                    );
                }

                testSetIDLists = testSetIDLists
                    .Substring(0, testSetIDLists.Length - 1);
                int countRowsAffect = await MainFormQuizAppBus
                    .Instance
                    .deleteTestSetByID(testSetIDLists);

                if (countRowsAffect > 0)
                    MessageBox.Show(
                        "Xóa bài thi thành công",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );

                testSetDict.Clear();

                if (checkIsTextBoxUnchanged(page))
                    return;

                guna2TextBox2.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        $"Xóa bài thi thất bại: {ex.Message}",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                );
            }
        }
    }
}
