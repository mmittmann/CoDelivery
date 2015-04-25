using System.Data.Entity;

namespace CoDelivery.Core.Entities
{
    public class EntitiesInitializer : DropCreateDatabaseIfModelChanges<CoDeliveryContext>
    {
        protected override void Seed(CoDeliveryContext context)
        {
            context.Users.Add(new User("mmittmann", "123qwe!@#QWE", "murilo@mittmann.me", "Murilo"));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}