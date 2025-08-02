using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saqya_system.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        public string RegionName { get; set; }

        // علاقات
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
