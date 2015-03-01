using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DropNet;
using DropNet.Models;
using Microsoft.Ajax.Utilities;

namespace CoDelivery.Core.Infra.Clients
{
    public class DropBoxClient
    {
        private DropNetClient _dropBoxClient;
        private static string _apiToken = "nf09bmb4l99w4y1", _appSecret = "utm9gqplqdzvezy";

        public string AccessToken { get; set; }
        public string ApiSecret { get; set; }

        public DropBoxClient()
        {
            _dropBoxClient = new DropNetClient(_apiToken, _appSecret);
        }

        public DropBoxClient(string accessToken, string userSecret)
        {
            _dropBoxClient = new DropNetClient(_apiToken, _appSecret, accessToken, userSecret, null);

        }

        public string GetUrlToRequestToken()
        {
            return _dropBoxClient.GetTokenAndBuildUrl();
        }

        public void GetAccessToken()
        {
            var userLogin = _dropBoxClient.GetAccessToken();
            AccessToken = userLogin.Token;
            ApiSecret = userLogin.Secret;
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
    }
}