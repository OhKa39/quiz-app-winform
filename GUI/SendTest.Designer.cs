namespace GUI
{
    partial class SendTest
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
            label2 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            panel5 = new Panel();
            comboBox2 = new ComboBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            panel4 = new Panel();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            radioButton2 = new RadioButton();
            panel3 = new Panel();
            textBox5 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(929, 692);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(356, 357);
            label2.Name = "label2";
            label2.Size = new Size(240, 24);
            label2.TabIndex = 10;
            label2.Text = "Danh sách các câu hỏi";
            // 
            // button3
            // 
            button3.Location = new Point(724, 641);
            button3.Name = "button3";
            button3.Size = new Size(94, 41);
            button3.TabIndex = 4;
            button3.Text = "Sửa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(419, 641);
            button2.Name = "button2";
            button2.Size = new Size(94, 41);
            button2.TabIndex = 3;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(63, 641);
            button1.Name = "button1";
            button1.Size = new Size(94, 41);
            button1.TabIndex = 2;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 384);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(891, 241);
            dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(20, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(891, 338);
            panel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBox2);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(comboBox1);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(16, 267);
            panel5.Name = "panel5";
            panel5.Size = new Size(807, 59);
            panel5.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Luyện tập", "Thi" });
            comboBox2.Location = new Point(580, 21);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(457, 19);
            label4.Name = "label4";
            label4.Size = new Size(103, 24);
            label4.TabIndex = 12;
            label4.Text = "Phân loại";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(176, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(101, 21);
            label3.Name = "label3";
            label3.Size = new Size(53, 24);
            label3.TabIndex = 10;
            label3.Text = "Môn";
            // 
            // panel4
            // 
            panel4.Controls.Add(radioButton4);
            panel4.Controls.Add(radioButton3);
            panel4.Controls.Add(radioButton1);
            panel4.Controls.Add(textBox4);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(radioButton2);
            panel4.Location = new Point(16, 123);
            panel4.Name = "panel4";
            panel4.Size = new Size(862, 138);
            panel4.TabIndex = 1;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton4.Location = new Point(27, 86);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(43, 28);
            radioButton4.TabIndex = 11;
            radioButton4.Text = "C";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton3.Location = new Point(459, 85);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(43, 28);
            radioButton3.TabIndex = 10;
            radioButton3.Text = "D";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(26, 17);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(43, 28);
            radioButton1.TabIndex = 9;
            radioButton1.TabStop = true;
            radioButton1.Text = "A";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(72, 73);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(359, 52);
            textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(505, 73);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(342, 52);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(505, 6);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(342, 51);
            textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 6);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 51);
            textBox1.TabIndex = 5;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(459, 15);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(43, 28);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "B";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(16, 14);
            panel3.Name = "panel3";
            panel3.Size = new Size(862, 103);
            panel3.TabIndex = 0;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(115, 17);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(732, 73);
            textBox5.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 40);
            label1.Name = "label1";
            label1.Size = new Size(87, 24);
            label1.TabIndex = 4;
            label1.Text = "Câu hỏi";
            label1.Click += label1_Click;
            // 
            // SendTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 693);
            Controls.Add(panel1);
            Name = "SendTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SendTest";
            Load += SendTest_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private RadioButton radioButton2;
        private TextBox textBox5;
        private Label label1;
        private Button button3;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label2;
        private Panel panel5;
        private ComboBox comboBox1;
        private Label label3;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton1;
        private ComboBox comboBox2;
        private Label label4;
    }
}