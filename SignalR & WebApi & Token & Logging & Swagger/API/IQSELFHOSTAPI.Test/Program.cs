using Microsoft.Owin.Hosting;
using System;
using System.IO;

namespace IQSELFHOSTAPI.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiUri = "";

            using (TextReader reader = File.OpenText("port.txt"))
            {
                apiUri = reader.ReadLine();
            }

            using (WebApp.Start<Startup>(apiUri))
            {
                string mainMessage = "--------------------------------------------" + apiUri + " - WEB SERVER IS RUNNING";


                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(mainMessage);
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("--------------------------------------------SIGNALR SERVER IS RUNNING");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("...........");
                Console.WriteLine("........");
                Console.WriteLine(".....");
                Console.WriteLine("...");
                Console.WriteLine(".");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("########################################## *LOG LIST* #################################################");

                Console.ReadKey();
            }
        }
    }
}