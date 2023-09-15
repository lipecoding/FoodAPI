using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponMap : IEntityTypeConfiguration<CouponModel>
    {
        public void Configure(EntityTypeBuilder<CouponModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Categorie).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.V_Type).IsRequired();
            builder.Property(x => x.ItemID);
            builder.HasOne(x => x.Menu);
            builder.HasMany(x => x.UserRel).WithOne(x => x.Coupon);
            builder.HasMany(x => x.CompanyRel).WithOne(x => x.Coupon);

            builder.Ignore(x => x.Error);
        }
        
    }
}
