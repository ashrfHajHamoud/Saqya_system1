using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saqya_system.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }

        // معرف الزبون (المستخدم)
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User Customer { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string WaterType { get; set; }  // صالحة / غير صالحة للشرب

        [Required]
        public string Region { get; set; }

        public DateTime OrderTime { get; set; } = DateTime.Now;

        public string Status { get; set; } = "قيد التنفيذ"; // قيد التنفيذ / تم التسليم

        public DateTime? StartDeliveryTime { get; set; }

        public DateTime? EndDeliveryTime { get; set; }

        // معرف السائق المخصص (إن وجد)
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public User Driver { get; set; }
    }
}
