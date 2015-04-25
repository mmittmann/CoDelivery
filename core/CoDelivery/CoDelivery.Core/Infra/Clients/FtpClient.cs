using Limilabs.FTP.Client;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace CoDelivery.Core.Infra.Clients
{
    public class FtpClient
    {
        private readonly Ftp _ftp;

        public FtpClient(string host, string user, string password, int port)
        {
            _ftp = new Ftp();
            _ftp.ConnectSSL(host, port);
            _ftp.Login(user, password);

        }

        private readonly List<string> _folders = new List<string>();


        public List<string> GetFolders(string path)
        {
            var ftpList = _ftp.GetList(path);

            ftpList.ForEach(f =>
            {
                if (f.IsFolder)
                {
                    var folderName = path + f.Name + "/";
                    _folders.Add(folderName);
                    GetFolders(folderName);
                }
            });
            return _folders;

        }
    }
}
