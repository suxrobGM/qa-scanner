using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Scanner
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void OK_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetText(string Text)
        {
            textBox1.Text = Text;
        }
    }
}
