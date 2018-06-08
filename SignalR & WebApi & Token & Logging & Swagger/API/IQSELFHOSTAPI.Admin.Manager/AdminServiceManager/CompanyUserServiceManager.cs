using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class CompanyUserServiceManager : CompanyUserFactory
    {
        CompanyUserService companyUserService;
        public CompanyUserServiceManager(ConnectionHelper connectionHelper)
        {
            companyUserService = new CompanyUserService(connectionHelper);
        }
        public override BusinessLayerResult<CompanyApplicationUser> CompanyUserAdded(CompanyApplicationUser model)
        {
            return companyUserService.CompanyUserAdded(model);
        }
        public override BusinessLayerResult<bool> FindUserInApp(int userId, int appId, int companyId)
        {
            return companyUserService.FindUserInApp(userId, appId, companyId);
        }
    }
}