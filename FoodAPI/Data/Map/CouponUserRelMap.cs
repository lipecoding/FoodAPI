using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponUserRelMap : IEntityTypeConfiguration<CouponUserRel>
    {
        public void Configure(EntityTypeBuilder<CouponUserRel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CouponId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.Coupon).WithMany(x => x.UserRel).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.User).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
