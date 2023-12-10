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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            initialize();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            dc.DrawImageUnscaled(Background, 320, 0);
            base.OnPaint(e);
        }

        Bitmap Background, Backgroundtemp;
        private void initialize()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            Backgroundtemp = new Bitmap(Properties.Resources.wallpaperflare_com_wallpaper);
            Background = new Bitmap(Backgroundtemp, Backgroundtemp.Width, Backgroundtemp.Height);
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Add(new LoginModule());
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
