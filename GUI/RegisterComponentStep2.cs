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
    public partial class RegisterComponentStep2 : UserControl
    {
        public RegisterComponentStep2()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            formPanel.Controls.Add(new RegisterComponentStep1());
        }
    }
}
