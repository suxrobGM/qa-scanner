﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;


namespace QA_Scanner
{
    public partial class MainForm : Form
    {
        private HotKey hkey = new HotKey(Keys.D, KeyModifiers.Control);   //Ctrl+D
        private string FirstDocx = "ecology_1.docx";
        private string SecondDocx = "ecology_2.docx";
        private string[] ExtraChars = { " ", ",", ".", "!", "?" };
        
        public MainForm()
        {
            InitializeComponent();

            hkey.Pressed += (o, e) => { SetVisible(); e.Handled = true; };          
            hkey.Register(this);
            
        }    

        private void Find_Btn_Click(object sender, EventArgs e)
        {
            if(Question_TB.Text==String.Empty)
            {
                MessageBox.Show("Please enter the question string then click find button");
                return;
            }

            bool MatchQuestion_in_FirstDocx = false;
            bool MatchQuestion_in_SecondDocx = false;
            string Question = Question_TB.Text;

            Question = Question.RemoverStrs(ExtraChars);
            Question = Question.ToLower();

            try
            {
                using (DocX document1 = DocX.Load(FirstDocx))
                {
                    foreach (var p in document1.Paragraphs)
                    {
                        string ParagraphText = p.Text;
                        ParagraphText = ParagraphText.RemoverStrs(ExtraChars);
                        ParagraphText = ParagraphText.ToLower();

                        if (ParagraphText.Contains(Question))
                        {
                            MatchQuestion_in_FirstDocx = true;
                            continue;
                        }

                        if (MatchQuestion_in_FirstDocx)
                        {
                            Answer_TB.Text = p.Text;
                            break;
                        }
                    }

                    if (!MatchQuestion_in_FirstDocx)
                    {
                        
                        using (DocX document2 = DocX.Load(SecondDocx))
                        {
                            foreach (var p in document2.Paragraphs)
                            {
                                string ParagraphText = p.Text;
                                ParagraphText = ParagraphText.RemoverStrs(ExtraChars);
                                ParagraphText = ParagraphText.ToLower();

                                if (ParagraphText.Contains(Question))
                                {
                                    MatchQuestion_in_SecondDocx = true;
                                    continue;
                                }

                                if (MatchQuestion_in_SecondDocx)
                                {
                                    Answer_TB.Text = p.Text;
                                    break;
                                }
                            }
                        }                                            
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            if(!MatchQuestion_in_FirstDocx && !MatchQuestion_in_SecondDocx)
            {
                MessageBox.Show("Question was not found");
            }
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            Question_TB.Text = String.Empty;
            Answer_TB.Text = String.Empty;           
        }

        private static void SetVisible()
        {
            if (Program.mainForm.Visible)
                Program.mainForm.Visible = false;
            else
                Program.mainForm.Visible = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hkey.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Program.mainForm.Opacity = (float)trackBar1.Value/100.0f;           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            double opacity = Program.mainForm.Opacity;
            trackBar1.Value = (int)(opacity * 100.0);
        }
    }

    public static class StringHelper
    {
        public static string RemoverStrs(this string str, string[] removeStrs)
        {
            foreach (var removeStr in removeStrs)
                str = str.Replace(removeStr, "");
            return str;
        }     
    }
}
