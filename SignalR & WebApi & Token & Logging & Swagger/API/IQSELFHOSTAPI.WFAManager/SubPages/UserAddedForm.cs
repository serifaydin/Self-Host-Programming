using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.WFAManager.Services;
using System;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager.SubPages
{
    public partial class UserAddedForm : Form
    {
        public delegate void UserAddedEvent();
        public event UserAddedEvent UserEvent;

        AdminService adminService = new AdminService();

        public UserAddedForm(bool isUpdated = false)
        {
            if (isUpdated == true)
            {
                this.Text = "Kullanıcı Güncelle";
            }

            InitializeComponent();
            AuthorityGroupComboList();
            CompanyListResult();
        }

        private async void AuthorityGroupComboList()
        {
            BusinessLayerResult<AuthorityGroup> listAuthorityResult = await adminService.AuthorityGroupList();
            cbAuthority.DataSource = listAuthorityResult.Objects;
            cbAuthority.ValueMember = "TabloID";
            cbAuthority.DisplayMember = "AuthorityName";
        }

        private async void btnUserAdded_Click(object sender, System.EventArgs e)
        {
            Users _user = new Users();
            _user.Username = txtUsername.Text;
            _user.Password = txtPassword.Text;
            _user.UserFullName = txtFullName.Text;
            _user.ReportStatusValue = Int16.Parse(txtReportValue.Text);
            _user.IsActive = chcIsActive.Checked;

            BusinessLayerResult<AuthorityGroup> authorityGroupResult = await adminService.AuthorityGroupModel(int.Parse(cbAuthority.SelectedValue.ToString()));
            _user.AuthorityGroup = authorityGroupResult.Object;

            DateTime _Date = DateTime.Now;

            _user.CreatedOn = _Date;
            _user.ModifiedOn = _Date;
            _user.ModifiedUsername = "";

            BusinessLayerResult<Users> userAddedResult = await adminService.UserReturnModelInsert(_user);

            if (userAddedResult.Result)
            {
                ////CompanyUser
                foreach (var item in chcListCompany.CheckedItems)
                {
                    Companies _company = (Companies)item;

                    BusinessLayerResult<CompanyApplicationUser> CompanyUserResult = await adminService.CompanyUserAdded(new CompanyApplicationUser
                    {
                        Companies = _company,
                        Users = userAddedResult.Object,

                        CreatedOn = _Date,
                        ModifiedOn = _Date,
                        IsActive = true
                    });
                }
                ////------------
                UserEvent();
            }
            else
                MessageBox.Show("Hata Oluştu : ");
        }

        public async void CompanyListResult()
        {
            BusinessLayerResult<Companies> CompanyResult = await adminService.GetCompanyList();

            ((ListBox)chcListCompany).DataSource = CompanyResult.Objects;
            ((ListBox)chcListCompany).DisplayMember = "CompanyName";
            ((ListBox)chcListCompany).ValueMember = "TabloID";
        }
    }
}