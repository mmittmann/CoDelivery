using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoDelivery.Core.Entities
{
    public class CoDeliveryContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; } 
        public DbSet<IntegrationSystemEntity> IntegrationSystems { get; set; } 
        public DbSet<IntegrationEntity> Integrations { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
