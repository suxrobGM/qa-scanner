using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            if (!Directory.Exists("Documents"))
                Directory.CreateDirectory("Documents");

            _settings = new SettingsXml("Settings.xml");
            isAsyncFind.Checked = _settings.IsAsynchronousFinding;
            selectedSubject.SelectedItem = _settings.SelectedSubject;
            Opacity = _settings.Opacity;
            opacityTrack.Value = (int)(Opacity * 100.0);           
        }

        #region Event methods
        private void findBtn_Click(object sender, EventArgs e)
        {
            if (questionText.Text == String.Empty)
            {                
                var customMessageBox = new CustomMessageBox("Please enter the question string then click find button", this.Opacity);               
                customMessageBox.ShowDialog();
                return;
            }

            try
            {
                FindAnswer();
            }
            catch (FileNotFoundException ex)
            {
                var customMessageBox = new CustomMessageBox(ex.Message, this.Opacity);
                customMessageBox.ShowDialog();
            }          
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            questionText.Text = String.Empty;
            answerText.Text = String.Empty;           
        }       

        private void opacityTrack_Scroll(object sender, EventArgs e)
        {
            Opacity = opacityTrack.Value / 100.0;
            _settings.Opacity = Opacity;
        }              

        private void questionText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A && e.Control)
            {
                questionText.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyData == Keys.Enter)
            {
                findBtn_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }       

        private void questionText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isAsyncFind.Checked)
                    FindAnswer();
            }
            catch (FileNotFoundException ex)
            {
                var customMessageBox = new CustomMessageBox(ex.Message, this.Opacity);
                customMessageBox.ShowDialog();
            }            
        }

        private void isAsyncFind_CheckedChanged(object sender, EventArgs e)
        {
            _settings.IsAsynchronousFinding = isAsyncFind.Checked;
        }

        private void selectedSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settings.SelectedSubject = selectedSubject.SelectedItem.ToString();
        }

        private void authorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/suxrobgm");
        }

        private void siteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://moodle.samtuit.uz");
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (Login_TB.Text != String.Empty && Password_TB.Text != String.Empty)
            {
                var automation = new Automation(Login_TB.Text, Password_TB.Text);
                automation.SessionLogin();
            }
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
                case 0: // Manual Table Method
                    {
                        answerText.Text = Subject.ResponseManualTableMethod(questionText.Text);
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
                case 4: // Physics - 2018
                    {
                        answerText.Text = Subject.ResponsePhysics(questionText.Text);
                        break;
                    }
                case 5: // Digital - 2019
                    {
                        answerText.Text = Subject.ResponseDigital(questionText.Text);
                        break;
                    }
                case 6: // Computer Network - 2019
                    {
                        answerText.Text = Subject.ResponseComputerNetwork(questionText.Text);
                        break;
                    }
                
                default:
                    break;
            }
        }
        #endregion       
    }
}
