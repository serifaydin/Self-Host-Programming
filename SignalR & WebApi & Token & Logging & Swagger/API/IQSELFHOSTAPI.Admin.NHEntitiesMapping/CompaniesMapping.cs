
using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class CompaniesMapping : CustomClassMap<Companies>
    {
        public CompaniesMapping()
        {
            Table("tblCompanies");
            Map(x => x.CompanyName).Not.Nullable().Length(150);
            Map(x => x.CompanyFullName).Not.Nullable().Length(150);
            Map(x => x.PeriodYear);
            Map(x => x.PeriodStartDate);
            Map(x => x.PeriodEndDate);
            Map(x => x.ServerName).Not.Nullable().Length(150);
            Map(x => x.ServerUsername).Not.Nullable().Length(150);
            Map(x => x.ServerPassword).Not.Nullable().Length(150);
            Map(x => x.DatabaseName).Not.Nullable().Length(150);
            Map(x => x.Address);
            Map(x => x.Address2);
            Map(x => x.WebSite);
            Map(x => x.Email);
            Map(x => x.Phone);
            Map(x => x.Phone2);

            OtherColumnsSet(CustomClassMapStatus.CustomFieldlarıEkleme);
        }
    }
}