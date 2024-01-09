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
using ValidateRules;
using FluentValidation.Results;
using BUS;
using DTO;
using ENUM;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.Threading;

namespace GUI
{
    public partial class RegisterComponentStep2 : UserControl
    {
        private AccountRequest tempAccount;
        private List<int> allOK;
        private AccountRequestValidator validator = new AccountRequestValidator();

        public RegisterComponentStep2(AccountRequest _tempAccount, List<int> _allOK)
        {
            tempAccount = _tempAccount;
            allOK = _allOK;
            InitializeComponent();
        }

        #region ownmethod
        private void enableButton(Guna2Button btn)
        {
            if (allOK.Sum() == 10)
            {
                btn.Enabled = true;
                return;
            }

            btn.Enabled = false;
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

        public void turnOffValidateEffectTimePicker
        (
            Guna2HtmlLabel lb, Guna2DateTimePicker dtp,
            string mess = null, bool mode = false
        )
        {
            Color fillColor;
            Color borderColor;

            if (mode)
            {
                fillColor = Color.Violet;
                dtp.FillColor = fillColor;
                borderColor = System.Drawing
                    .ColorTranslator
                    .FromHtml("#ebbfef");
                dtp.BorderColor = borderColor;
                lb.Text = mess;
                lb.Visible = true;
                return;
            }

            fillColor = Color.FromArgb(94, 148, 255);
            dtp.FillColor = fillColor;
            borderColor = Color.FromArgb(0, 0, 0);
            dtp.BorderColor = borderColor;
            lb.Visible = false;
        }

        public void turnOffValidateEffectImageButton
        (
            Guna2HtmlLabel lb,
            string mess = null, bool mode = false
        )
        {
            if (mode)
            {
                lb.Text = mess;
                lb.Visible = true;
                return;
            }
            lb.Visible = false;
        }

        private async Task<bool> showErrorMessage
        (
            AccountRequest tempAcc, string attr,
            Guna2HtmlLabel lb, Guna2TextBox txb,
            Guna2ComboBox cb, Guna2DateTimePicker dtp, string type
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
                    case "datetimepicker":
                        turnOffValidateEffectTimePicker(lb, dtp, message, true);
                        return true;
                    case "imagebutton":
                        turnOffValidateEffectImageButton(lb, message, true);
                        return true;
                }
            }

            return false;
        }
        #endregion

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            //Button thisTB = sender as Button;
            openFileDialog1.Filter = "Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = openFileDialog1.FileName;
                Image image = Image.FromFile(sourceFile);
                guna2ImageButton1.Image = image;
                tempAccount.ImagePath = sourceFile;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new RegisterComponentStep1(tempAccount, allOK);
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private async void RegisterComponentStep2_Load(object sender, EventArgs e)
        {
            enableButton(guna2Button2);
            guna2Button2.Enabled = false;
            int? schoolYearID = await LoginBus.Instance.getCurrentSchoolYearID();
            DataTable grade = await LoginBus.Instance.loadClass(schoolYearID);
            foreach (var i in grade.Rows)
            {
                DataRow row = (DataRow)i;
                guna2ComboBox1.Items.Add(row["ClassName"]);
            }

            if (tempAccount.ImagePath != null)
                guna2ImageButton1.Image = Image.FromFile(tempAccount.ImagePath);
            guna2ComboBox1.DataBindings.Add("SelectedItem", tempAccount, "Grade", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2TextBox1.DataBindings.Add("Text", tempAccount, "Fullname", false, DataSourceUpdateMode.OnPropertyChanged);
            guna2DateTimePicker1.DataBindings.Add("Value", tempAccount, "Dateofbirth", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new VerifyEmailStep(tempAccount, allOK);
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }

        private async void guna2ComboBox1_Leave(object sender, EventArgs e)
        {
            tempAccount.Grade = (string)guna2ComboBox1.SelectedItem;
            if
            (
                !await showErrorMessage
                (
                    tempAccount, "Grade",
                    guna2HtmlLabel5, null,
                    guna2ComboBox1, null, "combobox"
                )
            )
            {
                turnOffValidateEffectComboBox(guna2HtmlLabel5, guna2ComboBox1);
                allOK[6] = 1;

            }
            else
                allOK[6] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2DateTimePicker1_Leave(object sender, EventArgs e)
        {
            //tempAccount.Date = (string)guna2ComboBox1.SelectedItem;
            if
            (
                !await showErrorMessage
                (
                    tempAccount, "Dateofbirth",
                    guna2HtmlLabel4, null,
                    null, guna2DateTimePicker1, "datetimepicker"
                )
            )
            {
                turnOffValidateEffectTimePicker(guna2HtmlLabel4, guna2DateTimePicker1);
                allOK[7] = 1;

            }
            else
                allOK[7] = 0;
            enableButton(guna2Button2);
        }

        private async void RegisterComponentStep2_Click(object sender, EventArgs e)
        {
            if
            (
                !await showErrorMessage
                (
                    tempAccount, "ImagePath",
                    guna2HtmlLabel2, null,
                    null, null, "imagebutton"
                )
            )
            {
                turnOffValidateEffectImageButton(guna2HtmlLabel2);
                allOK[8] = 1;

            }
            else
                allOK[8] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if
            (
                !await showErrorMessage
                (
                    tempAccount, "Fullname",
                    guna2HtmlLabel3, guna2TextBox1,
                    null, null, "textbox"
                )
            )
            {
                turnOffValidateEffectTextBox(guna2HtmlLabel3, guna2TextBox1);
                allOK[9] = 1;
            }
            else
                allOK[9] = 0;
            enableButton(guna2Button2);
        }

        private async void guna2ImageButton1_Leave(object sender, EventArgs e)
        {
            if
            (
                !await showErrorMessage
                (
                    tempAccount, "ImagePath",
                    guna2HtmlLabel2, null,
                    null, null, "imagebutton"
                )
            )
            {
                turnOffValidateEffectImageButton(guna2HtmlLabel2);
                allOK[8] = 1;

            }
            else
                allOK[8] = 0;
            enableButton(guna2Button2);
        }
    }

}
