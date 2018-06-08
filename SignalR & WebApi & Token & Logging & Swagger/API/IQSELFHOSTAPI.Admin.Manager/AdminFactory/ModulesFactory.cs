using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class ModulesFactory
    {
        public abstract BusinessLayerResult<Modules> ModulesList();
    }
}