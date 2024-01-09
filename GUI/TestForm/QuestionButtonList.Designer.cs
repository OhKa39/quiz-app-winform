using Guna.UI2.WinForms;

namespace GUI.TestForm
{
    partial class QuestionButtonList
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            guna2Button1 = new Guna2Button();
            guna2vScrollBar1 = new Guna2VScrollBar();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(10, 42);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(293, 529);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(97, 9);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(129, 22);
            guna2HtmlLabel1.TabIndex = 14;
            guna2HtmlLabel1.Text = "Danh sách câu hỏi";
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(71, 588);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(180, 45);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Nộp bài thi";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2vScrollBar1
            // 
            guna2vScrollBar1.InUpdate = false;
            guna2vScrollBar1.LargeChange = 10;
            guna2vScrollBar1.Location = new Point(314, 42);
            guna2vScrollBar1.Name = "guna2vScrollBar1";
            guna2vScrollBar1.ScrollbarSize = 13;
            guna2vScrollBar1.Size = new Size(13, 529);
            guna2vScrollBar1.TabIndex = 0;
            // 
            // QuestionButtonList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2vScrollBar1);
            Controls.Add(guna2Button1);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(flowLayoutPanel1);
            Name = "QuestionButtonList";
            Size = new Size(330, 720);
            Load += QuestionButtonList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2Button guna2Button1;
        private Guna2VScrollBar guna2vScrollBar1;

        public FlowLayoutPanel FlowLayoutPanel1
        {
            get => flowLayoutPanel1;
        }

        public Guna2Button Guna2Button1
        {
            get => guna2Button1;
        }
    }
}
