namespace IQSELFHOSTAPI.Admin.Entities
{
    public class AuthorityGroupModules : EntityBase
    {
        public virtual AuthorityGroup AuthorityGroup { get; set; }
        public virtual Modules Modules { get; set; }
        public virtual bool isDelete { get; set; }
        public virtual bool isUpdate { get; set; }
        public virtual bool isInsert { get; set; }
        public virtual bool IsSelect { get; set; }
    }
}
