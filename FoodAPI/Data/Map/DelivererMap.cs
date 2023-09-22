using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class DelivererMap : IEntityTypeConfiguration<Deliverer>
    {
        public void Configure(EntityTypeBuilder<Deliverer> builder)
        {
            builder.Ignore(x => x.Error);
        }
    }
}
