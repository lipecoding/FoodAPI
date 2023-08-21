using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CouponCompanyRelMap : IEntityTypeConfiguration<CouponCompanyRelModel>
    {
        public void Configure(EntityTypeBuilder<CouponCompanyRelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CouponId).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();

            builder.HasOne(x => x.Coupon);
            builder.HasOne(x => x.Company);
        }
    }
}
