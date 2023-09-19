using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.AdressId).IsRequired();
            builder.Property(x => x.DelivererId).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.CouponId);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Adress);
            builder.HasOne(x => x.Deliverer);
            builder.HasOne(x => x.Company);
            builder.HasOne(x => x.Coupon);
            builder.HasMany(x => x.Itens).WithOne(x => x.Order).OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(x => x.Error);
        }
    }
}
