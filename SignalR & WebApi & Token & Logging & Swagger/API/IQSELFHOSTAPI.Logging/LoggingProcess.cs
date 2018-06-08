using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.EnumBase;
using IQSELFHOSTAPI.Helpers.Messages;
using System;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Logging
{
    public class LoggingProcess
    {
        ConnectionHelper conHelper;

        public LoggingProcess(ConnectionHelper _conHelper)
        {
            conHelper = _conHelper;
        }

        public async Task TransactionLogAdded(string functionName,
            ErrorMessageCode errorCode,
            ProjectNames projectName,
            ApplicationType appType, DateTime _time,
            string errorText,
            int userid = 0, int Moduleid = 0)
        {

            PosTransactionLogsProcess transactionLogManager = PosTransactionLogsProcess.PosTransactionLogProcessMultiton(conHelper);

            posTransactionLogs tranLog = new posTransactionLogs
            {
                UserID = userid,
                ModuleID = Moduleid,
                ProjectName = projectName,
                AppType = appType,
                CreatedDate = _time,
                ErrorMessageCode = errorCode,
                ErrorText = "{" + functionName + " }" + " { " + errorText + " }"
            };
            transactionLogManager.posTransactionLogInsert(tranLog);
        }

        public async Task ApplicationLogAdded(string functionName,
            ErrorMessageCode errorCode,
            ProjectNames projectName,
            ApplicationType appType, DateTime _time,
            string errorText,
            int userid = 0, int Moduleid = 0)
        {

            PosApplicationLogsProcess applicationLogManager = PosApplicationLogsProcess.PosApplicationLogProcessMultiton(conHelper);

            posApplicationLogs appLog = new posApplicationLogs
            {
                UserID = userid,
                ModuleID = Moduleid,
                ProjectName = projectName,
                AppType = appType,
                CreatedDate = _time,
                ErrorMessageCode = errorCode,
                ErrorText = "{" + functionName + " }" + " { " + errorText + " }"
            };
            applicationLogManager.posApplicationLogInsert(appLog);
        }
    }
}
