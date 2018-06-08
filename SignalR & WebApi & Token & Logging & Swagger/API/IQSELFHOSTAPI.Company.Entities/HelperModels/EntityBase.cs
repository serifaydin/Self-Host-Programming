using System;

namespace IQSELFHOSTAPI.Company.Entities.HelperModels
{
    public class EntityBase
    {
        public virtual int TabloID { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime CreatedOn { get; set; }
    }
}