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
        private HotKey hKey = new HotKey(Keys.D, KeyModifiers.Control);   //Ctrl+D
        private HotKey trackBarKey_Plus = new HotKey(Keys.Multiply, KeyModifiers.None);
        private HotKey trackBarKey_Minus = new HotKey(Keys.Divide, KeyModifiers.None);
        private SettingsXml _settings;

        public MainForm()
        {
            InitializeComponent();

            hKey.Pressed += (o, e) => { SetVisible(); e.Handled = true; };          
            hKey.Register(this);
            trackBarKey_Plus.Pressed += (o, e) => { AddOpacity(); e.Handled = true; };
            trackBarKey_Plus.Register(this);
            trackBarKey_Minus.Pressed += (o, e) => { SubtractOpacity(); e.Handled = true; };
            trackBarKey_Minus.Register(this);

            _settings = new SettingsXml("Settings.xml");
            isAsyncFind.Checked = _settings.IsAsynchronousFind;
            selectedSubject.SelectedText = _settings.SelectedSubject;
            Opacity = _settings.Opacity;
            opacityTrack.Value = (int)(Opacity * 100.0);
            
        }

        #region Event methods
        private void Find_Btn_Click(object sender, EventArgs e)
        {
            if (questionText.Text == String.Empty)
            {                
                var customMessageBox = new CustomMessageBox("Please enter the question string then click find button", this.Opacity);               
                customMessageBox.ShowDialog();
                return;
            }

            FindAnswer();
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            questionText.Text = String.Empty;
            answerText.Text = String.Empty;           
        }       

        private void opacityTrack_Scroll(object sender, EventArgs e)
        {
            Opacity = opacityTrack.Value / 100.0;
            _settings.Opacity = Opacity;
        }              

        private void Question_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A && e.Control)
            {
                questionText.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyData == Keys.Enter)
            {
                Find_Btn_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void siteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void questionText_TextChanged(object sender, EventArgs e)
        {
            FindAnswer();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hKey.Dispose();
        }
        #endregion

        #region Private methods
        private void SetVisible()
        {
            if (Visible)
                Visible = false;
            else
                Visible = true;
        }

        private void AddOpacity()
        {
            if(opacityTrack.Value < opacityTrack.Maximum)
            {
                opacityTrack.Value++;
                Opacity = opacityTrack.Value / 100.0;
                _settings.Opacity = Opacity;
            }
        }

        private void SubtractOpacity()
        {
            if (opacityTrack.Value > opacityTrack.Minimum)
            {
                opacityTrack.Value--;
                Opacity = opacityTrack.Value / 100.0;
                _settings.Opacity = Opacity;
            }
        }

        private void FindAnswer()
        {           
            switch (selectedSubject.SelectedIndex)
            {
                case 0: // Manual
                    {
                        //Answer_TB.Text = Subject.ResponsePhysics(Question_TB.Text);
                        break;
                    }
                case 1: // English - 2018
                    {
                        answerText.Text = Subject.ResponseEnglish(questionText.Text);
                        break;
                    }
                case 2: // Ecology - 2018
                    {
                        answerText.Text = Subject.ResponseEcology(questionText.Text);
                        break;
                    }
                case 3: // Data Structure - 2018
                    {
                        answerText.Text = Subject.ResponseStructure(questionText.Text);
                        break;
                    }
                case 4: //Computer Network - 2019
                    {
                        answerText.Text = Subject.ResponseComputerNetwork(questionText.Text);
                        break;
                    }
                case 5: //Digital - 2019
                    {
                        answerText.Text = Subject.ResponseDigital(questionText.Text);
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion
    }
}
