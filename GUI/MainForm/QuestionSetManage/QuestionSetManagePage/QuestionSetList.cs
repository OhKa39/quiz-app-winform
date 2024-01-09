using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.MainForm.QuestionSet.QuestionPage;
using GUI.MainForm.QuestionSet.QuestionTestPage;
using Guna.UI2.WinForms.Helpers;
using Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static Guna.UI2.Native.WinApi;

namespace GUI.MainForm.QuestionSetManage.QuestionSetManagePage
{

    public partial class QuestionSetList : UserControl
    {

        private AccountResponse acc;
        private int offset = 25;
        private int page = 1;
        private int totalPage = 1;
        private FilterQuestionSet filtermember;
        private string searchBox = "";
        private int isTurnOn = -1;
        private int type = 1;
        private QuestionSetComponent currentEditQSC;
        QuestionListComponentQS qlcqs;
        private string questionSetID = "";
        private Dictionary<int, string> questionSetDict = new Dictionary<int, string>();
        public QuestionSetList(AccountResponse _acc)
        {
            filtermember = new FilterQuestionSet();
            acc = _acc;
            InitializeComponent();
            Extension.DoubleBuffered(flowLayoutPanel1, true);
        }

        public string SearchBox { get => searchBox; set => searchBox = value; }
        public int Type { get => type; set => type = value; }
        public Dictionary<int, string> QuestionSetDict { get => questionSetDict; set => questionSetDict = value; }
        public string QuestionSetID { get => questionSetID; set => questionSetID = value; }

        #region ownmethod
        private async Task addDataToFlow(DataTable question)
        {
            totalPage = (int)Math.Ceiling((int)question.Rows[0]["TotalRecords"] / (double)offset);
            var qscList = new List<QuestionSetComponent>();

            await Task.WhenAll(question.Rows.Cast<DataRow>().Select(async row =>
            {
                int? count = await MainFormQuizAppBus
                .Instance
                .countQuestionInQuestionSet((int)row["QuestionSetID"]);

                var qsc = new QuestionSetComponent
                {
                    QuestionSetID = (int)row["QuestionSetID"],
                    QuestionSetName = row["QuestionSetName"] as string,
                    Time = ((int)row["Time"]).ToString(),
                    IsTest = (bool)row["IsTest"] == true ? "Thi" : "Luyện tập",
                    IsOK = (bool)row["IsOK"],
                    QuestionNumber = count.ToString(),
                    UpdateAt = (DateTime)row["UpdateAt"],
                    HasInDict = QuestionSetDict.ContainsKey((int)row["QuestionSetID"]) ? 1 : -1,
                    Type = this.Type
                };

                qscList.Add(qsc);
            }));

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(qscList.ToArray());
            if (type == 1)
            {
                QuestionSetComponent qsc = (QuestionSetComponent)flowLayoutPanel1
                    .Controls[0];
                qsc.IsChecked = true;
            }

            guna2HtmlLabel2.Text = $"/{totalPage:00}";
        }

        public async void updateData()
        {
            int? Time = filtermember.Time != "--Thời gian--" 
                ? Int32.Parse(filtermember.Time) : null;
            int? IsTest = filtermember.IsTest != "--Dạng--" 
                ? (filtermember.IsTest == "Thi" ? 1 : 0) : null;
            int? IsOK = filtermember.IsOK != "--Tình trạng--" 
                ? (filtermember.IsOK == "Đã được duyệt" ? 1 : 0) : null;
            int? accountID = (type == 1) ? acc.AccountID : null;
            int? TotalQuestion = filtermember.TotalQuestion != "--Số câu hỏi--" 
                ? Int32.Parse(filtermember.TotalQuestion) : null;
            guna2HtmlLabel1.Text = $"Số câu hỏi đã chọn: {questionSetDict.Count}";

            DataTable question = await MainFormQuizAppBus
                .Instance
                .loadQuestionSetByUser(
                    accountID, page, offset, IsTest, Time, TotalQuestion, 
                    filtermember.From, filtermember.To, IsOK,
                    searchBox, QuestionSetID
                );


            if (question.Rows.Count > 0)
            {
                await addDataToFlow(question);
                guna2HtmlLabel2.Text = $"/{totalPage:00}";
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                totalPage = 1;
                guna2HtmlLabel2.Text = $"/{totalPage:00}";
            }
        }

