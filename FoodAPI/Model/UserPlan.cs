using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("USER_PLAN")]
    public class UserPlan
    {
        public UserPlan() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("up_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("up_name")]
        public virtual String Name { get; set; }
    }
}
