using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FoodAPI.Data.Map
{
    public class DelivererMotorcicleMap : IEntityTypeConfiguration<DelivererMotorcicle>
    {
        public void Configure (EntityTypeBuilder<DelivererMotorcicle> builder){
            builder.HasOne(x => x.Deliverer).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Ignore(x => x.Error);
        }
        
    }
} 