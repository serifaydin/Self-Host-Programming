using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface ICompanyApplicationLicenseService
    {
        BusinessLayerResult<CompanyApplicationLicense> AddLicense(CompanyApplicationLicense model);
        BusinessLayerResult<CompanyApplicationLicense> RemoveLicense(CompanyApplicationLicense model);
        BusinessLayerResult<CompanyApplicationLicense> FindLicenseById(int id);
        BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplication(int companyId,int applicationId);
        BusinessLayerResult<CompanyApplicationLicense> GetAllLicenses();
    }
}
