using Guna.UI2.WinForms;

namespace GUI.MainForm.QuestionSetManage.QuestionSetDivPage
{
    partial class QuestionSetDiv
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna2Panel();
            guna2Panel2 = new Guna2Panel();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Left;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(570, 645);
            guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            guna2Panel2.CustomizableEdges = customizableEdges3;
            guna2Panel2.Dock = DockStyle.Right;
            guna2Panel2.Location = new Point(570, 0);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel2.Size = new Size(520, 645);
            guna2Panel2.TabIndex = 0;
            // 
            // QuestionSetDiv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            Name = "QuestionSetDiv";
            Size = new Size(1090, 645);
            Load += QuestionSetDiv_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna2Panel guna2Panel1;
        private Guna2Panel guna2Panel2;

        public Guna2Panel Guna2Panel1
        {
            get => guna2Panel1;
        }
    }
}
