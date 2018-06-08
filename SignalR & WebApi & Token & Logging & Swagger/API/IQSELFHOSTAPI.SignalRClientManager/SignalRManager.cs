using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Company.Entities;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.SignalRClientManager
{
    public class SignalRManager
    {
        private HubConnection Connection;
        private IHubProxy ChatHubProxy;

        //Online veya Offline durumu kontrol eden Event
        public delegate void OnlineUserUpdate(string KisiSayisi, List<Users> Kisiler);
        public event OnlineUserUpdate OnlineUserUpdated;
        //---------------------------------------------------------------------------------

        //Client ın Kill edilebilmesi için gerekli Event
        public delegate void ClientKillReceived(string process);
        public event ClientKillReceived clientKillReceived;
        //---------------------------------------------------------------------------------

        //Client içerisindeki Div lerin Refresh edilebilmesi için gerekli event
        public delegate void ClientDivRefreshReceived(List<DashboardPanel> DivIDs);
        public event ClientDivRefreshReceived clientDivRefreshReceived;
        //---------------------------------------------------------------------------------

        public SignalRManager(string url)
        {
            Connection = new HubConnection(url);

            ChatHubProxy = Connection.CreateHubProxy("echoposModelHub");

            //Online olan Kişilerin anlık olarak listelenmesi
            ChatHubProxy.On<int, List<Users>>("updateUsers", (userCount, userList) =>
            {
                string OnlineKisiSayisi = "Toplam Kişi Sayısı : " + userCount;

                OnlineUserUpdated?.Invoke(OnlineKisiSayisi, userList);
            });
            //-----------------------------------------------------------------------------------

            //Kill Process
            ChatHubProxy.On<string>("ClientKillReceived", (process) =>
            {
                clientKillReceived?.Invoke(process);
            });
            //-----------------------------------------------------------------------------------

            //Client Div Refresh Process
            ChatHubProxy.On<List<DashboardPanel>>("ClientDivDataRefreshReceived", (DivIDs) =>
            {
                clientDivRefreshReceived?.Invoke(DivIDs);
            });
            //-----------------------------------------------------------------------------------
        }

        public async Task ConnectionStart(Users user)
        {
            try
            {
                await Connection.Start();
                await ChatHubProxy.Invoke("connect", user);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                //System.Windows.Forms.MessageBox.Show("Test");
            }
            catch (AggregateException ex1)
            {
                var y = ex1;
            }
            catch (Exception ex1)
            {
                var y = ex1;
            }
        }

        public void ClientKill(Users user, string process)
        {
            ChatHubProxy.Invoke("ClientKill", user, process);
        }

        public void ClientDivDataRefresh(Users user, List<DashboardPanel> DivIDs)
        {
            ChatHubProxy.Invoke("ClientDivDataRefresh", user, DivIDs);
        }

        public void ConnectionStop()
        {
            Connection.Stop();
        }

        public bool IsConnectedOrConnecting
        {
            get
            {
                return Connection.State != (ConnectionState.Disconnected);
            }
        }

        public ConnectionState ConnectionState { get { return Connection.State; } }
    }
}