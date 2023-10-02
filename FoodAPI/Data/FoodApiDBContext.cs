using FoodAPI.Data.Map;
using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Data
{
    public class FoodApiDBContext : DbContext
    {
        public FoodApiDBContext(DbContextOptions<FoodApiDBContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<CouponUserRel> CouponUserRel { get; set; }
        public DbSet<CouponCompanyRel> CouponCompanyRel { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Deliverer> Deliverer { get; set; }
        public DbSet<DelivererMotorcicle> DelivererMotorcicle{ get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> OrderItens { get; set; }
        public DbSet<DelivererStatus> DelivererStatus { get; set; }
        public DbSet<DelivererVehicle> DelivererVehicle { get; set; }
        public DbSet<CompanyPlan> CompanyPlan { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<CouponValueType> CouponValueType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new CouponMap());
            modelBuilder.ApplyConfiguration(new CouponCompanyRelMap());
            modelBuilder.ApplyConfiguration(new CouponUserRelMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new DelivererMap());
            modelBuilder.ApplyConfiguration(new DelivererMotorcicleMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ItemMap());

            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DelivererStatus>().HasData(
                new DelivererStatus { Name = "Offline" },
                new DelivererStatus { Name = "Online"},
                new DelivererStatus { Name = "Work"}
                );
            modelBuilder.Entity<DelivererVehicle>().HasData(
                new DelivererVehicle { Name = "Bike"},
                new DelivererVehicle { Name = "Motorcicle"}
                );
            modelBuilder.Entity<CompanyPlan>().HasData(
                new CompanyPlan { Name = "Basic" }, 
                new CompanyPlan { Name = "Master" }
                );
            modelBuilder.Entity<CompanyType>().HasData(
                new CompanyType { Name = "Market" },
                new CompanyType { Name = "Restaurant" }
                );
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Name = "Open" },
                new OrderStatus { Name = "Closed" },
                new OrderStatus { Name = "Canceled" }
                );
            modelBuilder.Entity<UserPlan>().HasData(
                new UserPlan { Name = "None" },
                new UserPlan { Name = "Premium" }
                );
            modelBuilder.Entity<CouponValueType>().HasData(
                new CouponValueType { Name = "Percetage" },
                new CouponValueType { Name = "Value" }
                );
        }
    }
}
