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
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(37, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 164);
            panel1.TabIndex = 0;
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
            // panel3
            // 
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(63, 83);
            panel3.Name = "panel3";
            panel3.Size = new Size(217, 68);
            panel3.TabIndex = 0;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(126, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(18, 13);
            button1.Name = "button1";
            button1.Size = new Size(77, 42);
            button1.TabIndex = 2;
            button1.Text = "Luyện tập";
            button1.UseVisualStyleBackColor = true;
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
            // 
            // ChooseTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 212);
            Controls.Add(panel1);
            Name = "ChooseTest";
            Text = "ChooseTest";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label label1;
    }
}