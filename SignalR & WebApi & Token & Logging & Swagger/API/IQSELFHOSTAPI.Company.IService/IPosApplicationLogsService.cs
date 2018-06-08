using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.IService
{
    public interface IPosApplicationLogsService
    {
        BusinessLayerResult<posApplicationLogs> ApplicationLogInsert(posApplicationLogs model);
    }
}