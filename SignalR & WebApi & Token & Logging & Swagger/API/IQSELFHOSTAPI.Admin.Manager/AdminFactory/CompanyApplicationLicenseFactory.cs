using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class CompanyApplicationLicenseFactory
    {
        public abstract BusinessLayerResult<CompanyApplicationLicense> AddLicense(CompanyApplicationLicense model);
        public abstract BusinessLayerResult<CompanyApplicationLicense> RemoveLicense(CompanyApplicationLicense model);
        public abstract BusinessLayerResult<CompanyApplicationLicense> FindLicenseById(int id);
        public abstract BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplication(int companyId, int applicationId);
        public abstract BusinessLayerResult<CompanyApplicationLicense> GetAllLicenses();
    }
}
