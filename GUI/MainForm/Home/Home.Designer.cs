namespace GUI.MainForm.Home
{
    partial class Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2CircleProgressBar1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.FromArgb(0, 120, 212);
            guna2HtmlLabel1.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(24, 36);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(361, 58);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Xin chào, Khoa";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(24, 174);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(798, 461);
            guna2Panel1.TabIndex = 1;
            // 
            // guna2CircleProgressBar1
            // 
            guna2CircleProgressBar1.Controls.Add(guna2HtmlLabel4);
            guna2CircleProgressBar1.FillColor = Color.FromArgb(200, 213, 218, 223);
            guna2CircleProgressBar1.Font = new Font("Segoe UI", 12F);
            guna2CircleProgressBar1.ForeColor = Color.White;
            guna2CircleProgressBar1.Location = new Point(886, 317);
            guna2CircleProgressBar1.Minimum = 0;
            guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            guna2CircleProgressBar1.ProgressColor = Color.FromArgb(94, 148, 255);
            guna2CircleProgressBar1.ProgressColor2 = Color.LightSeaGreen;
            guna2CircleProgressBar1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleProgressBar1.Size = new Size(151, 151);
            guna2CircleProgressBar1.TabIndex = 0;
            guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.AutoSize = false;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = Color.FromArgb(94, 148, 255);
            guna2HtmlLabel4.Location = new Point(0, 0);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(151, 151);
            guna2HtmlLabel4.TabIndex = 4;
            guna2HtmlLabel4.Text = "67.27%";
            guna2HtmlLabel4.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.White;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(94, 148, 255);
            guna2HtmlLabel2.Location = new Point(862, 288);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(203, 23);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Tỉ lệ bài thi đã hoàn thành";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2CircleProgressBar1);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2HtmlLabel1);
            Name = "Home";
            Size = new Size(1090, 690);
            Load += Home_Load;
            guna2CircleProgressBar1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
    }
}
