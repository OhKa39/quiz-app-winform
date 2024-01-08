namespace GUI.MainForm.Home
{
    partial class TestList
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2vScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(14, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(727, 428);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // guna2vScrollBar1
            // 
            guna2vScrollBar1.InUpdate = false;
            guna2vScrollBar1.LargeChange = 10;
            guna2vScrollBar1.Location = new Point(767, 12);
            guna2vScrollBar1.Name = "guna2vScrollBar1";
            guna2vScrollBar1.ScrollbarSize = 18;
            guna2vScrollBar1.Size = new Size(18, 428);
            guna2vScrollBar1.TabIndex = 0;
            // 
            // TestList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2vScrollBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "TestList";
            Size = new Size(798, 461);
            Load += TestList_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar1;
    }
}
