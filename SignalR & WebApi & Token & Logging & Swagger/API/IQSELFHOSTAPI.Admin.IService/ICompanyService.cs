using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface ICompanyService
    {
        BusinessLayerResult<Companies> CompanyAdded(Companies model);
        BusinessLayerResult<Companies> CompanyFullList();
    }
}