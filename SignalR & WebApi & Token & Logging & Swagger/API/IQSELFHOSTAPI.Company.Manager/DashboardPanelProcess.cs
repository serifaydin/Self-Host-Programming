using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager.CompanyManager;
using IQSELFHOSTAPI.Company.Manager.CompanyServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Company.Manager
{
    public class DashboardPanelProcess
    {
        static Dictionary<string, DashboardPanelProcess> _dashboardPanelProcess = new Dictionary<string, DashboardPanelProcess>();
        static object _lockObject = new object();
        private DashboardPanelProcess() { }

        static DashboardPanelManager manager;

        public static DashboardPanelProcess DashboardPanelProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_dashboardPanelProcess.ContainsKey(connectionHelper.Database))
                {
                    _dashboardPanelProcess.Add(connectionHelper.Database, new DashboardPanelProcess());
                }
            }

            manager = new DashboardPanelManager(new DashboardPanelServiceManager(connectionHelper));

            return _dashboardPanelProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<DashboardPanel> GetFullDashboardPanelList()
        {
            return manager.GetFullDashboardPanelList();
        }

        public BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model)
        {
            return manager.DashboardPanelAdded(model);
        }
    }
}