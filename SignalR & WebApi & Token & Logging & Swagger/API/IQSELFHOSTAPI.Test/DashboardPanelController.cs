using DatabaseInfo;
using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager;
using IQSELFHOSTAPI.Helpers;
using System.Web.Http;

namespace IQSELFHOSTAPI.Test
{
    /// <summary>
    /// Dashboard ekranı dinamik Div ve sorgu oluşturma.
    /// </summary>
    [Authenticator.EchoAuth]
    public class DashboardPanelController : ApiController
    {
        DashboardPanelProcess process;

        /// <summary>
        /// Controller Constructor
        /// </summary>
        public DashboardPanelController()
        {
            ConnectionHelper _conHelper = new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.AdminDatabaseName };
            process = DashboardPanelProcess.DashboardPanelProcessMultiton(_conHelper);
        }

        /// <summary>
        /// Dashboard da bulunan Div lerin listelenmesi için gerekli tüm bilgileri alındığı methot.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public BusinessLayerResult<DashboardPanel> DashboardPanelList()
        {
            return process.GetFullDashboardPanelList();
        }

        /// <summary>
        /// Dashboard a yeni Div ve sorgu eklemek için kullanılan methot.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public BusinessLayerResult<DashboardPanel> DashboardPanelAdded(DashboardPanel model)
        {
            return process.DashboardPanelAdded(model);
        }
    }
}