using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Entities
{
    public class Users : EntityBase
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserFullName { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual int LastCompanyID { get; set; }
        public virtual Int16 ReportStatusValue { get; set; }
        public virtual AuthorityGroup AuthorityGroup { get; set; }
    }
}