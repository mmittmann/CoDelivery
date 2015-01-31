using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DropNet;
using DropNet.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace CoDelivery.Core.Infra.Clients
{
    public class DropBoxClient
    {
        private readonly DropNetClient _dropnetClient;

        public DropBoxClient(IRepository repository)
        {
            _dropnetClient = new DropNetClient("rgj1bdbeuc589gl", "cw5jo9a700c8d5v");
        }

        public void SetUserLoginCredentials(UserLogin userLogin)
        {
            _dropnetClient.UserLogin = userLogin;
        }

        public string GetUrlToRequestToken()
        {
            return _dropnetClient.BuildAuthorizeUrl();
        }

        public UserLogin GetToken()
        {
            return _dropnetClient.GetToken();
        }

        public UserLogin GetAccessToken()
        {


            return _dropnetClient.GetAccessToken();
        }

        public bool IsConnected()
        {
            return _dropnetClient.AccountInfo() != null;
        }

        public byte[] GetFile(string path)
        {
            return _dropnetClient.GetFile(path);
        }

        public string GetFolderContent(string path)
        {
            var metadata = _dropnetClient.GetMetaData(path);

            return "";
        }
    }

    public interface IRepository<T>
    {
        void Save(T entity);
        void Edit(int idEntity, T updatedEntity);
        void Delete(int idEntity);

        T GetSpecific(Func<T, bool> func);
        List<T> GetALot(Func<T, bool> func);
        List<T> GetAll();
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
            File.AppendAllText(_path,  JsonConvert.SerializeObject(entity));
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