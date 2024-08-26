namespace AdventOfCode2023
{
    partial class Form1
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
            this.InputTxtbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTxtBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Day11Btn = new System.Windows.Forms.Button();
            this.Day12Btn = new System.Windows.Forms.Button();
            this.Day22btn = new System.Windows.Forms.Button();
            this.Day21Btn = new System.Windows.Forms.Button();
            this.Day32Btn = new System.Windows.Forms.Button();
            this.Day31Btn = new System.Windows.Forms.Button();
            this.Day42Btn = new System.Windows.Forms.Button();
            this.Day41Btn = new System.Windows.Forms.Button();
            this.Day52Btn = new System.Windows.Forms.Button();
            this.Day51Btn = new System.Windows.Forms.Button();
            this.Day62Btn = new System.Windows.Forms.Button();
            this.Day61Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputTxtbox
            // 
            this.InputTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InputTxtbox.Location = new System.Drawing.Point(20, 31);
            this.InputTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.InputTxtbox.Name = "InputTxtbox";
            this.InputTxtbox.Size = new System.Drawing.Size(384, 507);
            this.InputTxtbox.TabIndex = 0;
            this.InputTxtbox.Text = "Time:      7  15   30\nDistance:  9  40  200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input";
            // 
            // OutputTxtBox
            // 
            this.OutputTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTxtBox.Location = new System.Drawing.Point(569, 31);
            this.OutputTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutputTxtBox.Name = "OutputTxtBox";
            this.OutputTxtBox.Size = new System.Drawing.Size(489, 507);
            this.OutputTxtBox.TabIndex = 2;
            this.OutputTxtBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // Day11Btn
            // 
            this.Day11Btn.Location = new System.Drawing.Point(413, 31);
            this.Day11Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day11Btn.Name = "Day11Btn";
            this.Day11Btn.Size = new System.Drawing.Size(80, 28);
            this.Day11Btn.TabIndex = 4;
            this.Day11Btn.Text = "Day 1-1";
            this.Day11Btn.UseVisualStyleBackColor = true;
            this.Day11Btn.Click += new System.EventHandler(this.Day11Btn_Click);
            // 
            // Day12Btn
            // 
            this.Day12Btn.Location = new System.Drawing.Point(481, 31);
            this.Day12Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day12Btn.Name = "Day12Btn";
            this.Day12Btn.Size = new System.Drawing.Size(80, 28);
            this.Day12Btn.TabIndex = 5;
            this.Day12Btn.Text = "Day 1-2";
            this.Day12Btn.UseVisualStyleBackColor = true;
            this.Day12Btn.Click += new System.EventHandler(this.Day12Btn_Click);
            // 
            // Day22btn
            // 
            this.Day22btn.Location = new System.Drawing.Point(481, 63);
            this.Day22btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day22btn.Name = "Day22btn";
            this.Day22btn.Size = new System.Drawing.Size(80, 28);
            this.Day22btn.TabIndex = 7;
            this.Day22btn.Text = "Day 2-2";
            this.Day22btn.UseVisualStyleBackColor = true;
            this.Day22btn.Click += new System.EventHandler(this.Day22btn_Click);
            // 
            // Day21Btn
            // 
            this.Day21Btn.Location = new System.Drawing.Point(413, 63);
            this.Day21Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day21Btn.Name = "Day21Btn";
            this.Day21Btn.Size = new System.Drawing.Size(80, 28);
            this.Day21Btn.TabIndex = 6;
            this.Day21Btn.Text = "Day 2-1";
            this.Day21Btn.UseVisualStyleBackColor = true;
            this.Day21Btn.Click += new System.EventHandler(this.Day21Btn_Click);
            // 
            // Day32Btn
            // 
            this.Day32Btn.Location = new System.Drawing.Point(481, 95);
            this.Day32Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day32Btn.Name = "Day32Btn";
            this.Day32Btn.Size = new System.Drawing.Size(80, 28);
            this.Day32Btn.TabIndex = 9;
            this.Day32Btn.Text = "Day 3-2";
            this.Day32Btn.UseVisualStyleBackColor = true;
            this.Day32Btn.Click += new System.EventHandler(this.Day32Btn_Click);
            // 
            // Day31Btn
            // 
            this.Day31Btn.Location = new System.Drawing.Point(413, 95);
            this.Day31Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day31Btn.Name = "Day31Btn";
            this.Day31Btn.Size = new System.Drawing.Size(80, 28);
            this.Day31Btn.TabIndex = 8;
            this.Day31Btn.Text = "Day 3-1";
            this.Day31Btn.UseVisualStyleBackColor = true;
            this.Day31Btn.Click += new System.EventHandler(this.Day31Btn_Click);
            // 
            // Day42Btn
            // 
            this.Day42Btn.Location = new System.Drawing.Point(481, 127);
            this.Day42Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day42Btn.Name = "Day42Btn";
            this.Day42Btn.Size = new System.Drawing.Size(80, 28);
            this.Day42Btn.TabIndex = 11;
            this.Day42Btn.Text = "Day 4-2";
            this.Day42Btn.UseVisualStyleBackColor = true;
            this.Day42Btn.Click += new System.EventHandler(this.Day42Btn_Click);
            // 
            // Day41Btn
            // 
            this.Day41Btn.Location = new System.Drawing.Point(413, 127);
            this.Day41Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day41Btn.Name = "Day41Btn";
            this.Day41Btn.Size = new System.Drawing.Size(80, 28);
            this.Day41Btn.TabIndex = 10;
            this.Day41Btn.Text = "Day 4-1";
            this.Day41Btn.UseVisualStyleBackColor = true;
            this.Day41Btn.Click += new System.EventHandler(this.Day41Btn_Click);
            // 
            // Day52Btn
            // 
            this.Day52Btn.Location = new System.Drawing.Point(481, 159);
            this.Day52Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day52Btn.Name = "Day52Btn";
            this.Day52Btn.Size = new System.Drawing.Size(80, 28);
            this.Day52Btn.TabIndex = 13;
            this.Day52Btn.Text = "Day 5-2";
            this.Day52Btn.UseVisualStyleBackColor = true;
            this.Day52Btn.Click += new System.EventHandler(this.Day52Btn_Click);
            // 
            // Day51Btn
            // 
            this.Day51Btn.Location = new System.Drawing.Point(413, 159);
            this.Day51Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day51Btn.Name = "Day51Btn";
            this.Day51Btn.Size = new System.Drawing.Size(80, 28);
            this.Day51Btn.TabIndex = 12;
            this.Day51Btn.Text = "Day 5-1";
            this.Day51Btn.UseVisualStyleBackColor = true;
            this.Day51Btn.Click += new System.EventHandler(this.Day51Btn_Click);
            // 
            // Day62Btn
            // 
            this.Day62Btn.Location = new System.Drawing.Point(480, 191);
            this.Day62Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day62Btn.Name = "Day62Btn";
            this.Day62Btn.Size = new System.Drawing.Size(80, 28);
            this.Day62Btn.TabIndex = 15;
            this.Day62Btn.Text = "Day 6-2";
            this.Day62Btn.UseVisualStyleBackColor = true;
            this.Day62Btn.Click += new System.EventHandler(this.Day62Btn_Click);
            // 
            // Day61Btn
            // 
            this.Day61Btn.Location = new System.Drawing.Point(413, 191);
            this.Day61Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Day61Btn.Name = "Day61Btn";
            this.Day61Btn.Size = new System.Drawing.Size(80, 28);
            this.Day61Btn.TabIndex = 14;
            this.Day61Btn.Text = "Day 6-1";
            this.Day61Btn.UseVisualStyleBackColor = true;
            this.Day61Btn.Click += new System.EventHandler(this.Day61Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Day62Btn);
            this.Controls.Add(this.Day61Btn);
            this.Controls.Add(this.Day52Btn);
            this.Controls.Add(this.Day51Btn);
            this.Controls.Add(this.Day42Btn);
            this.Controls.Add(this.Day41Btn);
            this.Controls.Add(this.Day32Btn);
            this.Controls.Add(this.Day31Btn);
            this.Controls.Add(this.Day22btn);
            this.Controls.Add(this.Day21Btn);
            this.Controls.Add(this.Day12Btn);
            this.Controls.Add(this.Day11Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutputTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputTxtbox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputTxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox OutputTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Day11Btn;
        private System.Windows.Forms.Button Day12Btn;
        private System.Windows.Forms.Button Day22btn;
        private System.Windows.Forms.Button Day21Btn;
        private System.Windows.Forms.Button Day32Btn;
        private System.Windows.Forms.Button Day31Btn;
        private System.Windows.Forms.Button Day42Btn;
        private System.Windows.Forms.Button Day41Btn;
        private System.Windows.Forms.Button Day52Btn;
        private System.Windows.Forms.Button Day51Btn;
        private System.Windows.Forms.Button Day62Btn;
        private System.Windows.Forms.Button Day61Btn;
    }
}

