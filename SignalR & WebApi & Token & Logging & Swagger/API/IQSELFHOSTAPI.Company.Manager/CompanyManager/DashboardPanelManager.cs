using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Company.Manager.CompanyManager
{
    public class DashboardPanelManager
    {
        DashboardPanelFactory factory;

        public DashboardPanelManager(DashboardPanelFactory _factory)
        {
            factory = _factory;
        }

        public BusinessLayerResult<DashboardPanel> GetFullDashboardPanelList()
        {
            return factory.DashboardPanelList();
        }

        public BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model)
        {
            return factory.DashboardPanelAdded(model);
        }
    }
}