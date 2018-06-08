using DatabaseInfo;
using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Company.Manager;
using IQSELFHOSTAPI.Helpers;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Timers;

namespace IQSELFHOSTAPI.Test.Hubs
{
    public class WebPortalReportHub : Hub
    {
        static ConcurrentDictionary<string, Users> dic = new ConcurrentDictionary<string, Users>();
        private static BusinessLayerResult<DashboardPanel> dashboardResult;

        public WebPortalReportHub()
        {
            DashboardPanelProcess dashboardProcess = DashboardPanelProcess.DashboardPanelProcessMultiton(
                new Helpers.ConnectionHelper
                {
                    Servername = App.ServerName,
                    Database = App.CompanyDatabaseName,
                    Username = App.Username,
                    Password = App.Password
                });

            dashboardResult = dashboardProcess.GetFullDashboardPanelList();
            StartTimer();
        }

        public void Connect(Users user)
        {
            int Count = dic.Where(w => w.Value.UserFullName == user.UserFullName).Count();
            if (Count > 0)
            {
                var Deletesender = dic.SingleOrDefault(u => u.Value.UserFullName == user.UserFullName);
                Users s = new Users();

                dic.TryRemove(Deletesender.Key, out s);
            }

            dic.TryAdd(Context.ConnectionId, user);
        }

        private Timer _timer;
        private void StartTimer()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }
        private void OnTimerElapsed(Object source, ElapsedEventArgs e)
        {
            Clients.All.divChanged(DateTime.Now);
        }
    }
}