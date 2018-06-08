namespace IQSELFHOSTAPI.Admin.Entities
{
    public class Modules : EntityBase
    {
        public virtual string ModuleName { get; set; }
        public virtual int TopModuleID { get; set; }
    }
}