using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;

namespace IQSELFHOSTAPI.Company.Service
{
    public class PosApplicationLogsService : IPosApplicationLogsService
    {
        private readonly RepositoryCompanyBase<posApplicationLogs> _repository;
        public PosApplicationLogsService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryCompanyBase<posApplicationLogs>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<posApplicationLogs> ApplicationLogInsert(posApplicationLogs model)
        {
            BusinessLayerResult<posApplicationLogs> result = new BusinessLayerResult<posApplicationLogs>();
            result.Result = true;

            Exception ex = new Exception();
            bool insertResult = _repository.Insert(model, ref ex);

            if (!insertResult)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = insertResult;
            return result;
        }
    }
}