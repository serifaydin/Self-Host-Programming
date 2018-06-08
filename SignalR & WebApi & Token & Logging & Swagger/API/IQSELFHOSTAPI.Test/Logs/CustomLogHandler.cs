using DatabaseInfo;
using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Helpers.EnumBase;
using IQSELFHOSTAPI.Helpers.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Test.Logs
{
    public class CustomLogHandler : DelegatingHandler
    {
        ConnectionHelper _conHelper = new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.CompanyDatabaseName };
        LoggingProcess logProcess;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.ToString().Contains("swagger"))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var logMetadata = BuildRequestMetadata(request);
            //First Log Created

            logProcess = new LoggingProcess(_conHelper);

            await logProcess.TransactionLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod,
                ErrorMessageCode.Transaction, ProjectNames.Other, ApplicationType.Windows, logMetadata.RequestTimestamp, "İşlem Başladı...", 1, 1);
            //---------------

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                await logProcess.TransactionLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod,
                ErrorMessageCode.NotFound, ProjectNames.Other, ApplicationType.Windows, logMetadata.ResponseTimestamp, "Yanlış Adres bilgisi.", 1, 1);

                await logProcess.ApplicationLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod,
                ErrorMessageCode.NotFound, ProjectNames.Other, ApplicationType.Windows, logMetadata.ResponseTimestamp, "Yanlış Adres bilgisi.", 1, 1);
            }

            else
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                BusinessLayerResult res = JsonConvert.DeserializeObject<BusinessLayerResult>(jsonContent);
                logMetadata.Errors = res.Errors;
                logMetadata.Result = res.Result;

                logMetadata = BuildResponseMetadata(logMetadata, response);
                await SendToLog(logMetadata);
            }

            //Eng Log Created
            await logProcess.TransactionLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod,
                ErrorMessageCode.Transaction, ProjectNames.Other, ApplicationType.Windows, logMetadata.ResponseTimestamp, "İşlem Tamamlandı...", 1, 1);
            //---------------

            return response;
        }

        private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata log = new LogMetadata
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };
            return log;
        }

        private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            logMetadata.ResponseStatusCode = response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.Now;
            logMetadata.ResponseContentType = response.Content.Headers.ContentType.MediaType;
            return logMetadata;
        }

        private async Task<bool> SendToLog(LogMetadata logMetadata)
        {
            logProcess = new LoggingProcess(_conHelper);

            if (!logMetadata.Result && (logMetadata.Errors.Count > 0 | logMetadata.Errors != null))
            {
                foreach (ErrorMessageObj item in logMetadata.Errors)
                {
                    await logProcess.TransactionLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod + " " + logMetadata.ResponseStatusCode.ToString(),
                     item.Code, ProjectNames.Other, ApplicationType.Windows, logMetadata.ResponseTimestamp, item.Message, 1, 1);

                    await logProcess.ApplicationLogAdded(logMetadata.RequestUri + " " + logMetadata.RequestMethod + " " + logMetadata.ResponseStatusCode.ToString(),
                           item.Code, ProjectNames.Other, ApplicationType.Windows, logMetadata.ResponseTimestamp, item.Message, 1, 1);
                }
            }
            return true;
        }
    }

    public class LogMetadata
    {
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public DateTime ResponseTimestamp { get; set; }

        public bool Result { get; set; }
        public List<ErrorMessageObj> Errors { get; set; }
    }

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

    public class BusinessLayerResult
    {
        public bool Result { get; set; }
        public List<ErrorMessageObj> Errors { get; set; }
    }
}