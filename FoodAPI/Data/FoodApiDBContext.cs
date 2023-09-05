using FoodAPI.Data.Map;
using FoodAPI.Enum;
using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Data
{
    public class FoodApiDBContext : DbContext
    {
        public FoodApiDBContext(DbContextOptions<FoodApiDBContext> options) : base(options) { }

        public DbSet<AdressModel> Adresses { get; set; }
        public DbSet<CouponModel> Coupon { get; set; }
        public DbSet<CouponUserRelModel> CouponUserRel { get; set; }
        public DbSet<CouponCompanyRelModel> CouponCompanyRel { get; set; }
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<DelivererModel> Deliverer { get; set; }
        public DbSet<DelivererMotorcicleModel> DelivererMotorcicle{ get; set; }


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

            base.OnModelCreating(modelBuilder);
        }
    }
}
