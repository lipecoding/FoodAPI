using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COMPANY_TYPE")]
    public class CompanyType
    {
        public CompanyType() 
        { 
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("ct_id")]
        public virtual Guid Id { get; set; }
        [Required]
        [Column("ct_name")]
        public virtual String Name { get; set; }
    }
}
