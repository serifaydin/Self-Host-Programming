using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    public class UserTokenManager
    {
        private UserTokenFactory _userTokenManager;

        public UserTokenManager(UserTokenFactory userTokenFactory)
        {
            _userTokenManager = userTokenFactory;
        }

        public BusinessLayerResult<UserToken> UserTokenDelete(UserToken model)
        {
            return _userTokenManager.RemoveToken(model);
        }

        public BusinessLayerResult<UserToken> UserTokenFind(int userId,int appId,int companyId)
        {
            return _userTokenManager.FindToken(userId, appId,companyId);
        }

        public BusinessLayerResult<UserToken> UserTokenFind(string token)
        {
            return _userTokenManager.FindToken(token);
        }

        public BusinessLayerResult<UserToken> UserTokenAdd(UserToken token)
        {
            return _userTokenManager.AddToken(token);
        }

        public BusinessLayerResult<UserToken> UserTokenUpdate(UserToken token)
        {
            return _userTokenManager.UpdateToken(token);
        }
    }
}
