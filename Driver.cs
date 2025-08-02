using System.ComponentModel.DataAnnotations;

namespace Saqya_system.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        public string DriverName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string TankSize { get; set; } // "خزان كامل" أو "جزء من خزان"

        [Required]
        public string Region { get; set; }

        [Required]
        public decimal PricePerBarrel { get; set; }

        [Required]
        public string TankStatus { get; set; } // "مشغول" / "غير مشغول"

        [Required]
        public string MaxDeliveryTime { get; set; }  // مثال: "3 ساعات"
    }
}
