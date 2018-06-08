using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Manager;
using IQSELFHOSTAPI.Company.Entities;
using IQSELFHOSTAPI.Helpers;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Test.Hubs
{
    public class EchoposModelHub : Hub
    {
        static ConcurrentDictionary<string, Users> dic = new ConcurrentDictionary<string, Users>();
        public override Task OnConnected()
        {
            Console.WriteLine("SignalR OnConnected");
            return base.OnConnected();
        }

        public void Connect(Users user)
        {
            int Count = dic.Where(w => w.Value.UserFullName == user.UserFullName).Count();
            if (Count > 0)
            {
                var Deletesender = dic.SingleOrDefault(u => u.Value.UserFullName == user.UserFullName);

                Users s = new Users();
                dic.TryRemove(Deletesender.Key, out s);
                Authenticator.Constants.Dic.TryRemove(Deletesender.Key, out s);
                Console.WriteLine(user.UserFullName + " - Silindi... Aşağıda Aktif olacak.");
            }

            dic.TryAdd(Context.ConnectionId, user);
            Authenticator.Constants.Dic.TryAdd(Context.ConnectionId, user);
            Clients.All.updateUsers(dic.Count(), dic.Select(s => s.Value));

            Console.WriteLine(user.UserFullName + " - Aktif Oldu");
            Console.WriteLine("Toplam Kullanıcı Sayısı : " + (dic.Count()));
        }

        public async Task ClientKill(Users user, string process)
        {
            int Count = dic.Where(w => w.Value.UserFullName == user.UserFullName).Count();
            if (Count > 0)
            {
                BusinessLayerResult<UserToken> resultClearToken = await UserTokenClear(user);
                if (resultClearToken.Result)
                {
                    var sender = dic.FirstOrDefault(u => u.Value.UserFullName == user.UserFullName);
                    Clients.Client(sender.Key).ClientKillReceived(process);
                }
            }
        }

        public async Task ClientDivDataRefresh(Users user, List<DashboardPanel> DivId)
        {
            int Count = dic.Where(w => w.Value.UserFullName == user.UserFullName).Count();
            if (Count > 0)
            {
                var sender = dic.FirstOrDefault(u => u.Value.UserFullName == user.UserFullName);
                Clients.Client(sender.Key).ClientDivDataRefreshReceived(DivId);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Users s = new Users();

            dic.TryRemove(Context.ConnectionId, out s);
            Authenticator.Constants.Dic.TryRemove(Context.ConnectionId, out s);
            Clients.All.updateUsers(dic.Count(), dic.Select(u => u.Value));

            Clients.All.disconnectedUpdate(s);
            Console.WriteLine(Context.ConnectionId + " - " + s.UserFullName + " -  Kullanıcı Çevrimdışı oldu.");
            Console.WriteLine("Toplam Kullanıcı Sayısı : " + (dic.Count()));
            return base.OnDisconnected(stopCalled);
        }

        public async Task<BusinessLayerResult<UserToken>> UserTokenClear(Users user)
        {
            ConnectionHelper helper = new Helpers.ConnectionHelper
            {
                Database = DatabaseInfo.App.AdminDatabaseName,
                Password = DatabaseInfo.App.Password,
                Servername = DatabaseInfo.App.ServerName,
                Username = DatabaseInfo.App.Username
            };

            UserTokenProcess utp = UserTokenProcess.UserTokenProcessMultiton(helper);

            BusinessLayerResult<UserToken> userToken = utp.UserTokenFindFunction(user.TabloID, 1, 3);

            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();
            if (userToken.Result)
            {
                utp = UserTokenProcess.UserTokenProcessMultiton(helper);
                result = utp.UserTokenDeleteFunction(userToken.Objects.FirstOrDefault());
            }

            return result;
        }
    }
}