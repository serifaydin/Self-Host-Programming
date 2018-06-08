using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.IService;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.Messages;
using IQSELFHOSTAPI.Repository;
using System;
using System.Collections.Generic;

namespace IQSELFHOSTAPI.Company.Service
{
    public class DashboardPanelService : IDashboardPanelService
    {
        private readonly RepositoryCompanyBase<DashboardPanel> _repository;
        public DashboardPanelService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryCompanyBase<DashboardPanel>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model)
        {
            BusinessLayerResult<DashboardPanel> result = new BusinessLayerResult<DashboardPanel>();

            Exception ex = new Exception();
            bool insertResult = _repository.Insert(model, ref ex);

            if (!insertResult)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = insertResult;
            return result;
        }

        public BusinessLayerResult<DashboardPanel> DashboardPanelList()
        {
            BusinessLayerResult<DashboardPanel> result = new BusinessLayerResult<DashboardPanel>();

            Exception ex = new Exception();
            List<DashboardPanel> list = new List<DashboardPanel>();
            bool resultState = _repository.GetList(x => x.IsActive == true, ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = resultState;
            result.Objects = list;
            return result;
        }
    }
}