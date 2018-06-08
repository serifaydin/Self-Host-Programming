using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.BackOfficeAPI.JsonManager
{
    public class DashboardPanelJsonService : BaseHttpJsonService<DashboardPanel>
    {
        public async Task<BusinessLayerResult<DashboardPanel>> DashboardPanelList()
        {
            return await SelectFunction("DashboardPanelList");
        }

        protected async Task<BusinessLayerResult<DashboardPanel>> InsertOrUpdateOrDeleteFunction(DashboardPanel model)
        {
            return await InsertOrUpdateOrDeleteFunction(model, "DashboardPanelAdded");
        }
    }
}