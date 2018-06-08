using System;

namespace IQSELFHOSTAPI.Admin.Entities
{
    public class EntityBase : EntityCustomBase
    {
        public virtual int TabloID { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual string ModifiedUsername { get; set; }
        public virtual bool IsActive { get; set; }
    }
}