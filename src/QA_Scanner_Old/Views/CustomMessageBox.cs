using System;
using System.Windows.Forms;

namespace QA_Scanner.Views
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public CustomMessageBox(string messageText)
        {
            InitializeComponent();

            textBox1.Text = messageText;
            StartPosition = FormStartPosition.CenterParent;
        }

        public CustomMessageBox(string messageText, double opacity)
        {
            InitializeComponent();

            textBox1.Text = messageText;
            this.Opacity = opacity;
            StartPosition = FormStartPosition.CenterParent;
        }

        private void OK_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetText(string messageText)
        {
            textBox1.Text = messageText;
        }
    }
}
