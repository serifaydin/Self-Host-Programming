using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class CompanyApplicationLicenseManager
    {
        private CompanyApplicationLicenseFactory _factory;
        public CompanyApplicationLicenseManager(CompanyApplicationLicenseFactory  factory)
        {
            _factory = factory;
        }
        public BusinessLayerResult<CompanyApplicationLicense> AddLicense(CompanyApplicationLicense model)
        {
            return _factory.AddLicense(model);
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplication(int companyId, int applicationId)
        {
            return _factory.FindLicenseByCompanyApplication(companyId, applicationId);
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseById(int id)
        {
            return _factory.FindLicenseById(id);
        }

        public BusinessLayerResult<CompanyApplicationLicense> GetAllLicenses()
        {
            return _factory.GetAllLicenses();
        }

        public BusinessLayerResult<CompanyApplicationLicense> RemoveLicense(CompanyApplicationLicense model)
        {
            return _factory.RemoveLicense(model);
        }
    }
}
