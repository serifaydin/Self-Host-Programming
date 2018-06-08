using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyFactory
{
    public abstract class PosTransactionLogsFactory
    {
        public abstract BusinessLayerResult<posTransactionLogs> PosTransactionLogInsert(posTransactionLogs log);
    }
}