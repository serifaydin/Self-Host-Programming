using System;

namespace IQSELFHOSTAPI.Helpers
{
    public static class ConsoleMessage
    {
        public static void ConsoleWrite(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
    }
}