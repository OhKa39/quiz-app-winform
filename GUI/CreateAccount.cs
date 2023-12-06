using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ENUM;

namespace GUI
{
    public partial class CreateAccount : Form
    {
        private bool usernameCheck = false;
        private bool fullnameCheck = false;
        private bool passCheck = false;
        private bool pass2Check = false;
        public CreateAccount()
        {
            InitializeComponent();
        }

        #region ownmethod
        public static bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        public static bool IsValidUsername(string plainText)
        {
            Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9_]{7,29}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        public static bool IsValidFullname(string plainText)
        {
            Regex regex = new Regex(@"^[A-Z][a-zA-Z]{3,}(?: [A-Z][a-zA-Z]*){0,2}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        public bool checkActiveButton()
        {
            return button2.Enabled;
        }
        public void turnOnButton()
        {
            if (!checkActiveButton())
            {
                button2.Enabled = true;
            }
        }
        public void turnOffButton()
        {
            if (checkActiveButton())
            {
                button2.Enabled = false;
            }
        }

        public bool validation()
        {
            return usernameCheck && pass2Check && passCheck && fullnameCheck;
        }

        public void dovalidation()
        {
            if (validation())
                turnOnButton();
            else
                turnOffButton();
        }
        #endregion

        #region UICODE
        private void CreateAccount_Load(object sender, EventArgs e)
        {
            roleComboBox.SelectedIndex = 0;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameTXB.Text.Trim();
            string password = passwordTXB.Text.Trim();
            string fullname = fullnameTXB.Text.Trim();
            int role = 0;
            for (int i = 0; i < 3; ++i)
            {
                if (Enum.GetName(typeof(Role), i) as string == roleComboBox.Text)
                {
                    role = i + 1;
                    break;
                }
            }

            bool isSuccess = CreateAccountBus
                .Instance
                .CreateAccount(username, password, fullname, role);

            if (isSuccess)
            {
                MessageBox.Show(
                    "Đăng ký thành công",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                this.Hide();
            }
            else
                MessageBox.Show(
                    "Đăng ký thất bại",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void passwordTXB_TextChanged(object sender, EventArgs e)
        {
            TextBox thistextBox = sender as TextBox;
            if (IsValidPassword(thistextBox.Text))
            {
                thistextBox.ForeColor = Color.Green;
                if (thistextBox.Text.Equals(passwordcheckTXB.Text))
                {
                    pass2Check = true;
                    passwordcheckTXB.ForeColor = Color.Green;
                }
                else
                {
                    pass2Check = false;
                    passwordcheckTXB.ForeColor = Color.Red;
                }
                passCheck = true;
                dovalidation();
            }
            else
            {
                thistextBox.ForeColor = Color.Red;
                pass2Check = false;
                passwordcheckTXB.ForeColor = Color.Red;
                passCheck = false;
                dovalidation();
            }

        }

        private void passwordcheckTXB_TextChanged(object sender, EventArgs e)
        {
            TextBox thistextBox = sender as TextBox;
            if (IsValidPassword(thistextBox.Text) && thistextBox.Text.Equals(passwordTXB.Text))
            {
                thistextBox.ForeColor = Color.Green;
                pass2Check = true;
                dovalidation();
            }
            else
            {
                thistextBox.ForeColor = Color.Red;
                pass2Check = false;
                dovalidation();

            }
        }

        private void usernameTXB_TextChanged(object sender, EventArgs e)
        {
            TextBox thistextBox = sender as TextBox;
            if (IsValidUsername(thistextBox.Text))
            {
                thistextBox.ForeColor = Color.Green;
                usernameCheck = true;
                dovalidation();
            }
            else
            {
                thistextBox.ForeColor = Color.Red;
                usernameCheck = false;
                dovalidation();
            }
        }

        private void fullnameTXB_TextChanged(object sender, EventArgs e)
        {
            TextBox thistextBox = sender as TextBox;
            if (IsValidFullname(thistextBox.Text))
            {
                thistextBox.ForeColor = Color.Green;
                fullnameCheck = true;
                dovalidation();
            }
            else
            {
                thistextBox.ForeColor = Color.Red;
                fullnameCheck = false;
                dovalidation();
            }
        }
        #endregion
    }
}
