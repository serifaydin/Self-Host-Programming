using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.BackOfficeAPI.JsonManager;
using IQSELFHOSTAPI.Helpers;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.WFAManager.Services
{
    public class AdminService
    {
        AdminJsonService service;

        public AdminService()
        {
            service = new AdminJsonService();
        }

        //Companies
        public async Task<BusinessLayerResult<Companies>> GetCompanyList()
        {
            return await service.CompanyJsonList();
        }

        public async Task<BusinessLayerResult<Companies>> CompanyInsert(Companies model)
        {
            return await service.CompanyJsonInsert(model);
        }

        //User

        public async Task<BusinessLayerResult<Users>> GetUserList()
        {
            return await service.UserJsonList();
        }

        public async Task<BusinessLayerResult<Users>> UserInsert(Users model)
        {
            return await service.UserJsonInsert(model);
        }

        public async Task<BusinessLayerResult<Users>> UserReturnModelInsert(Users model)
        {
            return await service.UserReturnModelJsonInsert(model);
        }


        //AuthorityGroup
        public async Task<BusinessLayerResult<AuthorityGroup>> AuthorityGroupModel(int id)
        {
            return await service.AuthorityGroupJsonModel(id);
        }

        public async Task<BusinessLayerResult<AuthorityGroup>> AuthorityGroupList()
        {
            return await service.AuthorityGroupJsonList();
        }


        //CompanyUser
        public async Task<BusinessLayerResult<CompanyApplicationUser>> CompanyUserAdded(CompanyApplicationUser model)
        {
            return await service.CompanyUserJsonInsert(model);
        }
    }
}