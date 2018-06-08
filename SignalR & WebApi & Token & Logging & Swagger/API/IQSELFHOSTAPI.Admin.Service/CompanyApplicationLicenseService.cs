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
    public class CompanyApplicationLicenseService : ICompanyApplicationLicenseService
    {
        private readonly RepositoryAdminBase<CompanyApplicationLicense> _repository;
        public CompanyApplicationLicenseService(ConnectionHelper connectionHelper)
        {
            _repository = new RepositoryAdminBase<CompanyApplicationLicense>(connectionHelper.Servername, connectionHelper.Username, connectionHelper.Password, connectionHelper.Database);
        }

        public BusinessLayerResult<CompanyApplicationLicense> AddLicense(CompanyApplicationLicense model)
        {
            BusinessLayerResult<CompanyApplicationLicense> result = new BusinessLayerResult<CompanyApplicationLicense>();
            result.Result = true;

            Exception ex = new Exception();
            model.ApplicationLicenseSize = model.ApplicationLicenseSize.Crypt();
            bool insertResult = _repository.Insert(model, ref ex);

            if (!insertResult)
            {
                result.Result = insertResult;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            return result;
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseByCompanyApplication(int companyId, int applicationId)
        {
            BusinessLayerResult<CompanyApplicationLicense> result = new BusinessLayerResult<CompanyApplicationLicense>();

            Exception ex = new Exception();
            List<CompanyApplicationLicense> list = new List<CompanyApplicationLicense>();
            bool resultState = _repository.GetList(x => x.Companies.TabloID == companyId && x.Application.TabloID == applicationId, ref list, ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Object = list.FirstOrDefault();
            return result;
        }

        public BusinessLayerResult<CompanyApplicationLicense> FindLicenseById(int id)
        {
            BusinessLayerResult<CompanyApplicationLicense> result = new BusinessLayerResult<CompanyApplicationLicense>();

            Exception ex = new Exception();
            CompanyApplicationLicense license = new CompanyApplicationLicense();
            bool resultState = _repository.GetById(id,ref license,ref ex);

            result.Result = resultState;

            if (!resultState)
            {
                result.Result = resultState;
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            result.Object = license;
            return result;
        }

        public BusinessLayerResult<CompanyApplicationLicense> GetAllLicenses()
        {
            BusinessLayerResult<CompanyApplicationLicense> result = new BusinessLayerResult<CompanyApplicationLicense>();

            Exception ex = new Exception();
            List<CompanyApplicationLicense> list = new List<CompanyApplicationLicense>();
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

        public BusinessLayerResult<CompanyApplicationLicense> RemoveLicense(CompanyApplicationLicense model)
        {
            BusinessLayerResult<CompanyApplicationLicense> result = new BusinessLayerResult<CompanyApplicationLicense>();
            result.Result = true;

            Exception ex = new Exception();
            bool deleteResult = _repository.Delete(model, ref ex);

            if (!deleteResult)
                result.AddError(ErrorMessageCode.TryCatchMessage, ex.Message);

            result.Result = deleteResult;
            return result;
        }
    }
}
