using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CoDelivery.Core.Entities;
using CoDelivery.Core.Infra.Clients;

namespace CoDelivery.Core.Repositories
{
    public class IntegrationRepository : IRepository<Integration>
    {
        private readonly CoDeliveryContext _context;

        public IntegrationRepository(CoDeliveryContext context)
        {
            _context = context;
        }

        public void Save(Integration entity)
        {
            _context.Integrations.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(int idEntity, Integration updatedEntity)
        {
            var integration = _context.Integrations.First(i => i.Id == idEntity);
            var preservedId = integration.Id;
            integration = updatedEntity;
            integration.Id = preservedId;

            _context.SaveChanges();
        }

        public void Delete(int idEntity)
        {
            var integration = _context.Integrations.First(i => i.Id == idEntity);
            _context.Integrations.Remove(integration);

            _context.SaveChanges();
        }

        public Integration GetSpecific(Func<Integration, bool> func)
        {
            return _context.Integrations.First(func);
        }

        public List<Integration> GetALot(Func<Integration, bool> func)
        {
            return _context.Integrations.Where(func).ToList();
        }

        public List<Integration> GetAll()
        {
            return _context.Integrations.Where(i => i.Id > 0).ToList();
        }
    }
}
