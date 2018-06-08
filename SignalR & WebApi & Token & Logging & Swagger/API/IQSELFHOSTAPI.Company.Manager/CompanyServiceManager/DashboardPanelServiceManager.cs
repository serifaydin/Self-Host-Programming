using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Company.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyServiceManager
{
    public class DashboardPanelServiceManager : DashboardPanelFactory
    {
        DashboardPanelService service;
        public DashboardPanelServiceManager(ConnectionHelper connectionHelper)
        {
            service = new DashboardPanelService(connectionHelper);
        }

        public override BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model)
        {
            return service.DashboardPanelAdded(model);
        }

        public override BusinessLayerResult<DashboardPanel> DashboardPanelList()
        {
            return service.DashboardPanelList();
        }
    }
}