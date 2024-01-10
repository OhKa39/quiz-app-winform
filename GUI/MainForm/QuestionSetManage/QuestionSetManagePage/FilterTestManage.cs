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
using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSetManage.QuestionSetManagePage
{
    public partial class FilterTestManage : Form
    {
        private FilterQuestionSet filterMember;
        private int isRender = -1;

        public FilterQuestionSet FilterMember { get => filterMember; set => filterMember = value; }

        public FilterTestManage(FilterQuestionSet _filterMember)
        {
            FilterMember = _filterMember;
            InitializeComponent();
        }



        private void FilterTestManage_Load(object sender, EventArgs e)
        {

            guna2ComboBox1.DataBindings.Add("SelectedItem", FilterMember, "Time", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox4.DataBindings.Add("SelectedItem", FilterMember, "IsOK", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox5.DataBindings.Add("SelectedItem", FilterMember, "IsTest", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2DateTimePicker1.DataBindings.Add("Value", FilterMember, "From", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2DateTimePicker2.DataBindings.Add("Value", FilterMember, "To", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox2.DataBindings.Add("SelectedItem", FilterMember, "TotalQuestion", false, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FilterMember.Time = "--Thời gian--";
            FilterMember.IsTest = "--Dạng--";
            FilterMember.IsOK = "--Tình trạng--";
            FilterMember.From = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            FilterMember.To = DateTime.Today;
            FilterMember.TotalQuestion = "--Số câu hỏi--";

            guna2ComboBox4.SelectedIndex = 0;
            guna2ComboBox5.SelectedIndex = 0;
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
            guna2DateTimePicker1.Value = FilterMember.From;
            guna2DateTimePicker2.Value = FilterMember.To;
        }
    }
}
