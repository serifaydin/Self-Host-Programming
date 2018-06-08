using FluentNHibernate.Mapping;
using IQSELFHOSTAPI.Company.Entities;

namespace IQSELFHOSTAPI.Company.NHEntitiesMapping
{
    public class DashboardPanelMapping : CustomClassMap<DashboardPanel>
    {
        public DashboardPanelMapping()
        {
            Table("tblDashboardPanel");
            Map(x => x.PanelTitle).Not.Nullable().Length(500);
            Map(x => x.PanelQuery).Not.Nullable().Length(500);
            Map(x => x.PanelColor).Not.Nullable().Length(500);
            Map(x => x.PanelColumn).Not.Nullable().Length(500);
            Map(x => x.PanelIcon).Not.Nullable().Length(500);
            Map(x => x.PanelUnit).Not.Nullable().Length(500);
            Map(x => x.RefreshTime).Not.Nullable();
        }
    }
}