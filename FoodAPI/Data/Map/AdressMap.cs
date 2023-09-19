using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class AdressMap :IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AdressNumber).IsRequired().HasMaxLength(6);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User).WithOne();
        }
        
    }
}
