using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class RegisterComponentStep1 : UserControl
    {
        public RegisterComponentStep1()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegisterComponent_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            formPanel.Controls.Add(new LoginModule());
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Panel formPanel = (Panel)(this.Parent);
            formPanel.Controls.Clear();
            formPanel.Controls.Add(new RegisterComponentStep2());
        }
    }
}
