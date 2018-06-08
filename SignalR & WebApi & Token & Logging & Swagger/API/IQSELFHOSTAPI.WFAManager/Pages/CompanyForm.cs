using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.WFAManager.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager.Pages
{
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        AdminService adminService;

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            adminService = new AdminService();
            CompanyListResult();
        }

        public async void CompanyListResult()
        {
            BusinessLayerResult<Companies> CompanyResult = await adminService.GetCompanyList();
            var _res = from c in CompanyResult.Objects.ToList()
                       select new
                       {
                           c.CompanyName,
                           c.CompanyFullName,
                           c.ServerName,
                           c.DatabaseName,
                           c.CreatedOn,
                           c.IsActive
                       };

            dataGridCompany.DataSource = _res.ToList();
        }

        private void btnFirmaEkle_Click(object sender, EventArgs e)
        {
            SubPages.CompanyAddedForm caf = new SubPages.CompanyAddedForm();
            caf.conpanyEvent += Caf_conpanyEvent;
            caf.ShowDialog();
        }

        private void Caf_conpanyEvent()
        {
            CompanyListResult();
        }
    }
}