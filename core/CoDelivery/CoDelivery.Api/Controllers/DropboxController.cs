using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoDelivery.Api.Models;
using CoDelivery.Core.Infra.Clients;
using System.Threading.Tasks;

namespace CoDelivery.Api.Controllers
{
    public class DropboxController : ApiController
    {
        private DropBoxClient _dropBoxClient;

        public DropboxController()
        {
            _dropBoxClient = new DropBoxClient();
        }

        public async Task<IHttpActionResult> Get()
        {
            if (_dropBoxClient.IsConnected())
                return Ok(new { Url = "", IsConnected = true });

            return Ok(new { Url = _dropBoxClient.GetUrlToRequestToken(), IsConnected = false });
        }
    }
}
