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
using Guna.UI2.WinForms;

namespace GUI.MainForm.ValidateManage
{
    public partial class ValidateManageP : UserControl
    {
        AccountResponse acc;
        public ValidateManageP(AccountResponse _acc)
        {
            acc = _acc;
            InitializeComponent();
        }

        private void ValidateManageP_Load(object sender, EventArgs e)
        {
            Control uc = new ValidateComponent(acc);
            uc.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(uc);
        }
    }
}
