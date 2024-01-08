namespace GUI.MainForm.QuestionSetManage.QuestionSetDivPage
{
    partial class QuestionPopUp
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.Location = new Point(0, 30);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(520, 645);
            guna2Panel1.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BackColor = Color.Transparent;
            guna2ControlBox1.Cursor = Cursors.Hand;
            guna2ControlBox1.CustomizableEdges = customizableEdges7;
            guna2ControlBox1.FillColor = Color.White;
            guna2ControlBox1.HoverState.FillColor = Color.Tomato;
            guna2ControlBox1.HoverState.IconColor = Color.White;
            guna2ControlBox1.IconColor = Color.Black;
            guna2ControlBox1.Location = new Point(473, -1);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2ControlBox1.Size = new Size(45, 30);
            guna2ControlBox1.TabIndex = 47;
            // 
            // guna2ControlBox2
            // 
            guna2ControlBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox2.BackColor = Color.Transparent;
            guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            guna2ControlBox2.Cursor = Cursors.Hand;
            guna2ControlBox2.CustomizableEdges = customizableEdges9;
            guna2ControlBox2.FillColor = Color.White;
            guna2ControlBox2.HoverState.FillColor = Color.Tomato;
            guna2ControlBox2.HoverState.IconColor = Color.White;
            guna2ControlBox2.IconColor = Color.Black;
            guna2ControlBox2.Location = new Point(426, -1);
            guna2ControlBox2.Name = "guna2ControlBox2";
            guna2ControlBox2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2ControlBox2.Size = new Size(45, 30);
            guna2ControlBox2.TabIndex = 48;
            // 
            // QuestionPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 675);
            Controls.Add(guna2ControlBox2);
            Controls.Add(guna2ControlBox1);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuestionPopUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuestionPopUp";
            Load += QuestionPopUp_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    }
}