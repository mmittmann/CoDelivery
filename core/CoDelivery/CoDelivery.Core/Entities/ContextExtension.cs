using System.Data.Entity;
using System.Linq;

namespace CoDelivery.Core.Entities
{
    public static class UserExtension
    {
        public static User GetByUserName(this DbSet<User> users, string username)
        {
            return users.FirstOrDefault(i => i.UserName == username);
        }
    }

    public static class IntegrationExtension
    {
        public static Integration GetById(this DbSet<Integration> integrations, int id)
        {
            return integrations.FirstOrDefault(i => i.Id == id);
        }


    }
}