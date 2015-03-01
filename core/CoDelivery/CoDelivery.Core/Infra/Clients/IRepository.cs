using System;
using System.Collections.Generic;

namespace CoDelivery.Core.Infra.Clients
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Edit(int idEntity, T updatedEntity);
        void Delete(int idEntity);

        T GetSpecific(Func<T, bool> func);
        List<T> GetALot(Func<T, bool> func);
        List<T> GetAll();
    }
}