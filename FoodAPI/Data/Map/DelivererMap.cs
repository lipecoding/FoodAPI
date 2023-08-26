using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class DelivererMap : IEntityTypeConfiguration<DelivererModel>
    {
        public void Configure(EntityTypeBuilder<DelivererModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Age).IsRequired().HasMaxLength(3);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.CNH).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AdressNumber).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Complement).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(1);

            builder.Ignore(x => x.Error);
        }
    }
}
