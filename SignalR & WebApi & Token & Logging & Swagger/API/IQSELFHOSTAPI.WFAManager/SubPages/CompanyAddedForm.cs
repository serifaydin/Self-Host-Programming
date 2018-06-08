using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.WFAManager.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager.SubPages
{
    public partial class CompanyAddedForm : Form
    {
        public delegate void CompanyAddedFormEvent();
        public event CompanyAddedFormEvent conpanyEvent;


        AdminService adminService;

        public CompanyAddedForm()
        {
            InitializeComponent();

            txtServerName.Text = Properties.Settings.Default.Servername;
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;

            adminService = new AdminService();
        }

        private async void btnConpanyAdded_Click(object sender, System.EventArgs e)
        {
            Companies _company = new Companies();
            _company.CompanyName = txtConpanyName.Text;
            _company.CompanyFullName = txtCompanyFullPath.Text;
            _company.PeriodYear = int.Parse(txtPeriodYear.Text);
            _company.PeriodStartDate = dtStarted.Value;
            _company.PeriodEndDate = dateEnddate.Value;
            _company.ServerName = txtServerName.Text;
            _company.ServerUsername = txtUsername.Text;
            _company.ServerPassword = txtPassword.Text;
            _company.DatabaseName = txtDatabaseName.Text;
            _company.Address = txtAdress.Text;
            _company.Address2 = txtAdress2.Text;
            _company.WebSite = txtWebSite.Text;
            _company.Email = txtEmail.Text;
            _company.Phone = txtPhone.Text;
            _company.Phone2 = txtPhone2.Text;
            _company.IsActive = chcIsActive.Checked;

            DateTime _date = DateTime.Now;

            _company.CreatedOn = _date;
            _company.ModifiedOn = _date;
            _company.ModifiedUsername = "";
            BusinessLayerResult<Companies> companyResult = await adminService.CompanyInsert(_company);

            if (companyResult.Result)
            {
                conpanyEvent();
                MessageBox.Show("Firma başarılı şekilde eklendi.");
            }
            else
            {

            }
        }
    }
}