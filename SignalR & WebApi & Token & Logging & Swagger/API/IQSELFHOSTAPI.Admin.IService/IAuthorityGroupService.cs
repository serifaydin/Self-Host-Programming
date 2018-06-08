using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface IAuthorityGroupService
    {
        BusinessLayerResult<AuthorityGroup> GetAuthorityById(int id);
        BusinessLayerResult<AuthorityGroup> GetAuthorityGroupList();
    }
}