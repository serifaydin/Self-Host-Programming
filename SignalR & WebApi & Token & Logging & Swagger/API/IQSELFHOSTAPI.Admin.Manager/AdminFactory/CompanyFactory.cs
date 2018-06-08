using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class CompanyFactory
    {
        public abstract BusinessLayerResult<Companies> GetCompanyFullList();
        public abstract BusinessLayerResult<Companies> CompanyAdded(Companies model);
    }
}