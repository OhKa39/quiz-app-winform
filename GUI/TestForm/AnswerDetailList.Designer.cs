namespace GUI.TestForm
{
    partial class AnswerDetailList
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
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2RadioButton1 = new Guna.UI2.WinForms.Guna2RadioButton();
            SuspendLayout();
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.AutoScroll = true;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.White;
            guna2TextBox1.DisabledState.ForeColor = Color.Black;
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.Enabled = false;
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(50, 1);
            guna2TextBox1.Multiline = true;
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(797, 97);
            guna2TextBox1.TabIndex = 0;
            // 
            // guna2RadioButton1
            // 
            guna2RadioButton1.AutoSize = true;
            guna2RadioButton1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2RadioButton1.CheckedState.BorderThickness = 0;
            guna2RadioButton1.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            guna2RadioButton1.CheckedState.InnerColor = Color.White;
            guna2RadioButton1.CheckedState.InnerOffset = -4;
            guna2RadioButton1.Enabled = false;
            guna2RadioButton1.Location = new Point(11, 3);
            guna2RadioButton1.Name = "guna2RadioButton1";
            guna2RadioButton1.Size = new Size(33, 19);
            guna2RadioButton1.TabIndex = 1;
            guna2RadioButton1.Text = "A";
            guna2RadioButton1.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            guna2RadioButton1.UncheckedState.BorderThickness = 2;
            guna2RadioButton1.UncheckedState.FillColor = Color.Transparent;
            guna2RadioButton1.UncheckedState.InnerColor = Color.Transparent;
            guna2RadioButton1.CheckedChanged += guna2RadioButton1_CheckedChanged_1;
            // 
            // AnswerDetailList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2RadioButton1);
            Controls.Add(guna2TextBox1);
            Name = "AnswerDetailList";
            Size = new Size(850, 100);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        public Guna.UI2.WinForms.Guna2RadioButton guna2RadioButton1;
    }
}
