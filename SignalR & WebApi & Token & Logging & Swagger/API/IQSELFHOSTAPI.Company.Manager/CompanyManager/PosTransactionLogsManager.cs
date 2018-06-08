using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyManager
{
    public class PosTransactionLogsManager
    {
        PosTransactionLogsFactory posTransactionLogsFactory;

        public PosTransactionLogsManager(PosTransactionLogsFactory _posTransactionLogsFactory)
        {
            posTransactionLogsFactory = _posTransactionLogsFactory;
        }
        public BusinessLayerResult<posTransactionLogs> PosTransactionLogInsert(posTransactionLogs model)
        {
            return posTransactionLogsFactory.PosTransactionLogInsert(model);
        }
    }
}
