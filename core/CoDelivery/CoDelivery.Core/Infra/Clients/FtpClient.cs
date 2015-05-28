using System.Collections.Generic;
using Limilabs.FTP.Client;

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

        public List<string> GetFolders(string path)
        {
            var folderList = new List<string>();

            var ftpList = _ftp.GetList(path);

            ftpList.ForEach(f =>
            {
                if (f.IsFolder)
                {
                    var folderName = path + f.Name + "/";
                    folderList.Add(folderName);
                    GetFolders(folderName);
                }
            });
            return folderList;
        }

        public Dictionary<string, byte[]> GetFiles(string path)
        {
            var fileList = new Dictionary<string, byte[]>();

            var ftpList = _ftp.GetList(path);

            ftpList.ForEach(f =>
            {
                if (f.IsFile)
                {
                    var fileName = path + f.Name + "/";
                    fileList.Add(fileName, _ftp.Download(fileName));
                }
            });
            return fileList;
        }

        public void UploadFile(string path, string fileName, byte[] fileContent)
        {
            _ftp.Upload(path + fileName, fileContent);
        }
    }
}
