using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly RepositoryAdminBase<CompanyApplicationUser> _repository;
        public CompanyUserService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<CompanyApplicationUser>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }
        public BusinessLayerResult<CompanyApplicationUser> CompanyUserAdded(CompanyApplicationUser model)
        {
            BusinessLayerResult<CompanyApplicationUser> result = new BusinessLayerResult<CompanyApplicationUser>();
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

        public BusinessLayerResult<bool> FindUserInApp(int userId,int appId,int companyId)
        {
            BusinessLayerResult<bool> result = new BusinessLayerResult<bool>();
            result.Result = true;

            Exception ex = new Exception();
            List<CompanyApplicationUser> list = new List<CompanyApplicationUser>();

            bool insertResult = _repository.GetList(
                x=>
                x.Users.TabloID == userId 
                && x.Application.TabloID==appId
                && x.Companies.TabloID == companyId,ref list, ref ex);

            if (!insertResult)
            {
                result.Result = insertResult;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }
            result.Object = list.Count > 0;
            return result;
        }
    }
}