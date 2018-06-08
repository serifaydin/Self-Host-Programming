using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class UserTokenMapping : CustomClassMap<UserToken>
    {
        public UserTokenMapping()
        {
            Table("tblUserTokens");
            Map(x => x.AccessToken).Not.Nullable().Length(1000);
            Map(x => x.ExpireDate).Not.Nullable();

            References(x => x.Application).Cascade.None().Not.LazyLoad();
            References(x => x.Company).Cascade.None().Not.LazyLoad();
            References(x => x.User).Cascade.None().Not.LazyLoad();


            OtherColumnsSet(CustomClassMapStatus.CustomFieldlarıEkleme);
        }
    }
}
