using System.Data.Entity;

namespace CoDelivery.Core.Entities
{
    public class EntitiesInitializer : DropCreateDatabaseIfModelChanges<CoDeliveryContext>
    {
        protected override void Seed(CoDeliveryContext context)
        {
           

            base.Seed(context);
        }
    }
}