using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginModule : UserControl
    {
        private int passwordShowState = 1;
        public LoginModule()
        {
            InitializeComponent();
        }

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            formPanel.Controls.Add(new RegisterComponentStep1());
            
        }
    }
}
