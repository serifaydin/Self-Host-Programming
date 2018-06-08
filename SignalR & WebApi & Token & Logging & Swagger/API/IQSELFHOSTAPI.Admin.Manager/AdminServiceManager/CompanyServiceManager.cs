using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class CompanyServiceManager : CompanyFactory
    {
        CompanyService _companyService;

        public CompanyServiceManager(ConnectionHelper connectionHelper)
        {
            _companyService = new CompanyService(connectionHelper);
        }

        public override BusinessLayerResult<Companies> GetCompanyFullList()
        {
            return _companyService.CompanyFullList();
        }

        public override BusinessLayerResult<Companies> CompanyAdded(Companies model)
        {
            return _companyService.CompanyAdded(model);
        }
    }
}