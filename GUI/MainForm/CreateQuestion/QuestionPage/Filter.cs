using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.MainForm.CreateQuestion.QuestionPage;
using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSet.QuestionPage
{
    public partial class Filter : Form
    {
        private FilterMember filterMember;
        private int isRender = -1;

        public FilterMember FilterMember { get => filterMember; set => filterMember = value; }

        public Filter(FilterMember _filterMember)
        {
            FilterMember = _filterMember;
            InitializeComponent();
        }



        private async void Filter_Load(object sender, EventArgs e)
        {
            DataTable books = await MainFormQuizAppBus.Instance.loadBook();
            //Guna2CheckBoxComboBox checkBoxComboBox = new Guna2CheckBoxComboBox();
            //checkBoxComboBox.DefaultString = "--Sách--";
            //checkBoxComboBox.Location = new System.Drawing.Point(42, 55);
            //checkBoxComboBox.BringToFront();
            //checkBoxComboBox.Size1 = new System.Drawing.Size(222, 36);

            if (books.Rows.Count > 0)
            {
                foreach (DataRow i in books.Rows)
                {
                    //checkBoxComboBox.AddItem(i["BookName"] as string);
                    guna2ComboBox1.Items.Add(i["BookName"]);
                }
            }
            //Controls.Add(checkBoxComboBox);

            guna2ComboBox1.DataBindings.Add("SelectedItem", FilterMember, "BookName", false, DataSourceUpdateMode.OnPropertyChanged);

            DataTable subject = await MainFormQuizAppBus
                .Instance
                .loadSubjectByBookName(guna2ComboBox1.Text);
            if (subject.Rows.Count > 0)
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("--Chủ đề--");
                guna2ComboBox2.SelectedIndex = 0;
                foreach (DataRow i in subject.Rows)
                {
                    guna2ComboBox2.Items.Add(i["SubjectName"]);
                }
            }

            FilterMember.IsOK = "--Tình trạng--";
            guna2ComboBox2.DataBindings.Add("SelectedItem", FilterMember, "SubjectName", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox3.DataBindings.Add("SelectedItem", FilterMember, "DifficultName", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox4.DataBindings.Add("SelectedItem", FilterMember, "IsOK", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox5.DataBindings.Add("SelectedItem", FilterMember, "IsTest", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2DateTimePicker1.DataBindings.Add("Value", FilterMember, "From", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2DateTimePicker2.DataBindings.Add("Value", FilterMember, "To", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2Button4.Checked = FilterMember.DifficultNameSort;
            guna2Button5.Checked = FilterMember.SubjectSort;
            guna2Button6.Checked = FilterMember.UpdateTimeSort1;
            guna2Button7.Checked = FilterMember.IsTestSort;
            guna2Button8.Checked = FilterMember.IsOKSort;
        }

        private async void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRender == -1)
            {
                isRender = 1;
                return;
            }

            if (guna2ComboBox1.Text == "--Sách--")
            {
                guna2ComboBox2.SelectedIndex = 0;
                return;
            }
            DataTable subject = await MainFormQuizAppBus
                .Instance
                .loadSubjectByBookName(guna2ComboBox1.Text);
            if (subject.Rows.Count > 0)
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("--Chủ đề--");
                guna2ComboBox2.SelectedIndex = 0;
                foreach (DataRow i in subject.Rows)
                {
                    guna2ComboBox2.Items.Add(i["SubjectName"]);
                }
            }
        }

        private void guna2Button4_CheckedChanged(object sender, EventArgs e)
        {
            FilterMember.DifficultNameSort = guna2Button4.Checked;
        }

        private void guna2Button5_CheckedChanged(object sender, EventArgs e)
        {
            FilterMember.SubjectSort = guna2Button5.Checked;
        }

        private void guna2Button6_CheckedChanged(object sender, EventArgs e)
        {
            FilterMember.UpdateTimeSort1 = guna2Button6.Checked;
        }

        private void guna2Button7_CheckedChanged(object sender, EventArgs e)
        {
            FilterMember.IsTestSort = guna2Button7.Checked;
        }

        private void guna2Button8_CheckedChanged(object sender, EventArgs e)
        {
            FilterMember.IsOKSort = guna2Button8.Checked;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FilterMember.DifficultName = "--Độ khó--";
            FilterMember.SubjectName = "--Chủ đề--";
            FilterMember.BookName = "--Sách--";
            FilterMember.IsTest = "--Dạng--";
            FilterMember.IsOK = "--Tình trạng--";
            FilterMember.From = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            FilterMember.To = DateTime.Today;

            guna2ComboBox2.SelectedIndex = 0;
            guna2ComboBox3.SelectedIndex = 0;
            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox5.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndex = 0;
            guna2DateTimePicker1.Value = FilterMember.From;
            guna2DateTimePicker2.Value = FilterMember.To;
        }
    }
}
