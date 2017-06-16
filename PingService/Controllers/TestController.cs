using System;
using System.Net.NetworkInformation;
using System.Web.Http;
using PingService.Models;

namespace PingService.Controllers
{
    public class TestController : ApiController
    {
        private static PingResponse PingHost(string nameOrAddress)
        {
            PingResponse pingResponse = new PingResponse();
            try
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingResponse.IpStatus = reply.Status;
                pingResponse.Details = "OK";
                return pingResponse;
            }
            catch (Exception e)
            {
                pingResponse.Details = e.ToString();
                return pingResponse;
            }
        }


        // GET: api/Test
        public PingResponse Get(string id)
        {
            return PingHost(id);
        }
    }
}
