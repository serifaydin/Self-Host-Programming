using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class CompanyApplicationUserMapping : CustomClassMap<CompanyApplicationUser>
    {
        public CompanyApplicationUserMapping()
        {
            Table("tblCompanyUser");

            References(x => x.Users).Cascade.None().Not.LazyLoad();
            References(x => x.Companies).Cascade.None().Not.LazyLoad();
            References(x => x.Application).Cascade.None().Not.LazyLoad();

            OtherColumnsSet(CustomClassMapStatus.CustomFieldlarıEkleme);
        }
    }
}