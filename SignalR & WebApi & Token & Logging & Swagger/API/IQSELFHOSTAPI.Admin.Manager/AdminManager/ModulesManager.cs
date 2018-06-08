using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class ModulesManager
    {
        private ModulesFactory _modulesManager;

        public ModulesManager(ModulesFactory modulesManager)
        {
            _modulesManager = modulesManager;
        }

        public BusinessLayerResult<Modules> GetModulesList()
        {
            return _modulesManager.ModulesList();
        }
    }
}