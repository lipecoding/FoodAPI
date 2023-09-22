using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(x => x.Menu);
            builder.HasOne(x => x.Order).WithMany(x => x.Itens).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
