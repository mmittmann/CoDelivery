using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoDelivery.Api.Models;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Api.Controllers
{
    public class DropboxController : ApiController
    {
        private DropBoxClient _dropBoxClient;

        public DropboxController()
        {
            _dropBoxClient = new DropBoxClient();
        }

        public IHttpActionResult TestIntegration(string username)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
