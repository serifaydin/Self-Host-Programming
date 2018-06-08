using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class CompanyManager
    {
        private CompanyFactory _companyManager;

        public CompanyManager(CompanyFactory companyFactory)
        {
            _companyManager = companyFactory;
        }

        public BusinessLayerResult<Companies> GetFullCompanyList()
        {
            return _companyManager.GetCompanyFullList();
        }

        public BusinessLayerResult<Companies> CompanyInsert(Companies model)
        {
            return _companyManager.CompanyAdded(model);
        }
    }
}