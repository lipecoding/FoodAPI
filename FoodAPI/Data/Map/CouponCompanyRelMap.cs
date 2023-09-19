using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponCompanyRelMap : IEntityTypeConfiguration<CouponCompanyRel>
    {
        public void Configure(EntityTypeBuilder<CouponCompanyRel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CouponId).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.HasOne(x => x.Coupon).WithMany(x => x.CompanyRel).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Company).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
