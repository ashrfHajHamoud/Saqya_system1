using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saqya_system.Models
{
    public class Tank
    {
        [Key]
        public int TankId { get; set; }

        [Required]
        public string TankSize { get; set; } // حجم الخزان: كامل أو جزء

        [Required]
        public string TankStatus { get; set; } // حالة الخزان: مشغول / غير مشغول

        // العلاقة مع السائق (اختياري)
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        // يمكن إضافة المزيد من الحقول حسب الحاجة
    }
}
