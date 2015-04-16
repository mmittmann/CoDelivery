using CoDelivery.Core.Entities;

namespace CoDelivery.Web.Models
{
    public class DashboardModel
    {
        public DashboardSpecificModel<Integration> Integrations { get; set; }
        public DashboardSpecificModel<Recipe> Recipes { get; set; }
    }
}