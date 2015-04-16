using System.Collections.Generic;

namespace CoDelivery.Core.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }  
        public virtual List<IntegrationRecipe> IntegrationRecipes{ get; set; }
    }
}
