using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Limilabs.FTP.Client;

namespace CoDelivery.Core.Infra.Clients
{
    public class FtpClient
    {
        private readonly Ftp _ftp;

        public FtpClient(string host, string user, string password, int port = 21)
        {
            _ftp = new Ftp();
            _ftp.Login(user, password);
            _ftp.Connect(host, port);
        }

        public List<string> GetFolders(string path)
        {
            var folders = new List<string>(); 
            var ftpList = _ftp.GetList(path);

            ftpList.ForEach(f =>
            {
                if (f.IsFolder)
                    folders.Add(f.Name);
            });

            return folders;
        }

    }
}
