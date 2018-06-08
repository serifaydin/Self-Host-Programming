using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.IService
{
    public interface IPosTransactionLogsService
    {
        BusinessLayerResult<posTransactionLogs> TransactionLogInsert(posTransactionLogs model);
    }
}