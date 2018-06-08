using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.WFAManager.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQSELFHOSTAPI.WFAManager.Pages
{
    public partial class UserForm : Form
    {
        AdminService adminService;
        public UserForm()
        {
            InitializeComponent();
            adminService = new AdminService();
            userGridList();
        }

        private void btnUserInsert_Click(object sender, EventArgs e)
        {
            SubPages.UserAddedForm uaf = new SubPages.UserAddedForm();
            uaf.UserEvent += Uaf_UserEvent;
            uaf.ShowDialog();
        }

        private void Uaf_UserEvent()
        {
            userGridList();
        }

        private async Task userGridList()
        {
            BusinessLayerResult<Users> userResult = await adminService.GetUserList();
            var _res = from u in userResult.Objects.ToList()
                       select new
                       {
                           u.TabloID,
                           u.Username,
                           u.UserFullName,
                           u.ReportStatusValue,
                           u.IsActive,
                           u.AuthorityGroup.AuthorityName
                       };

            dataGridUser.DataSource = _res.ToList();
        }

        private void btnKullanıcıGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridUser.SelectedRows.Count == 1)
            {
                int updatedUserId = Convert.ToInt32(this.dataGridUser.SelectedRows[0].Cells["TabloID"].Value.ToString());

                SubPages.UserAddedForm uaf = new SubPages.UserAddedForm(true);
                uaf.ShowDialog();
            }
        }
    }
}