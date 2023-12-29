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
    public partial class LoginModule : UserControl
    {
        private int passwordShowState = 1;
        private int isUnvalid = -1;
        public LoginModule()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, 
                true
            );
            InitializeComponent();
        }

        #region ownmethod
        private void ShowValidation(int isUnValid, string message = null)
        {
            Color fillColor;
            Color borderColor;
            if (isUnValid == 1)
            {
                if (message != null)
                    guna2HtmlLabel3.Text = message;
                guna2HtmlLabel3.Visible = true;
                guna2PictureBox3.Visible = true;

                fillColor = System.Drawing
                                  .ColorTranslator
                                  .FromHtml("#f4e3f5");
                borderColor = System.Drawing
                                    .ColorTranslator
                                    .FromHtml("#ebbfef");
                guna2TextBox1.FillColor = fillColor;
                guna2TextBox1.BorderColor = borderColor;
                guna2TextBox1.IconLeft = Properties.Resources.emergency;

                guna2TextBox2.FillColor = fillColor;
                guna2TextBox2.BorderColor = borderColor;
                guna2TextBox2.IconLeft = Properties.Resources.emergency;

                return;
            }

            guna2HtmlLabel3.Visible = false;
            guna2PictureBox3.Visible = false;

            fillColor = Color.FromArgb(237, 237, 237);
            borderColor = Color.FromArgb(213, 218, 223);
            guna2TextBox1.FillColor = fillColor;
            guna2TextBox1.BorderColor = borderColor;
            guna2TextBox1.IconLeft = null;

            guna2TextBox2.FillColor = fillColor;
            guna2TextBox2.BorderColor = borderColor;
            guna2TextBox2.IconLeft = null;
        }
        #endregion

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_IconRightClick(object sender, EventArgs e)
        {
            if (passwordShowState == 1)
            {
                guna2TextBox2.PasswordChar = '\0';
                guna2TextBox2.IconRight = Properties.Resources.icons8_hide_30;
                passwordShowState *= -1;
                return;
            }

            passwordShowState *= -1;
            guna2TextBox2.PasswordChar = '*';
            guna2TextBox2.IconRight = Properties.Resources.icons8_eye_30;

        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;
            DataTable data = await LoginBus.Instance.getUserInformation(username, password);

            if (data.Rows.Count <= 0)
            {
                if (isUnvalid == -1)
                {
                    isUnvalid *= -1;
                    ShowValidation
                    (
                        isUnvalid,
                        "Có vẻ như bạn đã nhập sai tài khoản hoặc mật khẩu. Hãy thử lại "
                    );
                }
                return;
            }

            AccountResponse acc = new AccountResponse(data.Rows[0]);
            if (acc.IsBanned)
            {
                if (isUnvalid == -1)
                {
                    isUnvalid *= -1;
                    ShowValidation
                    (
                        isUnvalid,
                        "Rất tiếc, tài khoản của bạn đã bị vô hiệu hóa. Hãy sử dụng tài khoản khác"
                    );
                }
                return;
            }

            Panel formPanel = (Panel)(this.Parent);
            LogForm parent = (LogForm)formPanel.Parent;
            parent.Opacity = 0;
            parent.ShowInTaskbar = false;
            MainFormQuiz mfqa = new MainFormQuiz(acc);
            mfqa.ShowDialog();
            parent.Opacity = 1;
            parent.ShowInTaskbar = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new RegisterComponentStep1();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);

        }

        private void LoginModule_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Focus();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

            if (isUnvalid == 1)
            {
                isUnvalid *= -1;
                ShowValidation(isUnvalid);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (isUnvalid == 1)
            {
                isUnvalid *= -1;
                ShowValidation(isUnvalid);
            }
        }

        private void guna2TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2TextBox2.Focus();
                e.IsInputKey = true;
            }

            if (e.KeyData == Keys.Enter)
            {
                guna2Button1.PerformClick();
                e.IsInputKey = true;
            }
        }

        private void guna2TextBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                guna2Button1.PerformClick();
                e.IsInputKey = true;
            }
        }
    }
}
