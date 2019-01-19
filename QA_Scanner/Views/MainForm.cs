using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QA_Scanner.Models;

namespace QA_Scanner.Views
{
    public partial class MainForm : Form
    {
        private HotKey hkey = new HotKey(System.Windows.Forms.Keys.D, KeyModifiers.Control);   //Ctrl+D
        private HotKey trackBarKey_Plus = new HotKey(System.Windows.Forms.Keys.Multiply, KeyModifiers.None);
        private HotKey trackBarKey_Minus = new HotKey(System.Windows.Forms.Keys.Divide, KeyModifiers.None);      

        public MainForm()
        {
            InitializeComponent();

            hkey.Pressed += (o, e) => { SetVisible(); e.Handled = true; };          
            hkey.Register(this);
            trackBarKey_Plus.Pressed += (o, e) => { AddOpacity(); e.Handled = true; };
            trackBarKey_Plus.Register(this);
            trackBarKey_Minus.Pressed += (o, e) => { SubtractOpacity(); e.Handled = true; };
            trackBarKey_Minus.Register(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            double opacity = Program.MainWindow.Opacity;
            trackBar1.Value = (int)(opacity * 100.0);

            comboBox1.SelectedIndex = 3; //Default Structure - 2018
        }

        private void Find_Btn_Click(object sender, EventArgs e)
        {
            FindAnswer();
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            Question_TB.Text = String.Empty;
            Answer_TB.Text = String.Empty;           
        }       

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hkey.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Program.MainWindow.Opacity = trackBar1.Value / 100.0f;           
        }              

        private void Question_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.A && e.Control)
            {
                Question_TB.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                FindAnswer();
                e.SuppressKeyPress = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://moodle.samtuit.uz");
        }

        private void Start_Btn_Click(object sender, EventArgs e)
        {
            if(Login_TB.Text != String.Empty && Password_TB.Text != String.Empty)
            {               
                var automation = new Automation(Login_TB.Text, Password_TB.Text);
                automation.SessionLogin();               
            }
        }

        
        private void SetVisible()
        {
            if (Program.MainWindow.Visible)
                Program.MainWindow.Visible = false;
            else
                Program.MainWindow.Visible = true;
        }

        private void AddOpacity()
        {
            if(trackBar1.Value < trackBar1.Maximum)
            {
                trackBar1.Value++;
                Program.MainWindow.Opacity = trackBar1.Value / 100.0f;
            }
        }

        private void SubtractOpacity()
        {
            if (trackBar1.Value > trackBar1.Minimum)
            {
                trackBar1.Value--;
                Program.MainWindow.Opacity = trackBar1.Value / 100.0f;
            }
        }

        private void FindAnswer()
        {
            if (Question_TB.Text == String.Empty)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Opacity = Program.MainWindow.Opacity;
                customMessageBox.SetText("Please enter the question string then click find button");
                customMessageBox.Show();
                return;
            }

            try
            {
                if (comboBox1.SelectedIndex == 0) //Physics
                {
                    Answer_TB.Text = Subject.FindResponsePhysics(Question_TB.Text);
                }
                else if (comboBox1.SelectedIndex == 1) //English
                {
                    Answer_TB.Text = Subject.FindResponseEnglish(Question_TB.Text);
                }
                else if (comboBox1.SelectedIndex == 2) //Ecology
                {
                    Answer_TB.Text = Subject.FindResponseEcology(Question_TB.Text);
                }
                else if (comboBox1.SelectedIndex == 3) //Structure
                {
                    Answer_TB.Text = Subject.FindResponseStructure(Question_TB.Text);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Opacity = Program.MainWindow.Opacity;
                customMessageBox.SetText(ex.Message);
                customMessageBox.Show();
            }
        }      
    }
}
