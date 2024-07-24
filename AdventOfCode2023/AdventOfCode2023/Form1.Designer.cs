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
            this.SuspendLayout();
            // 
            // InputTxtbox
            // 
            this.InputTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InputTxtbox.Location = new System.Drawing.Point(15, 25);
            this.InputTxtbox.Name = "InputTxtbox";
            this.InputTxtbox.Size = new System.Drawing.Size(289, 413);
            this.InputTxtbox.TabIndex = 0;
            this.InputTxtbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input";
            // 
            // OutputTxtBox
            // 
            this.OutputTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTxtBox.Location = new System.Drawing.Point(427, 25);
            this.OutputTxtBox.Name = "OutputTxtBox";
            this.OutputTxtBox.Size = new System.Drawing.Size(368, 413);
            this.OutputTxtBox.TabIndex = 2;
            this.OutputTxtBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output";
            // 
            // Day11Btn
            // 
            this.Day11Btn.Location = new System.Drawing.Point(310, 25);
            this.Day11Btn.Name = "Day11Btn";
            this.Day11Btn.Size = new System.Drawing.Size(60, 23);
            this.Day11Btn.TabIndex = 4;
            this.Day11Btn.Text = "Day 1-1";
            this.Day11Btn.UseVisualStyleBackColor = true;
            this.Day11Btn.Click += new System.EventHandler(this.Day11Btn_Click);
            // 
            // Day12Btn
            // 
            this.Day12Btn.Location = new System.Drawing.Point(361, 25);
            this.Day12Btn.Name = "Day12Btn";
            this.Day12Btn.Size = new System.Drawing.Size(60, 23);
            this.Day12Btn.TabIndex = 5;
            this.Day12Btn.Text = "Day 1-2";
            this.Day12Btn.UseVisualStyleBackColor = true;
            this.Day12Btn.Click += new System.EventHandler(this.Day12Btn_Click);
            // 
            // Day22btn
            // 
            this.Day22btn.Location = new System.Drawing.Point(361, 51);
            this.Day22btn.Name = "Day22btn";
            this.Day22btn.Size = new System.Drawing.Size(60, 23);
            this.Day22btn.TabIndex = 7;
            this.Day22btn.Text = "Day 2-2";
            this.Day22btn.UseVisualStyleBackColor = true;
            this.Day22btn.Click += new System.EventHandler(this.Day22btn_Click);
            // 
            // Day21Btn
            // 
            this.Day21Btn.Location = new System.Drawing.Point(310, 51);
            this.Day21Btn.Name = "Day21Btn";
            this.Day21Btn.Size = new System.Drawing.Size(60, 23);
            this.Day21Btn.TabIndex = 6;
            this.Day21Btn.Text = "Day 2-1";
            this.Day21Btn.UseVisualStyleBackColor = true;
            this.Day21Btn.Click += new System.EventHandler(this.Day21Btn_Click);
            // 
            // Day32Btn
            // 
            this.Day32Btn.Location = new System.Drawing.Point(361, 77);
            this.Day32Btn.Name = "Day32Btn";
            this.Day32Btn.Size = new System.Drawing.Size(60, 23);
            this.Day32Btn.TabIndex = 9;
            this.Day32Btn.Text = "Day 3-2";
            this.Day32Btn.UseVisualStyleBackColor = true;
            // 
            // Day31Btn
            // 
            this.Day31Btn.Location = new System.Drawing.Point(310, 77);
            this.Day31Btn.Name = "Day31Btn";
            this.Day31Btn.Size = new System.Drawing.Size(60, 23);
            this.Day31Btn.TabIndex = 8;
            this.Day31Btn.Text = "Day 3-1";
            this.Day31Btn.UseVisualStyleBackColor = true;
            this.Day31Btn.Click += new System.EventHandler(this.Day31Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

