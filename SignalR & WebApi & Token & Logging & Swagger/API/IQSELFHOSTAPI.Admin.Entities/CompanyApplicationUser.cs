namespace IQSELFHOSTAPI.Admin.Entities
{
    public class CompanyApplicationUser : EntityBase
    {
        public virtual Companies Companies { get; set; }
        public virtual Users Users { get; set; }
        public virtual Application Application { get; set; }
    }
}