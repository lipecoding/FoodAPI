using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponUserRelMap : IEntityTypeConfiguration<CouponUserRelModel>
    {
        public void Configure(EntityTypeBuilder<CouponUserRelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CouponId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.Coupon);
            builder.HasOne(x => x.User);
        }
    }
}
