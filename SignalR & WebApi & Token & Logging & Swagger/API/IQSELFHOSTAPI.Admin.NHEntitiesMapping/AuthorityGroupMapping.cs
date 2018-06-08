using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class AuthorityGroupMapping : CustomClassMap<AuthorityGroup>
    {
        public AuthorityGroupMapping()
        {
            Table("tblAuthorityGroup");
            Map(x => x.AuthorityName).Not.Nullable();

            OtherColumnsSet(CustomClassMapStatus.SadeceID);
        }
    }
}