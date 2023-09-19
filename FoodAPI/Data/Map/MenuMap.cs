using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Categories);
            builder.Property(x => x.Price);
            builder.Property(x => x.Discount);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Image);
            builder.Property(x => x.CompanyId);
            builder.HasOne(x => x.Company).WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(x => x.Error);
        }
    }
}
