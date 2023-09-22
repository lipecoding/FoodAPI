using FoodAPI.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COMPANY")]
    [Index(nameof(Email), Name = "Index_Company")]
    public class Company
    {
        public Company()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("cy_id")]
        public virtual Guid? Id { get; set; }

        [Column("cy_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("cy_description")]
        [Required]
        [MaxLength(1000)]
        public virtual String Description { get; set; }

        [Column("cy_email")]
        [Required]
        [MaxLength(255)]
        public virtual String Email { get; set; }

        [Column("cy_password")]
        [Required]
        [MaxLength(60)]
        public virtual String Password { get; set; }

        [Column("cy_cnpj")]
        [Required]
        [MaxLength(14)]
        public virtual String CNPJ { get; set; }

        [Column("cy_type")]
        [Required]
        public CompanyTypeEnum Type { get; set; }

        [Column("cy_plan")]
        [Required]
        public CompanyPlanEnum Plan { get; set; }
        public virtual String? Error { get; set; }
    }
}
