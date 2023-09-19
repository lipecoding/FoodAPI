using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class CompanyMap :IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.CNPJ).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Plan).IsRequired();

            builder.Ignore(x => x.Error);
        }
        
    }
}
