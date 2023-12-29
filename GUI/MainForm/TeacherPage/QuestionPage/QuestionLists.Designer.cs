namespace GUI.MainForm.TeacherPage
{
    partial class QuestionLists
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
            guna2RadioButton1 = new Guna.UI2.WinForms.Guna2RadioButton();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // guna2RadioButton1
            // 
            guna2RadioButton1.AutoSize = true;
            guna2RadioButton1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2RadioButton1.CheckedState.BorderThickness = 0;
            guna2RadioButton1.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            guna2RadioButton1.CheckedState.InnerColor = Color.White;
            guna2RadioButton1.CheckedState.InnerOffset = -4;
            guna2RadioButton1.Location = new Point(9, 4);
            guna2RadioButton1.Name = "guna2RadioButton1";
            guna2RadioButton1.Size = new Size(33, 19);
            guna2RadioButton1.TabIndex = 0;
            guna2RadioButton1.Text = "A";
            guna2RadioButton1.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            guna2RadioButton1.UncheckedState.BorderThickness = 2;
            guna2RadioButton1.UncheckedState.FillColor = Color.Transparent;
            guna2RadioButton1.UncheckedState.InnerColor = Color.Transparent;
            guna2RadioButton1.CheckedChanged += guna2RadioButton1_CheckedChanged;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "\r\n";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(48, 6);
            guna2TextBox1.Multiline = true;
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.ScrollBars = ScrollBars.Both;
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(419, 62);
            guna2TextBox1.TabIndex = 1;
            // 
            // QuestionLists
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2TextBox1);
            Controls.Add(guna2RadioButton1);
            Name = "QuestionLists";
            Size = new Size(470, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
