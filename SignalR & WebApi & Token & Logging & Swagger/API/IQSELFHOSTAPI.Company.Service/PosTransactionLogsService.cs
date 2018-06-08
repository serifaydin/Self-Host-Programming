using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;

namespace IQSELFHOSTAPI.Company.Service
{
    public class PosTransactionLogsService : IPosTransactionLogsService
    {
        private readonly RepositoryCompanyBase<posTransactionLogs> _repository;
        public PosTransactionLogsService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryCompanyBase<posTransactionLogs>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<posTransactionLogs> TransactionLogInsert(posTransactionLogs model)
        {
            BusinessLayerResult<posTransactionLogs> result = new BusinessLayerResult<posTransactionLogs>();
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