using System;

namespace IQSELFHOSTAPI.Admin.Entities
{
    public class UserToken : EntityBase
    {
        public virtual Companies Company { get; set; }
        public virtual Application Application { get; set; }
        public virtual Users User { get; set; }
        public virtual string AccessToken { get; set; }
        public virtual DateTime ExpireDate { get; set; }
    }
}
