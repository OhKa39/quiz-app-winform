using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.IdentityModel.Tokens;
using BUS;

namespace GUI
{
    public partial class RegisterComponentStep3 : UserControl
    {
        private AccountRequest tempAccount;
        private string verifyCode;
        private List<int> allOK;
        private const int timeWaitSendMessage = 30;
        private int time;
        private string a, b, c, d, e, f;
        private Guna2TextBox[] gunaTextBoxes;
        private int currentTextBox = 0;
        private int isUnValid = -1;

        public string A { get => a; set => a = value; }
        public string B { get => b; set => b = value; }
        public string C { get => c; set => c = value; }
        public string D { get => d; set => d = value; }
        public string E { get => e; set => e = value; }
        public string F { get => f; set => f = value; }

        public RegisterComponentStep3(AccountRequest _tempAccount, List<int> _allOK)
        {
            allOK = _allOK;
            tempAccount = _tempAccount;
            InitializeComponent();
            gunaTextBoxes = new Guna2TextBox[] { guna2TextBox1, guna2TextBox2, guna2TextBox3, guna2TextBox4, guna2TextBox5, guna2TextBox6 };
            foreach (var i in gunaTextBoxes)
            {
                i.TextChanged += gunaTextBox_TextChanged;
                i.KeyPress += gunaTextBox_KeyPress;
                i.PreviewKeyDown += gunaTextBox_PreviewKeyDown;
            }
        }

        #region Own Method
        private async Task<string> sendVerifyCode()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 1000000);
            string verifyCode = num.ToString("D6");

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("bestlolvn21@gmail.com", "raic junn rkuy oaes"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("bestlolvn21@gmail.com"),
                Subject = "Mã xác nhận QuizApp",
                Body = (
                    "<h1>Mã xác nhận QuizApp</h1>\n" +
                    "<p>Bạn đã đăng ký tài khoản QuizApp với tài khoản là: " + tempAccount.Username + "</p>\n" +
                    "<p>Đây là mã xác nhận đăng nhập của bạn: " + verifyCode + "</p>\n"
                ),
                IsBodyHtml = true,
            };
            mailMessage.To.Add(tempAccount.Email);
            await smtpClient.SendMailAsync(mailMessage);
            return verifyCode;
        }

        private void turnValidation(int state)
        {
            Color fillColor;
            Color borderColor;
            if (state == 1)
            {
                foreach (var txb in gunaTextBoxes)
                {
                    fillColor = System.Drawing
                                  .ColorTranslator
                                  .FromHtml("#f4e3f5");
                    txb.FillColor = fillColor;
                    borderColor = System.Drawing
                        .ColorTranslator
                        .FromHtml("#ebbfef");
                    txb.BorderColor = borderColor;
                }
                guna2Button3.Visible = true;
                return;
            }

            foreach (var txb in gunaTextBoxes)
            {
                fillColor = Color.FromArgb(237, 237, 237);
                txb.FillColor = fillColor;
                borderColor = Color.White;
                txb.BorderColor = borderColor;
            }
            guna2Button3.Visible = false;
        }

        private async Task<bool> Work
        (
           string username,
           string fullName,
           string password,
           string role,
           string isMale,
           string imagePath,
           DateTime DOB,
           string grade,
           string email
        )
        {
            bool count = await LoginBus.Instance
                .CreateAccount
                (
                    username, fullName, password, role, isMale, imagePath,
                    DOB, grade, email
                );
            return count;
        }
        #endregion

        private async void RegisterComponentStep3_Load(object sender, EventArgs e)
        {
            guna2TextBox1.DataBindings.Add("Text", this, "A", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox2.DataBindings.Add("Text", this, "B", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox3.DataBindings.Add("Text", this, "C", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox4.DataBindings.Add("Text", this, "D", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox5.DataBindings.Add("Text", this, "E", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox6.DataBindings.Add("Text", this, "F", false, DataSourceUpdateMode.OnPropertyChanged);
            gunaTextBoxes[currentTextBox].Focus();
            time = timeWaitSendMessage;
            verifyCode = await sendVerifyCode();

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new RegisterComponentStep2(tempAccount, allOK);
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void label2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Enabled = false;
            verifyCode = await sendVerifyCode();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            time--;
            label3.Text = string.Format("{0:00}", time);
            label3.Visible = true;
            if (time <= 0)
            {
                time = timeWaitSendMessage;
                timer1.Stop();
                label2.Enabled = true;
                label3.Visible = false;
            }
        }

        private void gunaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isUnValid == 1)
            {
                isUnValid *= -1;
                turnValidation(isUnValid);
            }
            if (gunaTextBoxes[currentTextBox].Text.Length == 1)
            {
                int nextTextBox = Math.Min(5, currentTextBox + 1);
                gunaTextBoxes[nextTextBox].SelectAll();
                gunaTextBoxes[nextTextBox].Focus();
                currentTextBox = nextTextBox;
                return;
            }

            int PreviousTextBox = Math.Max(0, currentTextBox - 1);
            gunaTextBoxes[PreviousTextBox].SelectAll();
            gunaTextBoxes[PreviousTextBox].Focus();
            currentTextBox = PreviousTextBox;
        }

        private void gunaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if
            (
                !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.')
            )
            {
                e.Handled = true;
            }
        }

        private void gunaTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                int previousTextBox = Math.Max(0, currentTextBox - 1);
                gunaTextBoxes[previousTextBox].SelectAll();
                gunaTextBoxes[previousTextBox].Focus();
                e.IsInputKey = true;
                currentTextBox = previousTextBox;
                return;
            }

            if (e.KeyData == Keys.Right)
            {
                int nextTextBox = Math.Min(5, currentTextBox + 1);
                gunaTextBoxes[nextTextBox].SelectAll();
                gunaTextBoxes[nextTextBox].Focus();
                e.IsInputKey = true;
                currentTextBox = nextTextBox;
                return;
            }

            if (e.KeyData == Keys.Enter)
                guna2Button2.PerformClick();
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            string confirm = a + b + c + d + E + f;
            if (confirm == verifyCode)
            {
                bool IsSuccess = await Work(
                        tempAccount.Username, tempAccount.Fullname,
                        tempAccount.Password, tempAccount.RoleName,
                        tempAccount.IsMale, tempAccount.ImagePath,
                        tempAccount.Dateofbirth, tempAccount.Grade,
                        tempAccount.Email
                );
                Panel formPanel = (Panel)(this.Parent);
                formPanel.Controls.Clear();
                Control uc = new AfterCreateAccount(IsSuccess);
                uc.Dock = DockStyle.Fill;
                formPanel.Controls.Add(uc);
            }
            else
                if (isUnValid == -1)
            {
                currentTextBox = 0;
                isUnValid *= -1;
                turnValidation(isUnValid);
            }

        }
    }
}
