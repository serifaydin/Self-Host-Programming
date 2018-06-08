using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly RepositoryAdminBase<Companies> _repository;

        public CompanyService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<Companies>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<Companies> CompanyAdded(Companies model)
        {
            BusinessLayerResult<Companies> result = new BusinessLayerResult<Companies>();
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

        public BusinessLayerResult<Companies> CompanyFullList()
        {
            BusinessLayerResult<Companies> result = new BusinessLayerResult<Companies>();

            Exception ex = new Exception();
            List<Companies> list = new List<Companies>();
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
    }
}