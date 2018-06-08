using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class AuthorityGroupService : IAuthorityGroupService
    {
        private readonly RepositoryAdminBase<AuthorityGroup> _repository;

        public AuthorityGroupService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<AuthorityGroup>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }
        public BusinessLayerResult<AuthorityGroup> GetAuthorityById(int id)
        {
            BusinessLayerResult<AuthorityGroup> result = new BusinessLayerResult<AuthorityGroup>();
            result.Result = true;

            AuthorityGroup returnModel = new AuthorityGroup();
            Exception ex = new Exception();
            bool resultState = _repository.GetById(id, ref returnModel, ref ex);

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Object = returnModel;
            return result;
        }

        public BusinessLayerResult<AuthorityGroup> GetAuthorityGroupList()
        {
            BusinessLayerResult<AuthorityGroup> result = new BusinessLayerResult<AuthorityGroup>();

            Exception ex = new Exception();
            List<AuthorityGroup> list = new List<AuthorityGroup>();
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