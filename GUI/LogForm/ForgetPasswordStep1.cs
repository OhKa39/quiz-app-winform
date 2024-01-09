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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class ForgetPasswordStep1 : UserControl
    {
        AccountRequest tempAccount;
        public ForgetPasswordStep1()
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

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string email = guna2TextBox2.Text;
                var result = await LoginBus.Instance.getEmail(email) == 0;

                if (result)
                {
                    guna2HtmlLabel1.Visible = true;
                    turnOffValidateEffectTextBox(
                        guna2HtmlLabel1, guna2TextBox2,
                        "Không tồn tại địa chỉ email này",
                        true
                    );
                    return;
                }

                Panel formPanel = (Panel)(this.Parent);
                formPanel.Controls.Clear();
                Control uc = new VerifyEmailStep(tempAccount);
                ((VerifyEmailStep)uc).Type = 2;
                uc.Dock = DockStyle.Fill;
                formPanel.Controls.Add(uc);
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

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Visible = false;
            guna2HtmlLabel1.Visible = true;
            turnOffValidateEffectTextBox(
                guna2HtmlLabel1, guna2TextBox2,
                "Không tồn tại địa chỉ email này",
                false
            );
        }

        private void guna2TextBox2_Load(object sender, EventArgs e)
        {
            guna2TextBox2.DataBindings.Add("Text", tempAccount, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            Control uc = new LoginModule();
            uc.Dock = DockStyle.Fill;
            formPanel.Controls.Add(uc);
        }
    }
}
