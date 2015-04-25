using System.Collections.Generic;

namespace CoDelivery.Core.Entities
{
    public class User
    {
        protected User(){}

        public User(string userName, string password, string email, string name)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Name = name;
        }

        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Integration> Integrations { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
