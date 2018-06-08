using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Company.Service;
using IQSELFHOSTAPI.Helpers;
using System;

namespace IQSELFHOSTAPI.Company.Manager.CompanyServiceManager
{
    public class PosTransactionLogsServiceManager : PosTransactionLogsFactory
    {
        PosTransactionLogsService posTransactionLogService;

        public PosTransactionLogsServiceManager(ConnectionHelper connectionHelper)
        {
            posTransactionLogService = new PosTransactionLogsService(connectionHelper);
        }
        public override BusinessLayerResult<posTransactionLogs> PosTransactionLogInsert(posTransactionLogs log)
        {
            return posTransactionLogService.TransactionLogInsert(log);
        }
    }
}