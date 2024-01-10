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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class NotificationForm : UserControl
    {
        private bool isSuccess;
        private string alert;
        public NotificationForm(bool _isSuccess, string _alert)
        {
            isSuccess = _isSuccess;
            alert = _alert;
            InitializeComponent();
        }

        #region ownmethod
        #endregion

        private void AfterCreateAccount_Load(object sender, EventArgs e)
        {
            if (!isSuccess)
            {
                guna2HtmlLabel1.Text = alert;
                guna2HtmlLabel1.ForeColor = Color.Red;
                guna2PictureBox3.Image = Properties.Resources.warning;
            }
            else
                guna2HtmlLabel1.Text = alert;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Guna2Panel formPanel = (Guna2Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new LoginModule();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }
    }
}
