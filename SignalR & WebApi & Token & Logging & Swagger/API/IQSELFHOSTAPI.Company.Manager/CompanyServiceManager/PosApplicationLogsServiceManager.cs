using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Company.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyServiceManager
{
    public class PosApplicationLogsServiceManager : PosApplicationLogsFactory
    {
        PosApplicationLogsService posApplicationLogService;

        public PosApplicationLogsServiceManager(ConnectionHelper connectionHelper)
        {
            posApplicationLogService = new PosApplicationLogsService(connectionHelper);
        }

        public override BusinessLayerResult<posApplicationLogs> PosApplicationLogInsert(posApplicationLogs log)
        {
            return posApplicationLogService.ApplicationLogInsert(log);
        }
    }
}