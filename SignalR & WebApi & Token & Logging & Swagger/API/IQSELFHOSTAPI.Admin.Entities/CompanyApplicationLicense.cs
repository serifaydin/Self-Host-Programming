namespace IQSELFHOSTAPI.Admin.Entities
{
    public class CompanyApplicationLicense
    {
        public virtual int TabloID { get; set; }
        public virtual Companies Companies { get; set; }
        public virtual Application Application { get; set; }
        public virtual string ApplicationLicenseSize { get; set; }
    }
}