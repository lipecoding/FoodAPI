using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("MENU")]
    public class Menu
    {
        public Menu()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [Column("m_id")]
        public virtual Guid? Id { get; set; }

        [Column("m_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("m_description")]
        [Required]
        [MaxLength(1000)]
        public virtual String Description { get; set; }

        [Column("m_categories")]
        [Required]
        [MaxLength(255)]
        public virtual String Categories { get; set; }

        [Column("m_price")]
        [Required]
        public virtual Decimal Price { get; set; }

        [Column("m_discount")]
        [Required]
        public virtual Decimal Discount { get; set; }

        [Column("m_image")]
        [Required]
        [MaxLength(255)]
        public virtual String Image { get; set; }

        [Column("m_is_active")]
        [Required]
        public virtual bool IsActive { get; set; }

        [Column("m_company_id")]
        [Required]
        public virtual Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual String? Error { get; set; }
    }
}
