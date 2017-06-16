using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web.Http;
using PingService.Models;

namespace PingService.Controllers
{
    public class TestController : ApiController
    {
        private static PingResponse PingHost(string nameOrAddress, int port)
        {
            PingResponse pingResponse = new PingResponse();
            try
            {
                TcpClient client = new TcpClient(nameOrAddress, port);
                pingResponse.Details = "OK";
                pingResponse.IsConnected = client.Connected;
                return pingResponse;
            }
            catch (Exception e)
            {
                pingResponse.Details = e.ToString();
                pingResponse.IpStatus = IPStatus.DestinationHostUnreachable;
                return pingResponse;
            }
        }


        // GET: api/Test
        public PingResponse Get(string ip, int port)
        {
            return PingHost(ip, port);
        }
    }
}
