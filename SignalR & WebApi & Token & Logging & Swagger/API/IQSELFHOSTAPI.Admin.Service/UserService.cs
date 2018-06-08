using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class UserService : IUserService
    {
        private readonly RepositoryAdminBase<Users> _repository;
        public UserService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<Users>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }
        public BusinessLayerResult<Users> UserAdded(Users model)
        {
            BusinessLayerResult<Users> result = new BusinessLayerResult<Users>();
            result.Result = true;

            Exception ex = new Exception();
            bool insertResult = _repository.Insert(model, ref ex);

            if (!insertResult)
            {
                result.Result = insertResult;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            return result;
        }
        public BusinessLayerResult<Users> UserFullList()
        {
            BusinessLayerResult<Users> result = new BusinessLayerResult<Users>();

            Exception ex = new Exception();
            List<Users> list = new List<Users>();
            bool resultState = _repository.GetList(ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Objects = list;
            return result;
        }
        public BusinessLayerResult<Users> FindUser(string userName,string password)
        {
            BusinessLayerResult<Users> result = new BusinessLayerResult<Users>();

            Exception ex = new Exception();
            List<Users> list = new List<Users>();
            bool resultState = _repository.GetList(u=> u.Username == userName && u.Password == password,ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Object = list.FirstOrDefault();
            return result;
        }
        public BusinessLayerResult<Users> UserReturnModelAdded(Users model)
        {
            BusinessLayerResult<Users> result = new BusinessLayerResult<Users>();
            result.Result = true;

            Users resultModel = new Users();
            Exception ex = new Exception();

            bool insertResult = _repository.ReturnModelInsert(model, ref resultModel, ref ex);

            return result;
        }
        public BusinessLayerResult<Users> FindbyId(int id)
        {
            BusinessLayerResult<Users> result = new BusinessLayerResult<Users>();

            Exception ex = new Exception();
            Users user = new Users();
            bool resultState = _repository.GetById(id,ref user,ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Object = user;
            return result;
        }
    }
}