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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class AfterCreateAccount : UserControl
    {
        private bool isSuccess;
        public AfterCreateAccount(bool _isSuccess)
        {
            isSuccess = _isSuccess;
            InitializeComponent();
        }

        #region ownmethod
        #endregion

        private void AfterCreateAccount_Load(object sender, EventArgs e)
        {
            if (!isSuccess)
            {
                guna2HtmlLabel1.Text = "Đăng ký không thành công. Hãy thử lại";
                guna2HtmlLabel1.ForeColor = Color.Red;
                guna2PictureBox3.Image = Properties.Resources.warning;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new LoginModule();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }
    }
}
