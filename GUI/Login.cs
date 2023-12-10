using System.Data;
using System.Diagnostics;
using BUS;
using GUI;
using ENUM;
using DTO;

namespace QuizGameGroup5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameTXB.Text;
            string password = pwdTXB.Text;
            int role = comboBox1.SelectedIndex + 1;
            DataTable sessionInfomation = LoginBus.
                                          Instance.
                                          getUserInformation(username, password, role);
            if (sessionInfomation.Rows.Count > 0)
            {
                Account loginSession = new Account(sessionInfomation.Rows[0]);
                this.Hide();
                MainForm mainForm = new MainForm(loginSession);
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show(
                    "Sai thông tin đăng nhập",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccountForm = new CreateAccount();
            createAccountForm.ShowDialog();
            usernameTXB.Text = "";
            pwdTXB.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn muốn thoát chương trình chứ ?",
                "Thoát chương trình",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}