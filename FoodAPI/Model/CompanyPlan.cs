using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COMPANY_PLAN")]
    public class CompanyPlan
    {
        public CompanyPlan() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("cp_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("cp_name")]
        public virtual String Name { get; set; }
    }
}
