using System.Net.NetworkInformation;

namespace PingService.Models
{
    public class PingResponse
    {
        public IPStatus IpStatus { get; set; }
        public string Details { get; set; }
    }
}