namespace QA_Scanner.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Answer_TB = new System.Windows.Forms.TextBox();
            this.Find_Btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.Clear_Btn = new System.Windows.Forms.Button();
            this.Question_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.SubjectURL_TB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Start_Btn = new System.Windows.Forms.Button();
            this.Teacher_Password_TB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Login_TB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer:";
            // 
            // Answer_TB
            // 
            this.Answer_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer_TB.Location = new System.Drawing.Point(15, 28);
            this.Answer_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Answer_TB.Multiline = true;
            this.Answer_TB.Name = "Answer_TB";
            this.Answer_TB.Size = new System.Drawing.Size(811, 146);
            this.Answer_TB.TabIndex = 2;
            // 
            // Find_Btn
            // 
            this.Find_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Find_Btn.Location = new System.Drawing.Point(621, 224);
            this.Find_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Find_Btn.Name = "Find_Btn";
            this.Find_Btn.Size = new System.Drawing.Size(100, 28);
            this.Find_Btn.TabIndex = 4;
            this.Find_Btn.Text = "Find";
            this.Find_Btn.UseVisualStyleBackColor = true;
            this.Find_Btn.Click += new System.EventHandler(this.Find_Btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.Clear_Btn);
            this.panel2.Controls.Add(this.Answer_TB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Find_Btn);
            this.panel2.Location = new System.Drawing.Point(8, 238);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 271);
            this.panel2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(201, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Subject:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Physics - 2018",
            "English - 2018",
            "Ecology - 2018",
            "Data Structure - 2018",
            "Computer Network - 2019"});
            this.comboBox1.Location = new System.Drawing.Point(204, 212);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(457, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Opacity:";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(457, 212);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(156, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 25;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Developed by SuxrobGM";
            // 
            // Clear_Btn
            // 
            this.Clear_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear_Btn.Location = new System.Drawing.Point(727, 224);
            this.Clear_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Clear_Btn.Name = "Clear_Btn";
            this.Clear_Btn.Size = new System.Drawing.Size(100, 28);
            this.Clear_Btn.TabIndex = 5;
            this.Clear_Btn.Text = "Clear";
            this.Clear_Btn.UseVisualStyleBackColor = true;
            this.Clear_Btn.Click += new System.EventHandler(this.Clear_Btn_Click);
            // 
            // Question_TB
            // 
            this.Question_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Question_TB.Location = new System.Drawing.Point(15, 37);
            this.Question_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Question_TB.Multiline = true;
            this.Question_TB.Name = "Question_TB";
            this.Question_TB.Size = new System.Drawing.Size(811, 146);
            this.Question_TB.TabIndex = 1;
            this.Question_TB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Question_TB_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Question:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Question_TB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 203);
            this.panel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 549);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(868, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.SubjectURL_TB);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.Start_Btn);
            this.tabPage2.Controls.Add(this.Teacher_Password_TB);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.Password_TB);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.Login_TB);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(868, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Automation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(11, 484);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Developed by SuxrobGM";
            // 
            // SubjectURL_TB
            // 
            this.SubjectURL_TB.Location = new System.Drawing.Point(11, 300);
            this.SubjectURL_TB.Margin = new System.Windows.Forms.Padding(4);
            this.SubjectURL_TB.Name = "SubjectURL_TB";
            this.SubjectURL_TB.Size = new System.Drawing.Size(259, 22);
            this.SubjectURL_TB.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 278);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Enter Subject URL:";
            // 
            // Start_Btn
            // 
            this.Start_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start_Btn.Location = new System.Drawing.Point(15, 395);
            this.Start_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(109, 28);
            this.Start_Btn.TabIndex = 8;
            this.Start_Btn.Text = "Start";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // Teacher_Password_TB
            // 
            this.Teacher_Password_TB.Location = new System.Drawing.Point(11, 220);
            this.Teacher_Password_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Teacher_Password_TB.Name = "Teacher_Password_TB";
            this.Teacher_Password_TB.Size = new System.Drawing.Size(259, 22);
            this.Teacher_Password_TB.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Enter Teacher Password:";
            // 
            // Password_TB
            // 
            this.Password_TB.Location = new System.Drawing.Point(11, 144);
            this.Password_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(259, 22);
            this.Password_TB.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(11, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Enter Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Site:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(51, 20);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 17);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "moodle.samtuit.uz";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login_TB
            // 
            this.Login_TB.Location = new System.Drawing.Point(11, 85);
            this.Login_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Login_TB.Name = "Login_TB";
            this.Login_TB.Size = new System.Drawing.Size(259, 22);
            this.Login_TB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Enter Login:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 549);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "QA Scanner";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Answer_TB;
        private System.Windows.Forms.Button Find_Btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Question_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Clear_Btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox Login_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Start_Btn;
        private System.Windows.Forms.TextBox Teacher_Password_TB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SubjectURL_TB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

