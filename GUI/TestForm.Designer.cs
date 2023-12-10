namespace GUI
{
    partial class TestForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel8 = new Panel();
            label6 = new Label();
            label8 = new Label();
            button2 = new Button();
            label9 = new Label();
            button1 = new Button();
            panel3 = new Panel();
            panel7 = new Panel();
            label5 = new Label();
            panel6 = new Panel();
            label4 = new Label();
            panel5 = new Panel();
            label3 = new Label();
            radioButton5 = new RadioButton();
            panel4 = new Panel();
            label2 = new Label();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel8);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1233, 623);
            panel1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Controls.Add(label6);
            panel8.Controls.Add(label8);
            panel8.Location = new Point(1033, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(197, 59);
            panel8.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(73, 35);
            label6.Name = "label6";
            label6.Size = new Size(53, 24);
            label6.TabIndex = 15;
            label6.Text = "2:00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(10, 3);
            label8.Name = "label8";
            label8.Size = new Size(177, 24);
            label8.TabIndex = 14;
            label8.Text = "Thời gian còn lại";
            // 
            // button2
            // 
            button2.Location = new Point(1106, 559);
            button2.Name = "button2";
            button2.Size = new Size(109, 33);
            button2.TabIndex = 13;
            button2.Text = "Câu hỏi tiếp theo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(8, 65);
            label9.Name = "label9";
            label9.Size = new Size(87, 24);
            label9.TabIndex = 5;
            label9.Text = "Câu hỏi";
            label9.Click += label9_Click;
            // 
            // button1
            // 
            button1.Location = new Point(27, 559);
            button1.Name = "button1";
            button1.Size = new Size(109, 33);
            button1.TabIndex = 8;
            button1.Text = "Câu hỏi trước";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(radioButton5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(radioButton4);
            panel3.Controls.Add(radioButton3);
            panel3.Controls.Add(radioButton2);
            panel3.Controls.Add(radioButton1);
            panel3.Location = new Point(27, 267);
            panel3.Name = "panel3";
            panel3.Size = new Size(1188, 263);
            panel3.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Controls.Add(label5);
            panel7.Location = new Point(690, 148);
            panel7.Name = "panel7";
            panel7.Size = new Size(484, 98);
            panel7.TabIndex = 12;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(484, 98);
            label5.TabIndex = 4;
            label5.Text = "label5";
            label5.SizeChanged += label5_SizeChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(label4);
            panel6.Location = new Point(81, 148);
            panel6.Name = "panel6";
            panel6.Size = new Size(484, 98);
            panel6.TabIndex = 10;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(484, 98);
            label4.TabIndex = 4;
            label4.Text = "label4";
            label4.SizeChanged += label4_SizeChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(label3);
            panel5.Location = new Point(690, 27);
            panel5.Name = "panel5";
            panel5.Size = new Size(484, 98);
            panel5.TabIndex = 11;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(484, 98);
            label3.TabIndex = 4;
            label3.Text = "label3";
            label3.SizeChanged += label3_SizeChanged;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton5.Location = new Point(1238, 27);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(36, 24);
            radioButton5.TabIndex = 10;
            radioButton5.Text = "B";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Location = new Point(81, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(484, 98);
            panel4.TabIndex = 9;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(484, 98);
            label2.TabIndex = 4;
            label2.Text = "label2";
            label2.SizeChanged += label2_SizeChanged;
            label2.Click += label2_Click;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton4.Location = new Point(651, 148);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(39, 23);
            radioButton4.TabIndex = 3;
            radioButton4.Text = "D";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton3.Location = new Point(42, 148);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(39, 23);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "C";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(648, 27);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(39, 23);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "B";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(42, 27);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(38, 23);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "A";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(97, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(1118, 184);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1118, 184);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.SizeChanged += label1_SizeChanged;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 637);
            Controls.Add(panel1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Panel panel4;
        private Panel panel7;
        private Label label5;
        private Panel panel6;
        private Label label4;
        private Panel panel5;
        private Label label3;
        private RadioButton radioButton5;
        private Label label9;
        private Label label1;
        private Button button2;
        private Label label8;
        private Label label6;
        private Panel panel8;
    }
}