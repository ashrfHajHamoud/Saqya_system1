using System.Collections.Generic;

namespace Saqya_system.Models
{
    public class AdminDashboardViewModel
    {
        public int TotalOrders { get; set; }
        public string TopRegion { get; set; }
        public string AverageDeliveryTime { get; set; }
        public string DriverRatings { get; set; }

        public List<User> Users { get; set; } = new List<User>();
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}
