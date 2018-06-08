using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface IModulesService
    {
        BusinessLayerResult<Modules> GetListModules();
    }
}