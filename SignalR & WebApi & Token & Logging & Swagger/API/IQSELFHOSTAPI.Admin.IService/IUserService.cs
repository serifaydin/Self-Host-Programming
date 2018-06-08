using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Helpers;

namespace IQSELFHOSTAPI.Admin.IService
{
    public interface IUserService
    {
        BusinessLayerResult<Users> FindUser(string userName, string password);
        BusinessLayerResult<Users> FindbyId(int id);
        BusinessLayerResult<Users> UserAdded(Users model);
        BusinessLayerResult<Users> UserFullList();
        BusinessLayerResult<Users> UserReturnModelAdded(Users model);
    }
}
