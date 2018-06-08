using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface IUserTokenService
    {
        BusinessLayerResult<UserToken> FindToken(int userId, int appId, int companyId);
        BusinessLayerResult<UserToken> AddToken(UserToken token);
        BusinessLayerResult<UserToken> FindToken(string token);
        BusinessLayerResult<UserToken> RemoveToken(UserToken token);
        BusinessLayerResult<UserToken> UpdateToken(UserToken token);
    }
}
