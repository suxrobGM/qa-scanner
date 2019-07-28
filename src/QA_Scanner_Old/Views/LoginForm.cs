using System;
using System.Windows.Forms;

namespace QA_Scanner.Views
{
    public partial class LoginForm : Form
    {
        public bool IsSuccessfeullyLogged { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void PassBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ValidateData();
            }            
        }

        private void ValidateData()
        {
            if (!string.IsNullOrEmpty(passBox.Text) && passBox.Text == "0729")
            {
                IsSuccessfeullyLogged = true;
                statusLabel.Text = "";
                this.Close();
            }
            else
            {
                statusLabel.Text = "Invalid password, please try again";
            }
        }
    }
}
