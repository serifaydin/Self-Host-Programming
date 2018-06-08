using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class CompanyUserFactory
    {
        public abstract BusinessLayerResult<CompanyApplicationUser> CompanyUserAdded(CompanyApplicationUser model);
        public abstract BusinessLayerResult<bool> FindUserInApp(int userId, int appId, int companyId);
    }
}