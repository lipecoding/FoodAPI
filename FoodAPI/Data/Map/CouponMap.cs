using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponMap : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasOne(x => x.Menu);
            builder.HasMany(x => x.UserRel).WithOne(x => x.Coupon);
            builder.HasMany(x => x.CompanyRel).WithOne(x => x.Coupon);
            builder.HasOne(x => x.CompanyType).WithOne().OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(x => x.Error);
        }
        
    }
}
