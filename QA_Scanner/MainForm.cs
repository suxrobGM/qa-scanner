using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QA_Scanner
{
    public partial class MainForm : Form
    {
        private HotKey hkey = new HotKey(Keys.D, KeyModifiers.Control);   //Ctrl+D
        
        public MainForm()
        {
            InitializeComponent();

            hkey.Pressed += (o, e) => { SetVisible(); e.Handled = true; };          
            hkey.Register(this);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            double opacity = Program.mainForm.Opacity;
            trackBar1.Value = (int)(opacity * 100.0);

            comboBox1.SelectedIndex = 0;
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
            Program.mainForm.Opacity = trackBar1.Value / 100.0f;           
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
                FindAnswer();
                e.SuppressKeyPress = true;
            }
        }


        //Functions
        private void SetVisible()
        {
            if (Program.mainForm.Visible)
                Program.mainForm.Visible = false;
            else
                Program.mainForm.Visible = true;
        }

        private void FindAnswer()
        {
            if (Question_TB.Text == String.Empty)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Opacity = Program.mainForm.Opacity;
                customMessageBox.SetText("Please enter the question string then click find button");
                customMessageBox.Show();
                return;
            }

            try
            {
                if (comboBox1.SelectedIndex == 0) //Physics
                {
                    Answer_TB.Text = Subjects.FindResponsePhysics(Question_TB.Text);
                }
                else if (comboBox1.SelectedIndex == 1) //English
                {
                    Answer_TB.Text = Subjects.FindResponseEnglish(Question_TB.Text);
                }
                else if (comboBox1.SelectedIndex == 2) //Ecology
                {
                    Answer_TB.Text = Subjects.FindResponseEcology(Question_TB.Text);
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox();
                customMessageBox.Opacity = Program.mainForm.Opacity;
                customMessageBox.SetText(ex.Message);
                customMessageBox.Show();
            }
        }
    }
}
