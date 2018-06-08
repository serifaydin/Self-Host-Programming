using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.IService
{
    public interface IDashboardPanelService
    {
        BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model);
        BusinessLayerResult<DashboardPanel> DashboardPanelList();
    }
}