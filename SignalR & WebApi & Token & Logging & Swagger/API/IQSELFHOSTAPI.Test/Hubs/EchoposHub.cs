using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Test.Hubs
{
    public class EchoposHub : Hub
    {
        static ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
        public override Task OnConnected()
        {
            Console.WriteLine("Toplam Kullanıcı Sayısı : " + (dic.Count() + 1));
            return base.OnConnected();
        }

        public void Connect(string username)
        {
            int Count = dic.Where(w => w.Value == username).Count();
            if (Count > 0)
            {
                var Deletesender = dic.First(u => u.Value.Equals(username));

                string s;
                dic.TryRemove(Deletesender.Key, out s);

                Console.WriteLine(username + " - Silindi... Aşağıda Aktif olacak.");
            }

            dic.TryAdd(Context.ConnectionId, username);
            Clients.All.updateUsers(dic.Count(), dic.Select(s => s.Value));

            Console.WriteLine(username + " - Aktif Oldu");
        }

        public void Send(string message)
        {
            var sender = dic.First(u => u.Key.Equals(Context.ConnectionId));
            Clients.All.broadcastMessage(sender.Value, message);
        }

        public void SendFile(string file)
        {
            var sender = dic.First(u => u.Key.Equals(Context.ConnectionId));
            Clients.All.broadcastMessage(sender.Value, "bir dosya gönderildi.");
        }

        public void SpesificMessage(string name, string message)
        {
            var senderMain = dic.First(u => u.Key.Equals(Context.ConnectionId));
            var sender = dic.First(u => u.Value.Equals(name));
            Clients.Client(sender.Key).broadcastMessage(senderMain.Value, message);
        }

        public void MultipleMessages(List<string> _Users, string message)
        {
            var senderMain = dic.First(f => f.Key.Equals(Context.ConnectionId));

            List<string> _connectionUsers = new List<string>();

            foreach (string item in _Users)
            {
                string _conID = dic.SingleOrDefault(s => s.Value == item).Key;
                _connectionUsers.Add(_conID);
            }

            Clients.Clients(_connectionUsers).broadcastMessage(senderMain.Value, message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string s;

            dic.TryRemove(Context.ConnectionId, out s);
            Clients.All.updateUsers(dic.Count(), dic.Select(u => u.Value));

            Clients.All.disconnectedUpdate(s);
            Console.WriteLine(Context.ConnectionId + " - " + s + " -  Kullanıcı Çevrimdışı oldu.");
            Console.WriteLine("Toplam Kullanıcı Sayısı : " + (dic.Count() - 1));
            return base.OnDisconnected(stopCalled);
        }
    }
}
