using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class AuthorityGroupFactory
    {
        public abstract BusinessLayerResult<AuthorityGroup> AuthorityGroupModel(int id);
        public abstract BusinessLayerResult<AuthorityGroup> AuthorityGroupList();
    }
}