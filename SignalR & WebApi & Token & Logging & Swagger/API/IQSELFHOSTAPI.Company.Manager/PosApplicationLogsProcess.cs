using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyManager;
using IQSELFHOSTAPI.Company.Manager.CompanyServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Company.Manager
{
    public class PosApplicationLogsProcess
    {
        static Dictionary<string, PosApplicationLogsProcess> _posBranchProcess = new Dictionary<string, PosApplicationLogsProcess>();
        static object _lockObject = new object();
        private PosApplicationLogsProcess() { }

        static PosApplicationLogsManager manager;

        public static PosApplicationLogsProcess PosApplicationLogProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_posBranchProcess.ContainsKey(connectionHelper.Database))
                {
                    _posBranchProcess.Add(connectionHelper.Database, new PosApplicationLogsProcess());
                }
            }

            manager = new PosApplicationLogsManager(new PosApplicationLogsServiceManager(connectionHelper));

            return _posBranchProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<posApplicationLogs> posApplicationLogInsert(posApplicationLogs model)
        {
            return manager.PosApplicationLogInsert(model);
        }
    }
}