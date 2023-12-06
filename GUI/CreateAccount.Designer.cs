namespace GUI
{
    partial class CreateAccount
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
            panel1 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            panel7 = new Panel();
            roleComboBox = new ComboBox();
            label5 = new Label();
            panel6 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel5 = new Panel();
            passwordcheckTXB = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            passwordTXB = new TextBox();
            label3 = new Label();
            panel3 = new Panel();
            fullnameTXB = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            usernameTXB = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(32, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(610, 536);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label8.Location = new Point(244, 75);
            label8.Name = "label8";
            label8.Size = new Size(288, 15);
            label8.TabIndex = 7;
            label8.Text = "* Ít nhất 8 kí tự, không chứa các kí tự đặc biệt ở đầu\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label7.Location = new Point(244, 154);
            label7.Name = "label7";
            label7.Size = new Size(293, 15);
            label7.TabIndex = 6;
            label7.Text = "*Chữ cái đầu viết hoa, không chứa các kí tự đặc biệt\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(244, 231);
            label6.Name = "label6";
            label6.Size = new Size(309, 30);
            label6.TabIndex = 2;
            label6.Text = "* Ít nhất 8 kí tự và chứa ít nhất 1 kí tự đặc biệt, 1 kí tự in \r\n   hoa, 1 kí tự thường và 1 chữ số\r\n";
            // 
            // panel7
            // 
            panel7.Controls.Add(roleComboBox);
            panel7.Controls.Add(label5);
            panel7.Location = new Point(22, 343);
            panel7.Name = "panel7";
            panel7.Size = new Size(553, 83);
            panel7.TabIndex = 2;
            // 
            // roleComboBox
            // 
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Teacher", "Student" });
            roleComboBox.Location = new Point(312, 25);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(121, 23);
            roleComboBox.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(16, 25);
            label5.Name = "label5";
            label5.Size = new Size(55, 24);
            label5.TabIndex = 1;
            label5.Text = "Role";
            label5.Click += label5_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(button2);
            panel6.Controls.Add(button1);
            panel6.Location = new Point(168, 448);
            panel6.Name = "panel6";
            panel6.Size = new Size(264, 85);
            panel6.TabIndex = 5;
            // 
            // button2
            // 
            button2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(147, 22);
            button2.Name = "button2";
            button2.Size = new Size(92, 40);
            button2.TabIndex = 1;
            button2.Text = "Tạo tài khoản";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(20, 22);
            button1.Name = "button1";
            button1.Size = new Size(86, 40);
            button1.TabIndex = 0;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(passwordcheckTXB);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(22, 269);
            panel5.Name = "panel5";
            panel5.Size = new Size(553, 54);
            panel5.TabIndex = 4;
            // 
            // passwordcheckTXB
            // 
            passwordcheckTXB.Location = new Point(227, 15);
            passwordcheckTXB.Name = "passwordcheckTXB";
            passwordcheckTXB.PasswordChar = '*';
            passwordcheckTXB.Size = new Size(299, 23);
            passwordcheckTXB.TabIndex = 1;
            passwordcheckTXB.TextChanged += passwordcheckTXB_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(16, 14);
            label4.Name = "label4";
            label4.Size = new Size(205, 24);
            label4.TabIndex = 0;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // panel4
            // 
            panel4.Controls.Add(passwordTXB);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(22, 184);
            panel4.Name = "panel4";
            panel4.Size = new Size(553, 54);
            panel4.TabIndex = 3;
            // 
            // passwordTXB
            // 
            passwordTXB.Location = new Point(227, 15);
            passwordTXB.Name = "passwordTXB";
            passwordTXB.PasswordChar = '*';
            passwordTXB.Size = new Size(299, 23);
            passwordTXB.TabIndex = 1;
            passwordTXB.TextChanged += passwordTXB_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(16, 14);
            label3.Name = "label3";
            label3.Size = new Size(102, 24);
            label3.TabIndex = 0;
            label3.Text = "Mật khẩu";
            // 
            // panel3
            // 
            panel3.Controls.Add(fullnameTXB);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(22, 103);
            panel3.Name = "panel3";
            panel3.Size = new Size(553, 54);
            panel3.TabIndex = 2;
            // 
            // fullnameTXB
            // 
            fullnameTXB.Location = new Point(227, 15);
            fullnameTXB.Name = "fullnameTXB";
            fullnameTXB.Size = new Size(299, 23);
            fullnameTXB.TabIndex = 1;
            fullnameTXB.TextChanged += fullnameTXB_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 14);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 0;
            label2.Text = "Họ tên";
            // 
            // panel2
            // 
            panel2.Controls.Add(usernameTXB);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(22, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(553, 54);
            panel2.TabIndex = 0;
            // 
            // usernameTXB
            // 
            usernameTXB.ForeColor = Color.Black;
            usernameTXB.Location = new Point(227, 15);
            usernameTXB.Name = "usernameTXB";
            usernameTXB.Size = new Size(299, 23);
            usernameTXB.TabIndex = 1;
            usernameTXB.TextChanged += usernameTXB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 14);
            label1.Name = "label1";
            label1.Size = new Size(109, 24);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản";
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 577);
            Controls.Add(panel1);
            Name = "CreateAccount";
            Text = "Form1";
            Load += CreateAccount_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel6;
        private Button button1;
        private Panel panel5;
        private TextBox passwordcheckTXB;
        private Label label4;
        private Panel panel4;
        private TextBox passwordTXB;
        private Label label3;
        private Panel panel3;
        private TextBox fullnameTXB;
        private Label label2;
        private TextBox usernameTXB;
        private Button button2;
        private Panel panel7;
        private Label label5;
        private ComboBox roleComboBox;
        private Label label6;
        private Label label8;
        private Label label7;
    }
}