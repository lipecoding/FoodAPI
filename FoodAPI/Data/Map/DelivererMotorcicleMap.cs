using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FoodAPI.Data.Map
{
    public class DelivererMotorcicleMap : IEntityTypeConfiguration<DelivererMotorcicleModel>
    {
        public void Configure (EntityTypeBuilder<DelivererMotorcicleModel> builder){
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Ano).IsRequired().HasMaxLength(4);  
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Placa).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Renavam).IsRequired().HasMaxLength(9);
            builder.Property(x => x.DelivererId).IsRequired();
            builder.HasOne(x => x.Deliverer);
            builder.Ignore(x => x.Error);
        }
        
    }
} 