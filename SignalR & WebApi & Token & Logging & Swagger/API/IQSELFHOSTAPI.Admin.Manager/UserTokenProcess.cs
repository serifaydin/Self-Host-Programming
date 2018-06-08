using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Admin.Manager
{
    public class UserTokenProcess
    {
        static Dictionary<string, UserTokenProcess> _userTokenProcess = new Dictionary<string, UserTokenProcess>();
        static object _lockObject = new object();
        private UserTokenProcess() { }

        static UserTokenManager userTokenManager;

        public static UserTokenProcess UserTokenProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_userTokenProcess.ContainsKey(connectionHelper.Database))
                {
                    _userTokenProcess.Add(connectionHelper.Database, new UserTokenProcess());
                }
            }

            userTokenManager = new UserTokenManager(new UserTokenServiceManager(connectionHelper));

            return _userTokenProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<UserToken> UserTokenDeleteFunction(UserToken model)
        {
            return userTokenManager.UserTokenDelete(model);
        }

        public BusinessLayerResult<UserToken> UserTokenFindFunction(int userId,int appId,int companyId)
        {
            return userTokenManager.UserTokenFind(userId, appId,companyId);
        }

        public BusinessLayerResult<UserToken> UserTokenFindFunction(string token)
        {
            return userTokenManager.UserTokenFind(token);
        }

        public BusinessLayerResult<UserToken> UserTokenInsertFunction(UserToken token)
        {
            return userTokenManager.UserTokenAdd(token);
        }

        public BusinessLayerResult<UserToken> UserTokenUpdateFunction(UserToken token)
        {
            return userTokenManager.UserTokenUpdate(token);
        }
    }
}
