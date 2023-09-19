using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Premium).IsRequired();

            builder.Ignore(x => x.Error);
        }
        
    }
}
