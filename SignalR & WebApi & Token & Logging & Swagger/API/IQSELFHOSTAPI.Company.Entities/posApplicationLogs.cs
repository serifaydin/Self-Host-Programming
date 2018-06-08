using System;

namespace IQSELFHOSTAPI.Company.Entities
{
    public class posApplicationLogs
    {
        public virtual int TabloID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int ModuleID { get; set; }
        public virtual Helpers.EnumBase.ApplicationType AppType { get; set; }
        public virtual Helpers.EnumBase.ProjectNames ProjectName { get; set; }
        public virtual Helpers.Messages.ErrorMessageCode ErrorMessageCode { get; set; }
        public virtual string ErrorText { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}