using System.Collections.Generic;

namespace CoDelivery.Web.Models
{
    public class DashboardSpecificModel<T>
    {
        public string Name { get; set; }
        public List<T> List { get; set; }
        public string Label { get; set; }
    }
}