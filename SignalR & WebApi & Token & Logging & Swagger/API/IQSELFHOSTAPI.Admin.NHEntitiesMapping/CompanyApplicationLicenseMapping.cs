using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class CompanyApplicationLicenseMapping : ClassMap<CompanyApplicationLicense>
    {
        public CompanyApplicationLicenseMapping()
        {
            Table("tblCompanyApplicationLicense");

            Id(x => x.TabloID).GeneratedBy.Identity();
            References(x => x.Application).Cascade.None().Not.LazyLoad();
            References(x => x.Companies).Cascade.None().Not.LazyLoad();
            Map(x => x.ApplicationLicenseSize).Not.Nullable();
        }
    }
}