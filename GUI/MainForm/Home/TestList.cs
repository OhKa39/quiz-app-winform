using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainForm.Home
{
    public partial class TestList : UserControl
    {
        AccountResponse acc;
        public TestList(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private async void TestList_Load(object sender, EventArgs e)
        {
            PanelScrollHelper flowpan1 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar1, true
            );

            try
            {
                DataTable currentSchoolYear = await MainFormQuizAppBus
                    .Instance
                    .getCurrentSchoolYear();

                DataTable testSets = await MainFormQuizAppBus.Instance.loadTestSetOfUser(acc.AccountID);

                string currentSY = currentSchoolYear.Rows[0]["SchoolYearDescription"] as string;
                List<TestListComponent> tlcs = new List<TestListComponent>();
                foreach (DataRow dr in testSets.Rows)
                {
                    var tlc = new TestListComponent
                    {
                        TestSetID = (int)dr["TestSetManageID"],
                        TestSetName = dr["TestSetManageName"] as string,
                        Time = (int)dr["Time"],
                        QuestionCount = (int)dr["TotalQuestion"],
                        CurrentStudyYear = currentSY,
                        Acc = acc
                    };
                    tlcs.Add(tlc);
                }

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.AddRange(tlcs.ToArray());
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
    }
}
