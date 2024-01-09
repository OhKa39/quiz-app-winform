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
using GUI.MainForm.CreateTest.TestPageManage;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainForm.Practice.TrainingHistoryPage
{
    public partial class TrainingHistory : UserControl
    {
        AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        public TrainingHistory(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        #region ownmethod
        private void addDataToFlow(DataTable testLogList)
        {
            totalPage = (int)Math.Ceiling((int)testLogList.Rows[0]["TotalRecords"] / (double)offset);
            var thcList = new List<TrainingHistoryComponent>();

            foreach (DataRow row in testLogList.Rows)
            {
                var thc = new TrainingHistoryComponent
                {
                    TestLogID = (int)row["TestLogID"],
                    TestSetName = $"Bài luyện tập số {(int)row["TestLogID"]}",
                    FullName = row["FullName"] as string,
                    ClassName = row["ClassName"] as string,
                    CreateAt = (DateTime)row["CreateAt"],
                    TimeTaken = (int)row["TimeTaken"],
                    Acc = acc
                };

                thcList.Add(thc);
            }

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(thcList.ToArray());

            guna2HtmlLabel2.Text = $"/{totalPage:00}";
        }

        public async void updateData()
        {
            try
            {

                DataTable testLog = await MainFormQuizAppBus
                    .Instance
                    .loadAllPracticeTestLog(
                        acc.AccountID, offset, page
                );

                if (testLog.Rows.Count > 0)
                {
                    addDataToFlow(testLog);
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

        private void TrainingHistory_Load(object sender, EventArgs e)
        {
            PanelScrollHelper flowpan2 = new PanelScrollHelper(
               flowLayoutPanel1, guna2vScrollBar1, true
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (page == 1)
                return;
            --page;

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = page.ToString();
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
    }
}
