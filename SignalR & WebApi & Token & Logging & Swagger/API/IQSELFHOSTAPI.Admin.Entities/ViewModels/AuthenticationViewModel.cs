using System;

namespace IQSELFHOSTAPI.Admin.Entities.ViewModels
{
    public class AuthenticationViewModel
    {
        public OAuthModel AuthenticationModel { get; set; }
        public ErrorViewModel ErrorModel { get; set; }
    }

    public class OAuthModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public int AppId { get; set; }
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
    }
}
