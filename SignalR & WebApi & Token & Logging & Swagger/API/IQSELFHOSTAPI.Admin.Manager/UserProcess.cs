using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminManager;
using IQSELFHOSTAPI.Admin.Manager.AdminServiceManager;
using IQSELFHOSTAPI.Helpers;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Manager
{
    //Multiton and DI
    public class UserProcess
    {
        static Dictionary<string, UserProcess> _userProcess = new Dictionary<string, UserProcess>();
        static object _lockObject = new object();
        private UserProcess() { }

        static UserManager userManager;

        public static UserProcess UserProcessMultiton(ConnectionHelper connectionHelper)
        {
            lock (_lockObject)
            {
                if (!_userProcess.ContainsKey(connectionHelper.Database))
                {
                    _userProcess.Add(connectionHelper.Database, new UserProcess());
                }
            }

            userManager = new UserManager(new UserServiceManager(connectionHelper));

            return _userProcess[connectionHelper.Database];
        }

        public BusinessLayerResult<Users> GetFullUserList()
        {
            return userManager.GetFullUsers();
        }

        public BusinessLayerResult<Users> UserInserFunction(Users model)
        {
            return userManager.UserInsert(model);
        }

        public BusinessLayerResult<Users> UserReturnModelInserFunction(Users model)
        {
            return userManager.UserReturnModelInsert(model);
        }

        public BusinessLayerResult<Users> UserFindFunction(string userName,string password)
        {
            return userManager.UserFind(userName, password);
        }

        public BusinessLayerResult<Users> UserFindByIdFunction(int id)
        {
            return userManager.UserFindById(id);
        }
    }
}