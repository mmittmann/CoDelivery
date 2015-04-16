using System.Threading.Tasks;
using System.Web.Http;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Api.Controllers
{
    public class DropboxController : ApiController
    {
        private readonly DropBoxClient _dropBoxClient;

        public DropboxController()
        {
            _dropBoxClient = new DropBoxClient();
        }

        public IHttpActionResult Get()
        {
            if (_dropBoxClient.IsConnected())
                return Ok(new { Url = "", IsConnected = true });

            return Ok(new { Url = _dropBoxClient.GetUrlToRequestToken(""), IsConnected = false });
        }
    }
}
