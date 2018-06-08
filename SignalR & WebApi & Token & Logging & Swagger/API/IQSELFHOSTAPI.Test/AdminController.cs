using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager;
using IQSELFHOSTAPI.Helpers;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;
using DatabaseInfo;

namespace IQSELFHOSTAPI.Test
{
    [Authenticator.EchoAuth]
    public class AdminController : ApiController
    {
        UserProcess userProcess;
        CompanyProcess companyProcess;
        AuthorityGroupProcess authorityGroupProcess;
        CompanyUserProcess companyUserProcess;
        ModulesProcess modulesProcess;
        public AdminController()
        {
            ConnectionHelper _conHelper = new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.AdminDatabaseName };

            //ConnectionHelper _conHelper = new ConnectionHelper { Servername = "DESKTOP-NDB4SQT", Username = "sa", Password = "123", Database = "BackOfficeAdminDB" };

            userProcess = UserProcess.UserProcessMultiton(_conHelper);
            companyProcess = CompanyProcess.CompanyProcessMultiton(_conHelper);
            authorityGroupProcess = AuthorityGroupProcess.AuthorityProcessMultiton(_conHelper);
            companyUserProcess = CompanyUserProcess.CompanyUserProcessMultiton(_conHelper);
            modulesProcess = ModulesProcess.ModuleProcessMultiton(_conHelper);
        }

        [HttpGet]
        public BusinessLayerResult<AuthorityGroup> GetAuthorityModel(int id)
        {
            return authorityGroupProcess.GetAuthorityModel(id);
        }

        [HttpGet]
        public BusinessLayerResult<Users> GetFullUsers()
        {
            return userProcess.GetFullUserList();
        }

        [HttpPost]
        public BusinessLayerResult<Users> UserAdded(Users model)
        {
            return userProcess.UserInserFunction(model);
        }

        [HttpPost]
        public BusinessLayerResult<Users> UserReturnModelAdded(Users model)
        {
            return userProcess.UserReturnModelInserFunction(model);
        }

        [HttpGet]
        public BusinessLayerResult<object> ConnectionDatabaseStatus()
        {
            ConnectionADO connAdo = ConnectionADO.createAsSingleton();
            return connAdo.ConnectionStatus(App.ServerName, App.Username, App.Password);
        }

        [HttpGet]
        public BusinessLayerResult<Companies> GetFullCompanies()
        {
            return companyProcess.GetFullCompanyList();
        }

        [HttpPost]
        public BusinessLayerResult<Companies> CompanyAdded(Companies model)
        {
            return companyProcess.CompanyInserFunction(model);
        }

        [HttpGet]
        public BusinessLayerResult<AuthorityGroup> GetFullAuthorityGroup()
        {
            return authorityGroupProcess.GetAuthorityList();
        }

        [HttpPost]
        public BusinessLayerResult<CompanyApplicationUser> CompanyUserAdded(CompanyApplicationUser model)
        {
            return companyUserProcess.CompanyUserInserFunction(model);
        }

        [HttpGet]
        public BusinessLayerResult<Modules> GetFullModulesList()
        {
            return modulesProcess.GetFullModuleList();
        }
    }
}