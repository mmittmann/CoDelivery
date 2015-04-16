using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoDelivery.Core.Entities
{
    public class CoDeliveryContext : DbContext
    {
        public CoDeliveryContext()
            : base()
        {
            Database.SetInitializer(new EntitiesInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Integration> Integrations { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
