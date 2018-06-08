using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager.AdminFactory;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminManager
{
    //Dependency Injection
    public class UserManager
    {
        private UserFactory _userManager;

        public UserManager(UserFactory userFactory)
        {
            _userManager = userFactory;
        }

        public BusinessLayerResult<Users> GetFullUsers()
        {
            return _userManager.GetUserFullList();
        }

        public BusinessLayerResult<Users> UserInsert(Users model)
        {
            return _userManager.UserAdded(model);
        }

        public BusinessLayerResult<Users> UserReturnModelInsert(Users model)
        {
            return _userManager.UserReturnModelAdded(model);
        }

        public BusinessLayerResult<Users> UserFind(string userName,string password)
        {
            return _userManager.FindUser(userName, password);
        }
        public BusinessLayerResult<Users> UserFindById(int id)
        {
            return _userManager.FindbyId(id);
        }
    }
}