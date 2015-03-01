using System;
using System.Collections.Generic;
using System.Linq;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Repositories
{
    public class IntegrationSystemRepository : IRepository<IntegrationSystem>
    {
        private readonly CoDeliveryContext _context;

        public IntegrationSystemRepository(CoDeliveryContext context)
        {
            _context = context;
        }

        public void Save(IntegrationSystem entity)
        {
            _context.IntegrationSystems.Add(entity);

            _context.SaveChanges();
        }

        public void Edit(int idEntity, IntegrationSystem updatedEntity)
        {
            var integrationSystem = _context.IntegrationSystems.First(isys => isys.Id == idEntity);
            var preservedId = integrationSystem.Id;

            integrationSystem = updatedEntity;
            integrationSystem.Id = preservedId;

            _context.SaveChanges();
        }

        public void Delete(int idEntity)
        {
            var integrationSystem = _context.IntegrationSystems.First(isys => isys.Id == idEntity);
            _context.IntegrationSystems.Remove(integrationSystem);

            _context.SaveChanges();
        }

        public IntegrationSystem GetSpecific(Func<IntegrationSystem, bool> func)
        {
            return _context.IntegrationSystems.First(func);
        }

        public List<IntegrationSystem> GetALot(Func<IntegrationSystem, bool> func)
        {
            return _context.IntegrationSystems.Where(func).ToList();
        }

        public List<IntegrationSystem> GetAll()
        {
            return GetALot(isys => isys.Id > 0);
        }
    }
}
