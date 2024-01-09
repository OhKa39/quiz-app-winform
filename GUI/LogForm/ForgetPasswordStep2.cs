using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using Guna.UI2.WinForms;
using ValidateRules;
using static Guna.UI2.WinForms.Suite.Descriptions;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace GUI
{
    public partial class ForgetPasswordStep2 : UserControl
    {
        private AccountRequest tempAccount;
        private string email;
        private AccountRequestValidator validator = new AccountRequestValidator();

        public string Email { get => email; set => email = value; }

        public ForgetPasswordStep2()
        {
            tempAccount = new AccountRequest();
            InitializeComponent();
        }

        public void turnOffValidateEffectTextBox
        (
            Guna2HtmlLabel lb, Guna2TextBox txb,
            string mess = null, bool mode = false
        )
        {
            Color fillColor;
            Color borderColor;

            if (mode)
            {
                fillColor = System.Drawing
                                  .ColorTranslator
                                  .FromHtml("#f4e3f5");
                txb.FillColor = fillColor;
                borderColor = System.Drawing
                    .ColorTranslator
                    .FromHtml("#ebbfef");
                txb.BorderColor = borderColor;
                txb.IconLeft = Properties.Resources.emergency;
                lb.Text = mess;
                lb.Visible = true;
                return;
            }

            fillColor = Color.FromArgb(237, 237, 237);
            txb.FillColor = fillColor;
            borderColor = Color.FromArgb(213, 218, 223);
            txb.BorderColor = borderColor;
            txb.IconLeft = null;
            lb.Visible = false;
        }

        private async Task<bool> showErrorMessage
        (
            AccountRequest tempAcc, string attr,
            Guna2HtmlLabel lb, Guna2TextBox txb
        )
        {
            ValidationResult results = await validator.ValidateAsync(tempAccount);
            string message = "";
            bool isError = false;
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    if (failure.PropertyName == attr)
                    {
                        isError = true;
                        message = failure.ErrorMessage;
                        break;
                    }
                }

                if (isError)
                {
                    turnOffValidateEffectTextBox(lb, txb, message, true);
                    return true;
                }
            }
            return false;
        }

        private void ForgetPasswordStep2_Load(object sender, EventArgs e)
        {
            guna2TextBox3.DataBindings.Add("Text", tempAccount, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox4.DataBindings.Add("Text", tempAccount, "PasswordConfirm", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new LoginModule();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            if (guna2TextBox3.PasswordChar == '*')
            {
                guna2TextBox3.PasswordChar = '\0';
                guna2TextBox4.PasswordChar = '\0';
                guna2TextBox3.IconRight = Properties.Resources.icons8_hide_30;
                return;
            }

            guna2TextBox3.PasswordChar = '*';
            guna2TextBox4.PasswordChar = '*';
            guna2TextBox3.IconRight = Properties.Resources.icons8_eye_30;
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            bool notOk1 = await showErrorMessage
                (
                    tempAccount, "Password",
                    guna2HtmlLabel4, guna2TextBox3
                );

            bool notOk2 = await showErrorMessage
                (
                    tempAccount, "PasswordConfirm",
                    guna2HtmlLabel5, guna2TextBox4
                );
            if (notOk1 || notOk2)
                return;

            if(!notOk1 && !notOk2)
            {
                try
                {
                    string alert = null;
                    string password = guna2TextBox3.Text;
                    bool IsSuccess = await LoginBus
                        .Instance.updateUserPassword(email, password);
                    if (!IsSuccess)
                        alert = "Quá trình khôi phục tài khoản thất bại. Hãy thử lại";
                    else
                        alert = "Quá trình khôi phục tài khoản thành công. Hãy đăng nhập lại nào";
                    Panel formPanel = (Panel)(this.Parent);
                    formPanel.Controls.Clear();
                    Control uc = new NotificationForm(IsSuccess, alert);
                    uc.Dock = DockStyle.Fill;
                    formPanel.Controls.Add(uc);
                }
                catch(Exception ex)
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
}
