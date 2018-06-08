using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class CompanyApplicationServiceManager : CompanyApplicationLicenseFactory
    {
        CompanyApplicationLicenseService licenseService;

        public CompanyApplicationServiceManager(ConnectionHelper connectionHelper)
        {
            licenseService = new CompanyApplicationLicenseService(connectionHelper);
        }

        public override BusinessLayerResult<CompanyApplicationLicense> AddLicense(CompanyApplicationLicense model)
        {
            return licenseService.AddLicense(model);
        }

        public override BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplication(int companyId, int applicationId)
        {
            return licenseService.FindLicenseByCompanyApplication(companyId, applicationId);
        }

        public override BusinessLayerResult<CompanyApplicationLicense> FindLicenseById(int id)
        {
            return licenseService.FindLicenseById(id);
        }

        public override BusinessLayerResult<CompanyApplicationLicense> GetAllLicenses()
        {
            return licenseService.GetAllLicenses();
        }

        public override BusinessLayerResult<CompanyApplicationLicense> RemoveLicense(CompanyApplicationLicense model)
        {
            return licenseService.RemoveLicense(model);
        }
    }
}
