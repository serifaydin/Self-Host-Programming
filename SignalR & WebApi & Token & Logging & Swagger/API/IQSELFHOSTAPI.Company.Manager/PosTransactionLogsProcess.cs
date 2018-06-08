using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyManager;
using IQSELFHOSTAPI.Company.Manager.CompanyServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Company.Manager
{
    public class PosTransactionLogsProcess
    {
        static Dictionary<string, PosTransactionLogsProcess> _posBranchProcess = new Dictionary<string, PosTransactionLogsProcess>();
        static object _lockObject = new object();
        private PosTransactionLogsProcess() { }

        static PosTransactionLogsManager manager;

        public static PosTransactionLogsProcess PosTransactionLogProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_posBranchProcess.ContainsKey(connectionHelper.Database))
                {
                    _posBranchProcess.Add(connectionHelper.Database, new PosTransactionLogsProcess());
                }
            }

            manager = new PosTransactionLogsManager(new PosTransactionLogsServiceManager(connectionHelper));

            return _posBranchProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<posTransactionLogs> posTransactionLogInsert(posTransactionLogs model)
        {
            return manager.PosTransactionLogInsert(model);
        }
    }
}