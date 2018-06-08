using IQSELFHOSTAPI.Admin.Entities;
using System;
using System.Collections.Concurrent;

namespace IQSELFHOSTAPI.Authenticator
{
    public class Constants
    {
        public static readonly TimeSpan ExpireDays = TimeSpan.FromDays(1);
        public static ConcurrentDictionary<string, Users> Dic { get; } = new ConcurrentDictionary<string, Users>();
    }
}
