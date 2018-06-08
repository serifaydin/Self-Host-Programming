using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class UserMapping : CustomClassMap<Users>
    {
        public UserMapping()
        {
            Table("tblUsers");
            Map(x => x.Username).Not.Nullable().Length(150).Unique();
            Map(x => x.Password).Not.Nullable().Length(150);
            Map(x => x.UserFullName).Not.Nullable();
            Map(x => x.LastLoginDate).Not.Nullable();
            Map(x => x.LastCompanyID).Not.Nullable();
            Map(x => x.ReportStatusValue).Not.Nullable();

            OtherColumnsSet(CustomClassMapStatus.CustomFieldlarıEkleme);

            References(x => x.AuthorityGroup).Cascade.None().Not.LazyLoad();
        }
    }
}