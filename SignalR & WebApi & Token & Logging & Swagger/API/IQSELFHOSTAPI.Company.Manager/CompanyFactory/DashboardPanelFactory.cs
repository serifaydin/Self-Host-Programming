using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyFactory
{
    public abstract class DashboardPanelFactory
    {
        public abstract BusinessLayerResult<DashboardPanel> DashboardPanelList();
        public abstract BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model);
    }
}