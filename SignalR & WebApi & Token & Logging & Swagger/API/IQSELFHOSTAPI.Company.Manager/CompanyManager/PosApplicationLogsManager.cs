using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyManager
{
    public class PosApplicationLogsManager
    {
        PosApplicationLogsFactory posApplicationLogsFactory;

        public PosApplicationLogsManager(PosApplicationLogsFactory _posApplicationLogsFactory)
        {
            posApplicationLogsFactory = _posApplicationLogsFactory;
        }

        public BusinessLayerResult<posApplicationLogs> PosApplicationLogInsert(posApplicationLogs model)
        {
            return posApplicationLogsFactory.PosApplicationLogInsert(model);
        }
    }
}