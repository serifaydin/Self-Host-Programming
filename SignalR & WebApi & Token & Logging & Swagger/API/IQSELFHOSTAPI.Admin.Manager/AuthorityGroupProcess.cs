using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class AuthorityGroupProcess
    {
        static Dictionary<string, AuthorityGroupProcess> _authorityProcess = new Dictionary<string, AuthorityGroupProcess>();
        static object _lockObject = new object();
        private AuthorityGroupProcess() { }

        static AuthorityGroupManager authorityManager;

        public static AuthorityGroupProcess AuthorityProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_authorityProcess.ContainsKey(connectionHelper.Database))
                {
                    _authorityProcess.Add(connectionHelper.Database, new AuthorityGroupProcess());
                }
            }

            authorityManager = new AuthorityGroupManager(new AuthorityGroupServiceManager(connectionHelper));

            return _authorityProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<AuthorityGroup> GetAuthorityModel(int id)
        {
            return authorityManager.GetAuthorityGroupModel(id);
        }

        public BusinessLayerResult<AuthorityGroup> GetAuthorityList()
        {
            return authorityManager.GetAuthorityGroupList();
        }
    }
}