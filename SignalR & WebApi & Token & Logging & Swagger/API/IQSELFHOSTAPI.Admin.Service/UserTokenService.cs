using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class UserTokenService : IUserTokenService
    {
        private readonly RepositoryAdminBase<UserToken> _repository;
        public UserTokenService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<UserToken>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<UserToken> AddToken(UserToken token)
        {
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();
            result.Result = true;

            Exception ex = new Exception();
            bool insertResult = _repository.Insert(token, ref ex);

            if (!insertResult)
            {
                result.Result = insertResult;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            return result;
        }

        public BusinessLayerResult<UserToken> FindToken(int userId, int appId,int companyId)
        {
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();

            Exception ex = new Exception();
            List<UserToken> list = new List<UserToken>();



            bool resultState = _repository.GetList(x=>x.Application.TabloID == appId && x.User.TabloID == userId && x.Company.TabloID == companyId ,ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Objects = list;
            return result;
        }

        public BusinessLayerResult<UserToken> FindToken(string token)
        {
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();

            Exception ex = new Exception();
            List<UserToken> list = new List<UserToken>();
            bool resultState = _repository.GetList(x => x.AccessToken == token, ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Objects = list;
            return result;
        }

        public BusinessLayerResult<UserToken> RemoveToken(UserToken token)
        {
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();
            result.Result = true;

            Exception ex = new Exception();
            bool deleteResult = _repository.Delete(token, ref ex);

            if (!deleteResult)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = deleteResult;
            return result;
        }

        public BusinessLayerResult<UserToken> UpdateToken(UserToken token)
        {
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();
            result.Result = true;

            Exception ex = new Exception();
            bool updateResult = _repository.Update(token, ref ex);

            if (!updateResult)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = updateResult;
            return result;
        }
    }
}
