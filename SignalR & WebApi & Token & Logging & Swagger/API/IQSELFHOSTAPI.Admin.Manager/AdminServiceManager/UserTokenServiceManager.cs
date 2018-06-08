using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;
using System;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class UserTokenServiceManager : UserTokenFactory
    {
        UserTokenService tokenService;

        public UserTokenServiceManager(ConnectionHelper connectionHelper)
        {
            tokenService = new UserTokenService(connectionHelper);
        }

        public override BusinessLayerResult<UserToken> AddToken(UserToken token)
        {
            return tokenService.AddToken(token);
        }

        public override BusinessLayerResult<UserToken> FindToken(int userId, int appId,int companyId)
        {
            return tokenService.FindToken(userId, appId,companyId);
        }

        public override BusinessLayerResult<UserToken> FindToken(string token)
        {
            return tokenService.FindToken(token);
        }

        public override BusinessLayerResult<UserToken> RemoveToken(UserToken token)
        {
            return tokenService.RemoveToken(token);
        }

        public override BusinessLayerResult<UserToken> UpdateToken(UserToken token)
        {
            return tokenService.UpdateToken(token);
        }
    }
}
