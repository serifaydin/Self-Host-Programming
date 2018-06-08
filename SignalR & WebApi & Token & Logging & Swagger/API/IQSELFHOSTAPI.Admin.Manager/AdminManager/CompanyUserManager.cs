using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class CompanyUserManager
    {
        private CompanyUserFactory _companyUserManager;

        public CompanyUserManager(CompanyUserFactory companyUserManager)
        {
            _companyUserManager = companyUserManager;
        }

        public BusinessLayerResult<CompanyApplicationUser> CompanyUserInsert(CompanyApplicationUser model)
        {
            return _companyUserManager.CompanyUserAdded(model);
        }

        public BusinessLayerResult<bool> CanUseToApplication(int userId,int appId,int companyId)
        {
            return _companyUserManager.FindUserInApp(userId, appId, companyId);
        }
    }
}