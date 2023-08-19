using FoodAPI.Data.Map;
using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Data
{
    public class FoodApiDBContext : DbContext
    {
        public FoodApiDBContext(DbContextOptions<FoodApiDBContext> options) : base(options) { }

        public DbSet<AdressModel> Adresses { get; set; }
        public DbSet<CouponModel> CompanyCoupon { get; set; }
        public DbSet<CompanyModel> CompanyModel { get; set; }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdressMap());
            modelBuilder.ApplyConfiguration(new CouponMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MenuMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
