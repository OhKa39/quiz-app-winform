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
using GUI.MainForm.QuestionSet.QuestionTestPage;
using Guna.UI2.WinForms;
using GUI.MainForm.QuestionSetManage.QuestionSetManagePage;
using GUI.MainForm.QuestionSetManage.QuestionSetDivPage;

namespace GUI.MainForm.QuestionSetManage.QuestionSetManagePage
{
    public partial class QuestionSetComponent : UserControl
    {

        public QuestionSetComponent()
        {
            InitializeComponent();
        }
        private int questionSetID;
        private string questionSetName;
        private string time;
        private string isTest;
        private bool isOK;
        private string questionNumber;
        private DateTime updateAt;
        private bool choose;
        private bool isCheck;
        private bool isEdit = false;
        private int type = 1;
        private int hasInDict = -1;

        private async void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            //If is not user edit mode return
            if (type != 1 && type != 4)
                return;

            //This's for user edit mode page
            IsChecked = Guna2Button2.Checked;
            if (IsChecked)
            {
                if(type == 1)
                {
                    Control transvertControl = this;
                    while (!(transvertControl is QuestionSetManageP))
                    {
                        transvertControl = transvertControl.Parent;
                    }

                    QuestionSetManageP qtm = (QuestionSetManageP)transvertControl;
                    QuestionListComponentQS qlcqs = (QuestionListComponentQS)qtm
                        .Guna2Panel2.Controls[0];

                    qlcqs.questionDict.Clear();

                    DataTable questionIDs = await MainFormQuizAppBus
                        .Instance
                        .findQuestionIDinQuestionSet(QuestionSetID);
                    string questionID = "";

                    foreach (DataRow dr in questionIDs.Rows)
                    {
                        qlcqs.questionDict.Add((int)dr["QuestionID"], "");
                        questionID += ((int)dr["QuestionID"]).ToString() + ",";
                    }
                    questionID = questionID.Substring(0, questionID.Length - 1);
                    qlcqs.QuestionID = questionID;
                    qlcqs.updateData();
                }

                foreach (QuestionSetComponent fk in Parent.Controls)
                {
                    if (!fk.Equals(this))
                    {
                        if (fk.IsChecked)
                        {
                            fk.IsChecked = false;
                        }
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (Type == 1 || Type == 4)
                return;
            using (QuestionPopUp qpp = new QuestionPopUp(QuestionSetID))
                qpp.ShowDialog();
        }

        private void QuestionSetComponent_Load(object sender, EventArgs e)
        {
            guna2CheckBox1.Checked = HasInDict == 1 ? true : false;
            if (type != 1 & type != 4)
            {
                guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
                return;
            }    
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            QuestionSetList qsl = (QuestionSetList)Parent.Parent;
            if (guna2CheckBox1.Checked)
            {
                if (HasInDict == 1)
                    return;
                qsl.QuestionSetDict.Add(QuestionSetID, Time.ToString() + "*" + QuestionNumber.ToString() + "*" + isOK.ToString());
                qsl.Guna2HtmlLabel1.Text = $"Số bộ đề đã chọn: {qsl.QuestionSetDict.Count}";
                HasInDict = 1;
            }
            else
            {
                qsl.QuestionSetDict.Remove(QuestionSetID);
                qsl.Guna2HtmlLabel1.Text = $"Số bộ đề đã chọn: {qsl.QuestionSetDict.Count}";
                HasInDict = -1;
            }
        }

        public int QuestionSetID
        {
            get => questionSetID;
            set
            {
                guna2HtmlLabel1.Text = value.ToString();
                questionSetID = value;

            }
        }
        public string QuestionSetName
        {
            get => questionSetName;
            set
            {
                Guna2TextBox1.Text = value;
                questionSetName = value;
            }
        }
        public string Time
        {
            get => time;
            set
            {
                time = value;
                Guna2ComboBox1.Text = value.ToString();
            }
        }
        public string IsTest
        {
            get => isTest;
            set
            {
                isTest = value;
                Guna2ComboBox3.Text = value;
            }
        }
        public bool IsOK
        {
            get => isOK;
            set
            {
                isOK = value;
                if (value == true)
                    guna2PictureBox1.Image = Properties.Resources.checked1;
                else
                    guna2PictureBox1.Image = Properties.Resources.warning;
            }
        }

        public string QuestionNumber
        {
            get => questionNumber;
            set
            {
                questionNumber = value;
                Guna2ComboBox2.Text = value;
            }
        }

        public DateTime UpdateAt
        {
            get => updateAt;
            set
            {
                updateAt = value;
                guna2HtmlLabel2.Text = $"Lần cuối sửa đổi: {value}";
            }
        }

        public bool Choose
        {
            get
            {
                return guna2CheckBox1.Checked;
            }
            set
            {
                choose = value;
                guna2CheckBox1.Checked = value;
            }
        }

        public bool IsChecked
        {
            get
            {
                return isCheck;
            }
            set
            {
                isCheck = value;
                if (Guna2Button2.Checked != value)
                    Guna2Button2.Checked = value;
            }
        }

        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public int Type { get => type; set => type = value; }
        public int HasInDict { get => hasInDict; set => hasInDict = value; }
    }
}
