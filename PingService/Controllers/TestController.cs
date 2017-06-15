using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;

namespace PingService.Controllers
{
    public class TestController : ApiController
    {
        private static IPStatus PingHost(string nameOrAddress)
        {
            try
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                return reply.Status;
            }
            catch (Exception e)
            {
                return IPStatus.DestinationHostUnreachable;
            } 
        }


        // GET: api/Test
        public IPStatus Get()
        {
            return PingHost("10.9.9.185");
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
