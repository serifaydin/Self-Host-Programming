using Microsoft.Owin.Hosting;
using System;
using System.ServiceProcess;

namespace IQSELFHOSTAPI.BackOfficeAPI
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8090"))
            {
                Console.WriteLine("Web Server is running");
                Console.ReadKey();
            }
        }

        protected override void OnStop()
        {
        }
    }
}