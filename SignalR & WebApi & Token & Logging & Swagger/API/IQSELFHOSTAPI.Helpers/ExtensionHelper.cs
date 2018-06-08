using System.Net.NetworkInformation;
using System.Linq;

namespace IQSELFHOSTAPI.Helpers
{
    public static class ExtensionHelper
    {
        public static string GetClientId(this object obj)
        {
            string result = string.Empty;
            result = NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault().Crypt();
            return result;
        }
    }
}
