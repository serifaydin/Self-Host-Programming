using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class ModulesServiceManager : ModulesFactory
    {
        ModulesService modulesService;

        public ModulesServiceManager(ConnectionHelper connectionHelper)
        {
            modulesService = new ModulesService(connectionHelper);
        }

        public override BusinessLayerResult<Modules> ModulesList()
        {
            return modulesService.GetListModules();
        }
    }
}