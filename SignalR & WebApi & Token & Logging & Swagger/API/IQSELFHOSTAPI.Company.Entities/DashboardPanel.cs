using IQSELFHOSTAPI.Company.Entities.HelperModels;

namespace IQSELFHOSTAPI.Company.Entities
{
    public class DashboardPanel : EntityBase
    {
        public virtual string PanelTitle { get; set; }
        public virtual string PanelQuery { get; set; }
        public virtual string PanelColor { get; set; }
        public virtual string PanelColumn { get; set; }
        public virtual string PanelIcon { get; set; }
        public virtual string PanelUnit { get; set; }
        public virtual int RefreshTime { get; set; }
    }
}