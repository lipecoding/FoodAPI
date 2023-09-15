using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class OrderItensMap : IEntityTypeConfiguration<OrderItensModel>
    {
        public void Configure(EntityTypeBuilder<OrderItensModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.MenuId).IsRequired();
            builder.HasOne(x => x.Menu);
            builder.HasOne(x => x.Order).WithMany(x => x.Itens).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
