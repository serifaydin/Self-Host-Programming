using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface ICompanyUserService
    {
        BusinessLayerResult<CompanyApplicationUser> CompanyUserAdded(CompanyApplicationUser model);
        BusinessLayerResult<bool> FindUserInApp(int userId, int appId,int companyId);
    }
}