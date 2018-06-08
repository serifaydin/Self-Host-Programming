using System;

namespace IQSELFHOSTAPI.Admin.Entities
{
    public class Companies : EntityBase
    {
        public virtual string CompanyName { get; set; }
        public virtual string CompanyFullName { get; set; }
        public virtual int PeriodYear { get; set; }
        public virtual DateTime PeriodStartDate { get; set; }
        public virtual DateTime PeriodEndDate { get; set; }

        public virtual string ServerName { get; set; }
        public virtual string ServerUsername { get; set; }
        public virtual string ServerPassword { get; set; }
        public virtual string DatabaseName { get; set; }

        public virtual string Address { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string WebSite { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Phone2 { get; set; }
    }
}