using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class CompanyApplicationLicenseProcess
    {
        static Dictionary<string, CompanyApplicationLicenseProcess> _licenseProcess = new Dictionary<string, CompanyApplicationLicenseProcess>();

        static object _lockObject = new object();
        private CompanyApplicationLicenseProcess() { }

        static CompanyApplicationLicenseManager licenseManager;

        public static CompanyApplicationLicenseProcess UserTokenProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_licenseProcess.ContainsKey(connectionHelper.Database))
                {
                    _licenseProcess.Add(connectionHelper.Database, new CompanyApplicationLicenseProcess());
                }
            }

            licenseManager = new CompanyApplicationLicenseManager(new CompanyApplicationServiceManager(connectionHelper));

            return _licenseProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<CompanyApplicationLicense> AddLicenseFunction(CompanyApplicationLicense model)
        {
            return licenseManager.AddLicense(model);
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplicationFunction(int companyId, int applicationId)
        {
            return licenseManager.FindLicenseByCompanyApplication(companyId, applicationId);
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseByIdFunction(int id)
        {
            return licenseManager.FindLicenseById(id);
        }

        public BusinessLayerResult<CompanyApplicationLicense> GetAllLicensesFunction()
        {
            return licenseManager.GetAllLicenses();
        }

        public BusinessLayerResult<CompanyApplicationLicense> RemoveLicenseFunction(CompanyApplicationLicense model)
        {
            return licenseManager.RemoveLicense(model);
        }
    }
}
