using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.Manager.AdminFactory
{
    //Abstract Factory
    public abstract class UserFactory
    {
        public abstract BusinessLayerResult<Users> GetUserFullList();
        public abstract BusinessLayerResult<Users> UserAdded(Users model);
        public abstract BusinessLayerResult<Users> UserReturnModelAdded(Users model);
        public abstract BusinessLayerResult<Users> FindUser(string userName, string password);
        public abstract BusinessLayerResult<Users> FindbyId(int id);
    }
}