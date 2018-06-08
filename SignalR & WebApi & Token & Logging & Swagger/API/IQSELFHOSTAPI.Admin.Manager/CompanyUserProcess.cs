using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class CompanyUserProcess
    {
        static Dictionary<string, CompanyUserProcess> _companyProcess = new Dictionary<string, CompanyUserProcess>();
        static object _lockObject = new object();
        private CompanyUserProcess() { }

        static CompanyUserManager companyUserManager;

        public static CompanyUserProcess CompanyUserProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_companyProcess.ContainsKey(connectionHelper.Database))
                {
                    _companyProcess.Add(connectionHelper.Database, new CompanyUserProcess());
                }
            }

            companyUserManager = new CompanyUserManager(new CompanyUserServiceManager(connectionHelper));

            return _companyProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<CompanyApplicationUser> CompanyUserInserFunction(CompanyApplicationUser model)
        {
            return companyUserManager.CompanyUserInsert(model);
        }

        public BusinessLayerResult<bool> CanUseToApplication(int userId, int appId, int companyId)
        {
            return companyUserManager.CanUseToApplication(userId, appId, companyId);
        }
    }
}