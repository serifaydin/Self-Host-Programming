using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.BackOfficeAPI.JsonManager;
using IQSELFHOSTAPI.Helpers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoginForm lf = new LoginForm();
            lf.MdiParent = this;
            lf.loginEvent += Lf_loginEvent;
            lf.Show();
            menuPanel.Enabled = false;

            #region Properties Remove
            //Properties.Settings.Default.Servername = "";
            //Properties.Settings.Default.Username = "";
            //Properties.Settings.Default.Password = "";
            //Properties.Settings.Default.Save();
            #endregion     
        }

        private void Lf_loginEvent()
        {
            ConnectionADO _connectionAdo = ConnectionADO.createAsSingleton();

            string Server = Properties.Settings.Default.Servername;
            string UserName = Properties.Settings.Default.Username;
            string Password = Properties.Settings.Default.Password;

            BusinessLayerResult<object> connectionResult = _connectionAdo.ConnectionStatus(Server, UserName, Password);

            if (connectionResult.Result == false)
            {
                menuPanel.Enabled = false;

                ServerConnectionForm scf = new ServerConnectionForm();
                scf.MdiParent = this;
                scf.serverConnectionFormControl += Scf_serverConnectionForm;
                scf.Show();
            }
            else
            {
                menuPanel.Enabled = true;
            }
        }

        private void Scf_serverConnectionForm()
        {
            menuPanel.Enabled = true;

            string Server = Properties.Settings.Default.Servername;
            string UserName = Properties.Settings.Default.Username;
            string Password = Properties.Settings.Default.Password;

            //await userListResult(Server, UserName, Password);

            MessageBox.Show("Server'a bağlanıldı, Gerekli İşlemler başarılı şekilde yapıldı..", "SERVER CONNECTED", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public async Task<BusinessLayerResult<Users>> userListResult()
        {
            AdminJsonService userjsonManager = new AdminJsonService();
            return await userjsonManager.UserJsonList();
        }

        Pages.CompanyForm companyForm = null;
        private void btnFirmaYonetim_Click(object sender, System.EventArgs e)
        {
            if (companyForm == null || companyForm.Disposing || companyForm.IsDisposed)
            {
                companyForm = new Pages.CompanyForm();
                companyForm.MdiParent = this;
                companyForm.Dock = DockStyle.Fill;
                companyForm.Show();
            }
            else
                companyForm.Activate();
        }

        Pages.UserForm userForm = null;
        private void btnKullaniciYonetim_Click(object sender, System.EventArgs e)
        {
            if (userForm == null || userForm.Disposing || userForm.IsDisposed)
            {
                userForm = new Pages.UserForm();
                userForm.MdiParent = this;
                userForm.Dock = DockStyle.Fill;
                userForm.Show();
            }
            else
                userForm.Activate();
        }

        Pages.RolMuduleForm rolModuleForm = null;
        private void btnRolModul_Click(object sender, System.EventArgs e)
        {
            if (rolModuleForm == null || rolModuleForm.Disposing || rolModuleForm.IsDisposed)
            {
                rolModuleForm = new Pages.RolMuduleForm();
                rolModuleForm.MdiParent = this;
                rolModuleForm.Dock = DockStyle.Fill;
                rolModuleForm.Show();
            }
        }
    }
}