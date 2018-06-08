namespace QA_Scanner
{
    partial class CustomMessageBox
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
            this.OK_Btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OK_Btn
            // 
            this.OK_Btn.Location = new System.Drawing.Point(116, 111);
            this.OK_Btn.Name = "OK_Btn";
            this.OK_Btn.Size = new System.Drawing.Size(75, 23);
            this.OK_Btn.TabIndex = 0;
            this.OK_Btn.Text = "OK";
            this.OK_Btn.UseVisualStyleBackColor = true;
            this.OK_Btn.Click += new System.EventHandler(this.OK_Btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(291, 92);
            this.textBox1.TabIndex = 1;
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 146);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.OK_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomMessageBox";
            this.Text = "CustomMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK_Btn;
        private System.Windows.Forms.TextBox textBox1;
    }
}