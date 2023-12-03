namespace QuizGameGroup5
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel5 = new Panel();
            label3 = new Label();
            comboBox1 = new ComboBox();
            panel4 = new Panel();
            exitButton = new Button();
            button2 = new Button();
            createAccountButton = new Button();
            panel3 = new Panel();
            pwdTXB = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            usernameTXB = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(29, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(656, 192);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Controls.Add(comboBox1);
            panel5.Location = new Point(17, 118);
            panel5.Name = "panel5";
            panel5.Size = new Size(260, 55);
            panel5.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 17);
            label3.Name = "label3";
            label3.Size = new Size(55, 24);
            label3.TabIndex = 3;
            label3.Text = "Role";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(138, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(104, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(exitButton);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(createAccountButton);
            panel4.Location = new Point(283, 118);
            panel4.Name = "panel4";
            panel4.Size = new Size(356, 55);
            panel4.TabIndex = 4;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(266, 16);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 2;
            exitButton.Text = "Thoát";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(147, 16);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Đăng nhập";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // createAccountButton
            // 
            createAccountButton.Location = new Point(15, 16);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(89, 23);
            createAccountButton.TabIndex = 0;
            createAccountButton.Text = "Tạo tài khoản";
            createAccountButton.UseVisualStyleBackColor = true;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pwdTXB);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(17, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(622, 35);
            panel3.TabIndex = 3;
            // 
            // pwdTXB
            // 
            pwdTXB.Location = new Point(138, 7);
            pwdTXB.Name = "pwdTXB";
            pwdTXB.Size = new Size(469, 23);
            pwdTXB.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(11, 6);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // panel2
            // 
            panel2.Controls.Add(usernameTXB);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(17, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(622, 35);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // usernameTXB
            // 
            usernameTXB.Location = new Point(138, 7);
            usernameTXB.Name = "usernameTXB";
            usernameTXB.Size = new Size(469, 23);
            usernameTXB.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(11, 6);
            label1.Name = "label1";
            label1.Size = new Size(109, 24);
            label1.TabIndex = 1;
            label1.Text = "Tài khoản";
            label1.Click += label1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 230);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox pwdTXB;
        private Label label2;
        private TextBox usernameTXB;
        private Label label1;
        private Panel panel4;
        private Button exitButton;
        private Button button2;
        private Button createAccountButton;
        private Panel panel5;
        private ComboBox comboBox1;
        private Label label3;
    }
}