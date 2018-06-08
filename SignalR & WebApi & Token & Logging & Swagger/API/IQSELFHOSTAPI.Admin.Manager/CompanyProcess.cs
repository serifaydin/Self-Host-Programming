using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class CompanyProcess
    {
        static Dictionary<string, CompanyProcess> _companyProcess = new Dictionary<string, CompanyProcess>();
        static object _lockObject = new object();
        private CompanyProcess() { }

        static CompanyManager companyManager;

        public static CompanyProcess CompanyProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_companyProcess.ContainsKey(connectionHelper.Database))
                {
                    _companyProcess.Add(connectionHelper.Database, new CompanyProcess());
                }
            }

            companyManager = new CompanyManager(new CompanyServiceManager(connectionHelper));

            return _companyProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<Companies> GetFullCompanyList()
        {
            return companyManager.GetFullCompanyList();
        }

        public BusinessLayerResult<Companies> CompanyInserFunction(Companies model)
        {
            return companyManager.CompanyInsert(model);
        }
    }
}