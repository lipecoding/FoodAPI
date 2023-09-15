using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class MenuMap : IEntityTypeConfiguration<MenuModel>
    {
        public void Configure(EntityTypeBuilder<MenuModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Categories).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Discount);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();
            builder.HasOne(x => x.Company).WithMany();

            builder.Ignore(x => x.Error);
        }
    }
}
