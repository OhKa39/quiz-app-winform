using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI.MainForm.Home
{

    public partial class UserInformation : UserControl
    {
        AccountResponse acc;
        public UserInformation(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = acc.Fullname;
            guna2TextBox2.Text = acc.Dateofbirth.ToString("dd/MM/yyyy");
            guna2TextBox3.Text = acc.Username;
            guna2TextBox4.Text = acc.IsMale == true ? "Nam" : "Nữ";
            guna2TextBox5.Text = acc.Grade;
            guna2TextBox6.Text = acc.RoleName;
            guna2ImageButton1.Image = Utils.ConvertFile.convertByteToImage(acc.Image);
        }
    }
}
