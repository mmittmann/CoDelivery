using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using CoDelivery.Core.CoreModels;
using DropNet;

namespace CoDelivery.Core.Infra.Clients
{
    public class DropBoxClient
    {
        private DropNetClient _dropBoxClient;

        private static string
            _apiToken = "nf09bmb4l99w4y1",
            _appSecret = "utm9gqplqdzvezy";

        public string ApiSecret { get; set; }
        public string AccessToken { get; set; }

        public DropBoxClient()
        {
            _dropBoxClient = new DropNetClient(_apiToken, _appSecret);
        }

        public DropBoxClient(string userSecret, string accessToken)
        {
            _dropBoxClient = new DropNetClient(_apiToken, _appSecret, accessToken, userSecret, null);

        }

        public string GetUrlToRequestToken(string urlToCallback)
        {
            return _dropBoxClient.GetTokenAndBuildUrl(urlToCallback);
        }

        public void GetAccessToken()
        {
            var userLogin = _dropBoxClient.GetAccessToken();
            ApiSecret = userLogin.Secret;
            AccessToken = userLogin.Token;
        }

        public bool IsConnected()
        {
            try
            {
                var accountInfo = _dropBoxClient.AccountInfo();
                return accountInfo.uid > 0;
            }
            catch
            {
                return false;
            }
        }

        public byte[] GetFile(string path)
        {
            return _dropBoxClient.GetFile(path);
        }

        public List<string> GetFolderContent(string path)
        {
            var metaData = _dropBoxClient.GetMetaData(path);
            var content = metaData.Contents;

            return content.Where(data => data.Is_Dir).Select(data => data.Path).ToList();
        }

        public Information GetInformation()
        {
            var information = _dropBoxClient.AccountInfo();

            return new Information
            {
                Name = information.display_name,
                Email = information.email
            };
        }
    }
}