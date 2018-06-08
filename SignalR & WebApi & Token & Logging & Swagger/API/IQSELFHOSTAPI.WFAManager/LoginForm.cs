using System;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager
{
    public partial class LoginForm : Form
    {
        public delegate void LoginEvent();
        public event LoginEvent loginEvent;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginControl();
        }

        private void LoginControl()
        {
            string username = Properties.Settings.Default.ProjeUsername;
            string password = Properties.Settings.Default.ProjePassword;

            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                this.Hide();
                loginEvent();
            }
            else
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.", "GİRİŞ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                LoginControl();
            }
        }
    }
}