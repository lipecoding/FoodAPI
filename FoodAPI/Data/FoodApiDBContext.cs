using FoodAPI.Data.Map;
using FoodAPI.Enum;
using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Data
{
    public class FoodApiDBContext : DbContext
    {
        public FoodApiDBContext(DbContextOptions<FoodApiDBContext> options) : base(options) { }

        public DbSet<Adress> Adresses { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdressMap());
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
        }
    }
}
