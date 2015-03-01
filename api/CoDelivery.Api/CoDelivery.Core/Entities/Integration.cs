using System.Collections.Generic;

namespace CoDelivery.Core.Entities
{
    public class Integration
    {
        public int Id { get; set; } 
        public IntegrationSystem IntegrationSystem { get; set; }
        public Dictionary<string, string> Settings { get; set; }    
    }
}