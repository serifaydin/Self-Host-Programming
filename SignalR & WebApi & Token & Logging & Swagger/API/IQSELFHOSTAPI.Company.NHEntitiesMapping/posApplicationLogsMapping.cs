using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Company.Entities;

namespace IQSELFHOSTAPI.Company.NHEntitiesMapping
{
    public class posApplicationLogsMapping : ClassMap<posApplicationLogs>
    {
        public posApplicationLogsMapping()
        {
            Table("tblposApplicationLogs");
            Id(x => x.TabloID).GeneratedBy.Identity();
            Map(x => x.UserID).Not.Nullable();
            Map(x => x.ModuleID).Not.Nullable();
            Map(x => x.AppType).Not.Nullable();
            Map(x => x.ProjectName).Not.Nullable();
            Map(x => x.ErrorMessageCode).Not.Nullable();
            Map(x => x.ErrorText).Not.Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
        }
    }
}