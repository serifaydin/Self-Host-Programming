using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyFactory
{
    public abstract class PosApplicationLogsFactory
    {
        public abstract BusinessLayerResult<posApplicationLogs> PosApplicationLogInsert(posApplicationLogs log);
    }
}