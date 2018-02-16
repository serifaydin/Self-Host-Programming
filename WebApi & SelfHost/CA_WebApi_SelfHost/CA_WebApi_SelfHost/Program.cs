using Microsoft.Owin.Hosting;
using System;

namespace CA_WebApi_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup1>("http://localhost:8090"))
            {
                Console.WriteLine("Web Server is running");
                Console.ReadKey();
            }
        }
    }
}