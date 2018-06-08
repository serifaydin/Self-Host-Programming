using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    public abstract class UserTokenFactory
    {
        public abstract BusinessLayerResult<UserToken> RemoveToken(UserToken token);
        public abstract BusinessLayerResult<UserToken> FindToken(int userId, int appId, int companyId);
        public abstract BusinessLayerResult<UserToken> FindToken(string token);
        public abstract BusinessLayerResult<UserToken> AddToken(UserToken token);
        public abstract BusinessLayerResult<UserToken> UpdateToken(UserToken token);
    }
}
