using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DropboxRestAPI;
using Newtonsoft.Json;

namespace CoDelivery.Core.Infra.Clients
{
    public class DropBoxClient
    {
        private readonly Client _dropnetClient;

        public DropBoxClient()
        {
            _dropnetClient = new Client(
                new Options());
            }

        public void SetUserLoginCredentials(string secret, string token)
        {
            throw new NotImplementedException();
        }

        public string GetUrlToRequestToken()
        {

            throw new NotImplementedException();
        }

        public void GetToken()
        {

            throw new NotImplementedException();
        }

        public void GetAccessToken()
        {

            throw new NotImplementedException();
        }

        public bool IsConnected()
        {

            throw new NotImplementedException();
        }

        public byte[] GetFile(string path)
        {

            throw new NotImplementedException();
        }

        public string GetFolderContent(string path)
        {
            throw new NotImplementedException();
        }
    }

    public class FileRepository<T> : IRepository<T>
    {
        private string _path;


        public FileRepository()
        {

            _path = @"C:\FileRepository\DropNetClient.txt";
        }

        public void Save(T entity)
        {
            File.AppendAllText(_path, JsonConvert.SerializeObject(entity));
        }

        public void Edit(int idEntity, T updatedEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idEntity)
        {
            throw new NotImplementedException();
        }

        public T GetSpecific(Func<T, bool> func)
        {
            var fileContent = File.ReadAllText(_path);

            var fileContentDeserialized = JsonConvert.DeserializeObject<List<T>>(fileContent);

            return fileContentDeserialized.First(func);
        }

        public List<T> GetALot(Func<T, bool> func)
        {
            var fileContent = File.ReadAllText(_path);

            var fileContentDeserialized = JsonConvert.DeserializeObject<List<T>>(fileContent);

            return fileContentDeserialized.Where(func).ToList();
        }

        public List<T> GetAll()
        {
            var fileContent = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<List<T>>(fileContent);
        }
    }

}