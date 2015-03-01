using System;
using System.Collections.Generic;
using System.Linq;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        private readonly CoDeliveryContext _coDeliveryContext;

        public UserRepository(CoDeliveryContext coDeliveryContext)
        {
            _coDeliveryContext = coDeliveryContext;
        }

        public void Save(UserEntity entity)
        {
            _coDeliveryContext.UserEntities.Add(entity);
            _coDeliveryContext.SaveChanges();
        }

        public void Edit(int idEntity, UserEntity updatedEntity)
        {
            var user = _coDeliveryContext.UserEntities.First(u => u.Id == idEntity);
            user.Password = updatedEntity.Password;
            user.UserName = updatedEntity.UserName;

            _coDeliveryContext.SaveChanges();
        }

        public void Delete(int idEntity)
        {
            var user = _coDeliveryContext.UserEntities.First(u => u.Id == idEntity);

            _coDeliveryContext.UserEntities.Remove(user);
        }

        public UserEntity GetSpecific(Func<UserEntity, bool> func)
        {
            return _coDeliveryContext.UserEntities.FirstOrDefault(func);
        }

        public List<UserEntity> GetALot(Func<UserEntity, bool> func)
        {
            return _coDeliveryContext.UserEntities.Where(func).ToList();
        }

        public List<UserEntity> GetAll()
        {
            return _coDeliveryContext.UserEntities.Where(p => p.Id > 0).ToList();
        }
    }
}
