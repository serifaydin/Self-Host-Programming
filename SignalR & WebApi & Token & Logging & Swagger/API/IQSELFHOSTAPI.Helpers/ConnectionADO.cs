using System.Data.SqlClient;

namespace IQSELFHOSTAPI.Helpers
{
    public class ConnectionADO
    {
        private static ConnectionADO _connectionAdo;
        static object _lockObject = new object();

        private ConnectionADO() { }

        public static ConnectionADO createAsSingleton()
        {
            lock (_lockObject)
                return _connectionAdo ?? (_connectionAdo = new ConnectionADO());
        }

        public BusinessLayerResult<object> ConnectionStatus(string Servername, string userName, string Password)
        {
            BusinessLayerResult<object> _layerResult = new BusinessLayerResult<object>();
            _layerResult.Result = true;

            string connString = "server=" + Servername + "; uid=" + userName + "; pwd=" + Password + "; database=BackOfficeAdminDB";

            string DatabaseName = "BackOfficeAdminDB";

            string cmdText = "select * from master.dbo.sysdatabases where name=\'" + DatabaseName + "\'";

            _layerResult.Object = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection);
                    SqlDataReader dr = sqlCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        _layerResult.Object = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                _layerResult.Result = false;
                _layerResult.AddError(Messages.ErrorMessageCode.TryCatchMessage, ex.Message);
            }

            return _layerResult;
        }
    }
}