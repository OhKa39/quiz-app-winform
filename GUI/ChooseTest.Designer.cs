namespace GUI
{
    partial class ChooseTest
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
            panel4 = new Panel();
            comboBox2 = new ComboBox();
            label2 = new Label();
            panel3 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(37, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 236);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox2);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(43, 84);
            panel4.Name = "panel4";
            panel4.Size = new Size(262, 53);
            panel4.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Luyện tập", "Thi" });
            comboBox2.Location = new Point(126, 15);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 14);
            label2.Name = "label2";
            label2.Size = new Size(103, 24);
            label2.TabIndex = 0;
            label2.Text = "Phân loại";
            // 
            // panel3
            // 
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(63, 157);
            panel3.Name = "panel3";
            panel3.Size = new Size(217, 68);
            panel3.TabIndex = 0;
            // 
            // button2
            // 
            button2.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(122, 13);
            button2.Name = "button2";
            button2.Size = new Size(77, 42);
            button2.TabIndex = 3;
            button2.Text = "Làm bài";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(18, 13);
            button1.Name = "button1";
            button1.Size = new Size(77, 42);
            button1.TabIndex = 2;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(43, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 53);
            panel2.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(126, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 14);
            label1.Name = "label1";
            label1.Size = new Size(53, 24);
            label1.TabIndex = 0;
            label1.Text = "Môn";
            // 
            // ChooseTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 259);
            Controls.Add(panel1);
            Name = "ChooseTest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChooseTest";
            Load += ChooseTest_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Button button2;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panel4;
        private ComboBox comboBox2;
        private Label label2;
        private Button button1;
    }
}