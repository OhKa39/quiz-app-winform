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
using DTO;
using GUI.MainForm.QuestionSetManage.QuestionSetDivPage;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;
using Guna.UI2.WinForms.Helpers;

namespace GUI.MainForm.QuestionSetManage
{
    public partial class QuestionSetDivControl : UserControl
    {
        AccountResponse acc;
        public QuestionSetDivControl(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private async void QuestionSetDivControl_Load(object sender, EventArgs e)
        {
            PanelScrollHelper flowpan1 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar1, true
                );
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            try
            {
                int? schoolYearID = await MainFormQuizAppBus
                    .Instance
                    .getCurrentSchoolYearID();
                DataTable grade = await MainFormQuizAppBus
                    .Instance
                    .loadClass(schoolYearID);
                var classbtn = new List<ClassButton>();
                foreach (DataRow data in grade.Rows)
                {
                    var cbtn = new ClassButton
                    {
                        ClassName = data["ClassName"] as string,
                        ClassID = (int)data["ClassID"]
                    };

                    classbtn.Add(cbtn);
                }

                flowLayoutPanel1.Controls.AddRange(classbtn.ToArray());
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

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TestSetName = guna2TextBox1.Text.Trim();
                string timeString = guna2ComboBox1.Text;
                string questionCountString = guna2ComboBox2.Text;
                if (TestSetName == "" || timeString == "--Thời gian--"
                    || questionCountString == "--Số câu hỏi--")
                    throw new Exception("Không được để trống trường thông tin");

                string classID = "";
                foreach (ClassButton btn in flowLayoutPanel1.Controls)
                {
                    if(btn.IsChecked)
                        classID += btn.ClassID + ",";
                }

                if(classID == "")
                    throw new Exception("Không được để trống trường thông tin");

                QuestionSetDiv qsd = (QuestionSetDiv)Parent.Parent;
                QuestionSetList qsl = (QuestionSetList)qsd.Guna2Panel1.Controls[0];
                string previous = "-1";
                string questionSetID = "";

                foreach(var item in qsl.QuestionSetDict)
                {
                    string[] itemString = item.Value.Split("*");

                    if (itemString[0] != timeString)
                        throw new Exception(
                            "Bộ đề có thời gian không phù hợp với" +
                            " thời gian làm bài bạn đã lựa chọn"
                        );

                    if (itemString[0] != questionCountString)
                        throw new Exception(
                            "Bộ đề có tổng số câu hỏi không phù hợp với" +
                            " tổng số câu hỏi bạn đã lựa chọn"
                        );

                    if (previous != "-1" && previous != item.Value)
                        throw new Exception("Các bộ đề không cùng số câu hoặc thời gian");

                    questionSetID += item.Key + ",";
                    previous = item.Value;
                }

                if (questionSetID == "")
                    throw new Exception("Không được để trống trường thông tin");

                int time = Int32.Parse(timeString);
                int questionCount = Int32.Parse(questionCountString);

                int rowAffect = await MainFormQuizAppBus.Instance.createTestSet
                (
                    acc.AccountID, time, questionCount, TestSetName, 
                    questionSetID, classID
                );

                if(rowAffect > 0)
                {
                    MessageBox.Show(
                        $"Tạo bài thi thành công",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                guna2ComboBox1.SelectedIndex = 0;
                guna2ComboBox2.SelectedIndex = 0;
                guna2TextBox1.Text = "";
                foreach (ClassButton btn in flowLayoutPanel1.Controls)
                {
                    btn.IsChecked = false;
                }

                qsl.QuestionSetDict.Clear();
                qsl.updateData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Tạo bài thi thất bại: {ex.Message}",
                    "Thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
    }
}
