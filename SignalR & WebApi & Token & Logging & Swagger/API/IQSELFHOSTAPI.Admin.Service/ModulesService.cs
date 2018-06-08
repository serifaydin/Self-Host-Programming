using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Admin.Service
{
    public class ModulesService : IModulesService
    {
        private readonly RepositoryAdminBase<Modules> _repository;

        public ModulesService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<Modules>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }
        public BusinessLayerResult<Modules> GetListModules()
        {
            BusinessLayerResult<Modules> result = new BusinessLayerResult<Modules>();

            Exception ex = new Exception();
            List<Modules> list = new List<Modules>();
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