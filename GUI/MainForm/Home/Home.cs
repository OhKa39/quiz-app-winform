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
using Guna.UI2.WinForms;

namespace GUI.MainForm.Home
{
    public partial class Home : UserControl
    {
        AccountResponse acc;
        public Home(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void Home_Load(object sender, EventArgs e)
        {
            try
            {
                guna2HtmlLabel1.Text = $"Xin chào, {acc.Fullname}";
                guna2CircleProgressBar1.Minimum = 0;
                guna2CircleProgressBar1.Maximum = 100;

                guna2CircleProgressBar2.Minimum = 0;
                guna2CircleProgressBar2.Maximum = 100;

                DataTable percentDone = await MainFormQuizAppBus
                    .Instance.getPercenTestLogDone(acc.AccountID);
                if (percentDone.Rows.Count > 0)
                {
                    Double percent = (Double)percentDone.Rows[0]["percentDone"];
                    guna2HtmlLabel4.Text = $"{Math.Round(percent * 100, 2)}%";
                    guna2CircleProgressBar1.Value = (int)Math.Round(percent * 100);
                }
                else
                {
                    Double percent = 0;
                    guna2HtmlLabel4.Text = $"0%";
                }
                Control uc = new TestList(acc);
                uc.Dock = DockStyle.Fill;
                guna2Panel1.Controls.Add(uc);
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
