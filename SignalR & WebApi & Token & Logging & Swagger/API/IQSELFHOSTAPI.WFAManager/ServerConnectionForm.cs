using IQSELFHOSTAPI.Helpers;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager
{
    public partial class ServerConnectionForm : Form
    {
        public ServerConnectionForm()
        {
            InitializeComponent();
            ServerPanelControl();
        }

        public delegate void _serverConnectionForm();
        public event _serverConnectionForm serverConnectionFormControl;

        ConnectionADO _connectionAdo = ConnectionADO.createAsSingleton();
        private void ServerPanelControl()
        {
            string Server = Properties.Settings.Default.Servername;
            string UserName = Properties.Settings.Default.Username;
            string Password = Properties.Settings.Default.Password;

            BusinessLayerResult<object> connectionResult = _connectionAdo.ConnectionStatus(Server, UserName, Password);

            if (connectionResult.Result == true)
            {
                this.Hide();
                serverConnectionFormControl();
            }
        }

        private void btnServerCreated_Click(object sender, System.EventArgs e)
        {
            string Server = txtServerName.Text;
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;

            string adminUsername = txtAdminUsername.Text;
            string adminPassword = txtAdminPassword.Text;

            if (Server == "" || UserName == "" || Password == "" || adminUsername == "" || adminPassword == "")
            {
                MessageBox.Show("Tüm Bilgileri girdiğinize emin olun !!", "Bazı Alanlar Boş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BusinessLayerResult<object> connectionResult = _connectionAdo.ConnectionStatus(Server, UserName, Password);

            if (!connectionResult.Result)
                MessageBox.Show("Geçerli bir Server bilgisi değil Lütfen alanları kontrol edip tekrar deneyiniz.",
                    "SERVER NOTFOUND", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                Properties.Settings.Default.Servername = Server;
                Properties.Settings.Default.Username = UserName;
                Properties.Settings.Default.Password = Password;

                Properties.Settings.Default.ProjeUsername = adminUsername;
                Properties.Settings.Default.ProjePassword = adminPassword;

                Properties.Settings.Default.Save();
                ServerPanelControl();
            }
        }
    }
}