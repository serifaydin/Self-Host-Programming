using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class ModulesProcess
    {
        static Dictionary<string, ModulesProcess> _moduleProcess = new Dictionary<string, ModulesProcess>();
        static object _lockObject = new object();
        private ModulesProcess() { }

        static ModulesManager modulesManager;

        public static ModulesProcess ModuleProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_moduleProcess.ContainsKey(connectionHelper.Database))
                {
                    _moduleProcess.Add(connectionHelper.Database, new ModulesProcess());
                }
            }

            modulesManager = new ModulesManager(new ModulesServiceManager(connectionHelper));

            return _moduleProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<Modules> GetFullModuleList()
        {
            return modulesManager.GetModulesList();
        }
    }
}