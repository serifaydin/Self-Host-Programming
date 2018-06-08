using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class AuthorityGroupManager
    {
        private AuthorityGroupFactory _authorityManager;

        public AuthorityGroupManager(AuthorityGroupFactory authorityManager)
        {
            _authorityManager = authorityManager;
        }

        public BusinessLayerResult<AuthorityGroup> GetAuthorityGroupModel(int id)
        {
            return _authorityManager.AuthorityGroupModel(id);

        }

        public BusinessLayerResult<AuthorityGroup> GetAuthorityGroupList()
        {
            return _authorityManager.AuthorityGroupList();
        }
    }
}