        private string checkQuestionSetComponent(
            int QuestionSetid, string qsc
        )
        {
            string concatString = "";
           
            if (qsc.Split("*")[2] == "true" && Type != 3)
            {
                throw new Exception(
                    "Không thể xóa câu hỏi đã được phê duyệt"
                );
            }

            concatString = QuestionSetid + ",";
            return concatString;
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

        private void QuestionSetList_Load(object sender, EventArgs e)
        {

            PanelScrollHelper flowpan2 = new PanelScrollHelper(
                    flowLayoutPanel1, guna2vScrollBar2, true
                );
            if(type == 2 || type == 4)
                filtermember.IsOK = "Đã được duyệt";

            if (type == 4)
                filtermember.IsTest = "Luyện tập";

            guna2TextBox2.Text = page.ToString();

            guna2TextBox3.DataBindings.Add
            (
                "Text", this, 
                "SearchBox", false, DataSourceUpdateMode.OnPropertyChanged
            );

            if (type == 2 || type == 4)
            {
                guna2Button6.Visible = false;
                guna2Button2.Visible = false;
                guna2ToggleSwitch1.Visible = false;
                return;
            }

            if(type == 3)
            {
                guna2Button6.Text = "Not OK";
                guna2Button2.Text = "OK";
                guna2Button2.Enabled = true;
                guna2ToggleSwitch1.Visible = false;
                return;
            }

            Control convert = this;
            while (!(convert is QuestionSetManageP))
                convert = convert.Parent;
            QuestionSetManageP qsm = (QuestionSetManageP)convert;
            qlcqs = (QuestionListComponentQS)qsm.Guna2Panel2.Controls[0];
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            using (FilterTestManage filterControl = new FilterTestManage(filtermember))
            {
                if(type == 2 || type == 4)
                    filterControl.Guna2ComboBox4.Enabled = false;

                if(type == 4)
                    filterControl.Guna2ComboBox5.Enabled = false;

                filterControl.ShowDialog();
                filtermember = filterControl.FilterMember;
            }

            if (checkIsTextBoxUnchanged(page))
                return;

            guna2TextBox2.Text = "1";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(guna2TextBox2.Text, out int result))
            {
                page = result;
                updateData();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (isTurnOn == -1)
            {
                foreach (QuestionSetComponent qsc in flowLayoutPanel1.Controls)
                {
                    qsc.Choose = true;
                }
                isTurnOn *= -1;
                guna2Button5.Text = "Bỏ chọn";
                return;
            }

            foreach (QuestionSetComponent qsc in flowLayoutPanel1.Controls)
            {
                qsc.Choose = false;
            }
            guna2Button5.Text = "Chọn tất cả";
            isTurnOn *= -1;
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

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {



            if (guna2ToggleSwitch1.Checked)
            {
                guna2Button2.Enabled = true;
                foreach (QuestionSetComponent qsc in flowLayoutPanel1.Controls)
                {

                    qsc.IsEdit = true;
                    if (qsc.IsChecked)
                    {
                        qlcqs.Guna2ToggleSwitch1.Enabled = true;
                        qlcqs.Guna2ToggleSwitch1.Checked = true;
                        qsc.Guna2ComboBox1.Enabled = true;
                        qsc.Guna2ComboBox2.Enabled = true;
                        qsc.Guna2ComboBox3.Enabled = true;
                        qsc.Guna2TextBox1.Enabled = true;
                        currentEditQSC = qsc;
                    }
                    else
                    {
                        qsc.Guna2ComboBox1.Enabled = false;
                        qsc.Guna2ComboBox2.Enabled = false;
                        qsc.Guna2ComboBox3.Enabled = false;
                        qsc.Guna2TextBox1.Enabled = false;
                        qsc.Guna2Button2.Enabled = false;
                    }
                }
            }
            else
            {
                guna2Button2.Enabled = false;
                qlcqs.Guna2ToggleSwitch1.Enabled = false;
                qlcqs.Guna2TextBox2.Text = "1";
                updateData();
            }
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            if(type == 2)
            {
                try
                {
                    int questionSetID = currentEditQSC.QuestionSetID;
                    string questionSetName = currentEditQSC.Guna2TextBox1.Text;
                    string isTestString = currentEditQSC.Guna2ComboBox3.Text;
                    string timeString = currentEditQSC.Guna2ComboBox1.Text;
                    string questionNumberString = currentEditQSC.Guna2ComboBox2.Text;

                    if (isTestString == "--Dạng--" || timeString == "--Thời gian--"
                       || questionNumberString == "Số câu hỏi")
                    {
                        throw new Exception("Không được để trống trường thông tin");
                    }

                    int isTest = isTestString == "Thi" ? 1 : 0;
                    int time = Int32.Parse(timeString);
                    int questionNumber = Int32.Parse(questionNumberString);

                    if (questionNumber != qlcqs.questionDict.Count)
                    {
                        throw new Exception(
                            "Số câu hỏi đã chọn không trùng với thông tin đã cung cấp"
                        );
                    }

                    string questionID = "";
                    foreach (var K in qlcqs.questionDict)
                    {
                        questionID += K.Key.ToString() + ",";
                    }

                    int count = await MainFormQuizAppBus.Instance.updateQuestionSet(
                        questionSetID, questionSetName, time, isTest, questionID
                    );

                    if (count > 0)
                    {
                        MessageBox.Show(
                            $"Sửa bộ đề thành công",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        guna2ToggleSwitch1.Checked = false;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(
                        $"Sửa bộ đề thất bại: {er.Message}",
                        "Thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            
            if(Type == 3)
            {
                try
                {
                    string questionSetIDLists = "";
                    foreach (var item in questionSetDict)
                    {
                        questionSetIDLists += checkQuestionSetComponent(item.Key, item.Value);
                    }

                    if (questionSetIDLists == "")
                    {
                        throw new Exception(
                            "Chưa có bộ đề nào được chọn"
                        );
                    }

                    questionSetIDLists = questionSetIDLists
                        .Substring(0, questionSetIDLists.Length - 1);
                    int countRowsAffect = await MainFormQuizAppBus
                        .Instance
                        .validateQuestionSetbyID(questionSetIDLists, 1);

                    if (countRowsAffect == questionSetIDLists.Split(",").Length)
                        MessageBox.Show(
                            "Đổi trạng thái bộ đề thành công",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                    );

                    questionSetDict.Clear();

                    if (checkIsTextBoxUnchanged(page))
                        return;

                    guna2TextBox2.Text = "1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            $"Đổi trạng thái bộ đề đề thất bại: {ex.Message}",
                            "Thất bại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                    );
                }
            }    
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            if(type == 2)
            {
                try
                {
                    string questionSetIDLists = "";
                    foreach (var item in questionSetDict)
                    {
                        questionSetIDLists += checkQuestionSetComponent(item.Key, item.Value);
                    }

                    if (questionSetIDLists == "")
                    {
                        throw new Exception(
                            "Chưa chọn bộ đề để xóa"
                        );
                    }

                    questionSetIDLists = questionSetIDLists
                        .Substring(0, questionSetIDLists.Length - 1);
                    int countRowsAffect = await MainFormQuizAppBus
                        .Instance
                        .deleteQuestionSetbyID(questionSetIDLists);

                    if (countRowsAffect > 0)
                        MessageBox.Show(
                            "Xóa bộ đề thành công",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                    );

                    questionSetDict.Clear();

                    if (checkIsTextBoxUnchanged(page))
                        return;

                    guna2TextBox2.Text = "1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            $"Xóa bộ đề thất bại: {ex.Message}",
                            "Thất bại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                    );
                }
            }    

            if(type == 3)
            {
                try
                {
                    string questionSetIDLists = "";
                    foreach (var item in questionSetDict)
                    {
                        questionSetIDLists += checkQuestionSetComponent(item.Key, item.Value);
                    }

                    if (questionSetIDLists == "")
                    {
                        throw new Exception(
                            "Chưa có bộ đề nào được chọn"
                        );
                    }

                    questionSetIDLists = questionSetIDLists
                        .Substring(0, questionSetIDLists.Length - 1);
                    int countRowsAffect = await MainFormQuizAppBus
                        .Instance
                        .validateQuestionSetbyID(questionSetIDLists, 0);

                    if (countRowsAffect == questionSetIDLists.Split(",").Length)
                        MessageBox.Show(
                            "Đổi trạng thái bộ đề thành công",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                    );

                    questionSetDict.Clear();

                    if (checkIsTextBoxUnchanged(page))
                        return;

                    guna2TextBox2.Text = "1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            $"Đổi trạng thái bộ đề thất bại: {ex.Message}",
                            "Thất bại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                    );
                }
            }
            
        }
    }
}
