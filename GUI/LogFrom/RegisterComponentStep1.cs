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
using DTO;
using ValidateRules;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Guna.UI2.WinForms;
using System.CodeDom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class RegisterComponentStep1 : UserControl
    {
        private AccountRequest tempAccount;
        private AccountRequestValidator validator = new AccountRequestValidator();
        private int passwordShowState = 1;
        private List<int> allOK;

        public RegisterComponentStep1()
        {
            tempAccount = new AccountRequest();
            allOK = Enumerable.Repeat(0, 10).ToList();
            InitializeComponent();
        }

        public RegisterComponentStep1(
            AccountRequest _tempAccount,
            List<int> _allOK
        )
        {
            allOK = _allOK;
            tempAccount = _tempAccount;
            InitializeComponent();
        }

        #region ownmethod
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
        public void turnOffValidateEffectComboBox
        (
            Guna2HtmlLabel lb, Guna2ComboBox cb,
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
                cb.FillColor = fillColor;
                borderColor = System.Drawing
                    .ColorTranslator
                    .FromHtml("#ebbfef");
                cb.BorderColor = borderColor;
                lb.Text = mess;
                lb.Visible = true;
                return;
            }

            fillColor = Color.FromArgb(237, 237, 237);
            cb.FillColor = fillColor;
            borderColor = Color.FromArgb(213, 218, 223);
            cb.BorderColor = borderColor;
            lb.Visible = false;
        }
        private async Task<bool> showErrorMessage
        (
            AccountRequest tempAcc, string attr,
            Guna2HtmlLabel lb, Guna2TextBox txb,
            Guna2ComboBox cb, string type
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
            }

            if (isError)
            {
                switch (type)
                {
                    case "textbox":
                        turnOffValidateEffectTextBox(lb, txb, message, true);
                        return true;
                    case "combobox":
                        turnOffValidateEffectComboBox(lb, cb, message, true);
                        return true;
                }
            }

            return false;
        }

        private void enableButton(Guna2Button btn)
        {
            if (allOK.Take(6).Sum() == 6)
            {
                btn.Enabled = true;
                return;
            }

            btn.Enabled = false;
        }

        #endregion

        private void RegisterComponent_Load(object sender, EventArgs e)
        {
            enableButton(guna2Button2);
            guna2TextBox1.DataBindings.Add("Text", tempAccount, "Username", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox2.DataBindings.Add("Text", tempAccount, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox3.DataBindings.Add("Text", tempAccount, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox4.DataBindings.Add("Text", tempAccount, "PasswordConfirm", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2ComboBox1.DataBindings.Add("SelectedItem", tempAccount, "RoleName", false, DataSourceUpdateMode.OnValidation);
            guna2ComboBox2.DataBindings.Add("SelectedItem", tempAccount, "IsMale", false, DataSourceUpdateMode.OnValidation);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new LoginModule();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new RegisterComponentStep2(tempAccount, allOK);
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private void guna2TextBox3_IconRightClick(object sender, EventArgs e)
        {
            if (passwordShowState == 1)
            {
                guna2TextBox3.PasswordChar = '\0';
                guna2TextBox4.PasswordChar = '\0';
                guna2TextBox3.IconRight = Properties.Resources.icons8_hide_30;
                passwordShowState *= -1;
                return;
            }

            passwordShowState *= -1;
            guna2TextBox3.PasswordChar = '*';
            guna2TextBox4.PasswordChar = '*';
            guna2TextBox3.IconRight = Properties.Resources.icons8_eye_30;
        }

        private async void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "Username",
                    guna2HtmlLabel2, guna2TextBox1,
                    null, "textbox"
                )
            )
            {
                turnOffValidateEffectTextBox(guna2HtmlLabel2, guna2TextBox1);
                allOK[0] = 1;
            }
            else
                allOK[0] = 0;
            enableButton(guna2Button2);
        }

        private void RegisterComponentStep1_Click(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Focus();
        }

        private async void guna2TextBox2_Leave(object sender, EventArgs e)
        {
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "Email",
                    guna2HtmlLabel3, guna2TextBox2,
                    null, "textbox"
                )
            )
            {
                turnOffValidateEffectTextBox(guna2HtmlLabel3, guna2TextBox2);
                allOK[1] = 1;

            }
            else
                allOK[1] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2TextBox3_Leave(object sender, EventArgs e)
        {
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "Password",
                    guna2HtmlLabel4, guna2TextBox3,
                    null, "textbox"
                )
            )
            {
                turnOffValidateEffectTextBox(guna2HtmlLabel4, guna2TextBox3);
                if (guna2TextBox3.Text == guna2TextBox4.Text)
                {
                    Color fillColor = Color.FromArgb(237, 237, 237);
                    guna2TextBox4.FillColor = fillColor;
                    Color borderColor = Color.FromArgb(213, 218, 223);
                    guna2TextBox4.BorderColor = borderColor;
                    guna2TextBox4.IconLeft = null;
                    guna2HtmlLabel5.Visible = false;
                    allOK[3] = 1;
                }
                allOK[2] = 1;
            }
            else
                allOK[2] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2TextBox4_Leave(object sender, EventArgs e)
        {
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "PasswordConfirm",
                    guna2HtmlLabel5, guna2TextBox4,
                    null, "textbox"
                )
            )
            {
                if (guna2TextBox3.Text == guna2TextBox4.Text)
                {
                    turnOffValidateEffectTextBox(guna2HtmlLabel5, guna2TextBox4);
                    Color fillColor = Color.FromArgb(237, 237, 237);
                    guna2TextBox3.FillColor = fillColor;
                    Color borderColor = Color.FromArgb(213, 218, 223);
                    guna2TextBox3.BorderColor = borderColor;
                    guna2TextBox3.IconLeft = null;
                    guna2HtmlLabel4.Visible = false;
                    allOK[2] = 1;
                }
                allOK[3] = 1;

            }
            else
                allOK[3] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2ComboBox1_Leave(object sender, EventArgs e)
        {
            tempAccount.RoleName = (string)guna2ComboBox1.SelectedItem;
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "RoleName",
                    guna2HtmlLabel6, null,
                    guna2ComboBox1, "combobox"
                )
            )
            {
                turnOffValidateEffectComboBox(guna2HtmlLabel6, guna2ComboBox1);
                allOK[4] = 1;

            }
            else
                allOK[4] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2ComboBox2_Leave(object sender, EventArgs e)
        {
            tempAccount.IsMale = (string)guna2ComboBox2.SelectedItem;
            if
            (
                ! await showErrorMessage
                (
                    tempAccount, "IsMale",
                    guna2HtmlLabel7, null,
                    guna2ComboBox2, "combobox"
                )
            )
            {
                turnOffValidateEffectComboBox(guna2HtmlLabel7, guna2ComboBox2);
                allOK[5] = 1;

            }
            else
                allOK[5] = 0;
            enableButton(guna2Button2);
        }

        private void guna2TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2TextBox2.Focus();
                e.IsInputKey = true;
            }
        }

        private void guna2TextBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2TextBox3.Focus();
                e.IsInputKey = true;
            }
        }

        private void guna2TextBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2TextBox4.Focus();
                e.IsInputKey = true;
            }
        }

        private void guna2TextBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2ComboBox1.Focus();
                e.IsInputKey = true;
            }
        }

        private void guna2ComboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                guna2ComboBox2.Focus();
                e.IsInputKey = true;
            }
        }
    }
}
