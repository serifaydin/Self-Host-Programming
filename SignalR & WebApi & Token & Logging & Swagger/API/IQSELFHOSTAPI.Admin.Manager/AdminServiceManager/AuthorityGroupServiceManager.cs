using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    class AuthorityGroupServiceManager : AuthorityGroupFactory
    {
        AuthorityGroupService authorityGroupService;

        public AuthorityGroupServiceManager(ConnectionHelper connectionHelper)
        {
            authorityGroupService = new AuthorityGroupService(connectionHelper);
        }

        public override BusinessLayerResult<AuthorityGroup> AuthorityGroupList()
        {
            return authorityGroupService.GetAuthorityGroupList();
        }

        public override BusinessLayerResult<AuthorityGroup> AuthorityGroupModel(int id)
        {
            return authorityGroupService.GetAuthorityById(id);
        }
    }
}