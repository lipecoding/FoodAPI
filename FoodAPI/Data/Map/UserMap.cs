using FoodAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodAPI.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        { 
            builder.HasOne(x => x.Plan).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Ignore(x => x.Error);
        }
        
    }
}
