using System.Collections.Generic;

namespace CoDelivery.Core.Entities
{
    public class IntegrationEntity
    {
        public int Id { get; set; }
        public IntegrationSystemEntity IntegrationSystem { get; set; }
        public UserEntity User { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}