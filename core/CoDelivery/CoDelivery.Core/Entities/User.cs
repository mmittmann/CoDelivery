using System.Collections.Generic;

namespace CoDelivery.Core.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Integration> Integrations { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
