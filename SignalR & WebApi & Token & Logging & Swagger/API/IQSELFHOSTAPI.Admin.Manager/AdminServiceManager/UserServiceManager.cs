using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminServiceManager
{
    public class UserServiceManager : UserFactory
    {
        UserService uService;
        public UserServiceManager(ConnectionHelper connectionHelper)
        {
            uService = new UserService(connectionHelper);
        }

        public override BusinessLayerResult<Users> FindbyId(int id)
        {
            return uService.FindbyId(id);
        }

        public override BusinessLayerResult<Users> FindUser(string userName, string password)
        {
            return uService.FindUser(userName, password);
        }

        public override BusinessLayerResult<Users> GetUserFullList()
        {
            return uService.UserFullList();
        }

        public override BusinessLayerResult<Users> UserAdded(Users model)
        {
            return uService.UserAdded(model);
        }

        public override BusinessLayerResult<Users> UserReturnModelAdded(Users model)
        {
            return uService.UserReturnModelAdded(model);
        }
    }
}