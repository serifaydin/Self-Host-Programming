using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Admin.Entities;

namespace IQSELFHOSTAPI.Admin.NHEntitiesMapping
{
    public class ApplicationMapping : ClassMap<Application>
    {
        public ApplicationMapping()
        {
            Table("tblApplications");
            Id(x => x.TabloID).GeneratedBy.Identity();
            Map(x => x.ApplicationName).Not.Nullable();
        }
    }
}