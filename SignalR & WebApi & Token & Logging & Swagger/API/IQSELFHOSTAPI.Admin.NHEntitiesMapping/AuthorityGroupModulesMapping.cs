using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class AuthorityGroupModulesMapping : CustomClassMap<AuthorityGroupModules>
    {
        public AuthorityGroupModulesMapping()
        {
            Table("tblAuthorityGroupModules");
            Map(x => x.isDelete).Not.Nullable();
            Map(x => x.isUpdate).Not.Nullable();
            Map(x => x.isInsert).Not.Nullable();
            Map(x => x.IsSelect).Not.Nullable();

            References(x => x.AuthorityGroup).Cascade.None().Not.LazyLoad();
            References(x => x.Modules).Cascade.None().Not.LazyLoad();

            OtherColumnsSet(CustomClassMapStatus.CustomFieldlarıEkleme);
        }
    }
}