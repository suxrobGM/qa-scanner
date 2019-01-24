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

            double opacity = this.Opacity;
            trackBar1.Value = (int)(opacity * 100.0);

            comboBox1.SelectedIndex = 5;
        }

        #region Event methods
        private void Find_Btn_Click(object sender, EventArgs e)
        {
            if (Question_TB.Text == String.Empty)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Opacity = this.Opacity;
                customMessageBox.SetText("Please enter the question string then click find button");
                customMessageBox.StartPosition = FormStartPosition.CenterParent;
                customMessageBox.ShowDialog();
                return;
            }

            FindAnswer();
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            Question_TB.Text = String.Empty;
            Answer_TB.Text = String.Empty;           
        }       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar1.Value / 100.0f;           
        }              

        private void Question_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A && e.Control)
            {
                Question_TB.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyData == Keys.Enter)
            {
                Find_Btn_Click(sender, e);
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

        private void Question_TB_TextChanged(object sender, EventArgs e)
        {
            FindAnswer();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hkey.Dispose();
        }
        #endregion

        #region Private methods
        private void SetVisible()
        {
            if (this.Visible)
                this.Visible = false;
            else
                this.Visible = true;
        }

        private void AddOpacity()
        {
            if(trackBar1.Value < trackBar1.Maximum)
            {
                trackBar1.Value++;
                this.Opacity = trackBar1.Value / 100.0f;
            }
        }

        private void SubtractOpacity()
        {
            if (trackBar1.Value > trackBar1.Minimum)
            {
                trackBar1.Value--;
                this.Opacity = trackBar1.Value / 100.0f;
            }
        }

        private void FindAnswer()
        {
            

            switch (comboBox1.SelectedIndex)
            {
                case 0: //Physics
                    {
                        Answer_TB.Text = Subject.ResponsePhysics(Question_TB.Text);
                        break;
                    }
                case 1: //English
                    {
                        Answer_TB.Text = Subject.ResponseEnglish(Question_TB.Text);
                        break;
                    }
                case 2: //Ecology
                    {
                        Answer_TB.Text = Subject.ResponseEcology(Question_TB.Text);
                        break;
                    }
                case 3: //Data Structure 2018
                    {
                        Answer_TB.Text = Subject.ResponseStructure(Question_TB.Text);
                        break;
                    }
                case 4: //Computer Network 2019
                    {
                        Answer_TB.Text = Subject.ResponseComputerNetwork(Question_TB.Text);
                        break;
                    }
                case 5: //Digital 2019
                    {
                        Answer_TB.Text = Subject.ResponseDigital(Question_TB.Text);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion               
    }
}
