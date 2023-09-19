using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FoodAPI.Data.Map
{
    public class DelivererMotorcicleMap : IEntityTypeConfiguration<DelivererMotorcicle>
    {
        public void Configure (EntityTypeBuilder<DelivererMotorcicle> builder){
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Year).IsRequired().HasMaxLength(4);  
            builder.Property(x => x.Model).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Plate).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Renavam).IsRequired().HasMaxLength(9);
            builder.Property(x => x.DelivererId).IsRequired();
            builder.HasOne(x => x.Deliverer).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Ignore(x => x.Error);
        }
        
    }
} 