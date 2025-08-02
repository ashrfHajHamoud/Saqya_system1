using Microsoft.EntityFrameworkCore;
using Saqya_system.Models;

namespace Saqya_system.Data
{
    public class SaqyaDbContext : DbContext
    {
        public SaqyaDbContext(DbContextOptions<SaqyaDbContext> options) : base(options) { }

        // جداول قاعدة البيانات
        public DbSet<User> Users { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Tank> Tanks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // إعداد المفتاح الأساسي أو العلاقات إن لزم الأمر
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<CustomerOrder>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Driver>()
                .HasKey(d => d.DriverId);

            modelBuilder.Entity<Region>()
                .HasKey(r => r.RegionId);

            modelBuilder.Entity<Tank>()
                .HasKey(t => t.TankId);

            // مثال على إضافة بيانات أولية (Seed Data) بدون lambda خطأ
            modelBuilder.Entity<Region>().HasData(
                new Region { RegionId = 1, RegionName = "ريف إدلب الجنوبي" },
                new Region { RegionId = 2, RegionName = "ريف حلب الغربي" }
            );

            // يمكن إضافة بيانات أولية أخرى إذا أردت بنفس الطريقة
        }
    }
}
