using FoodAPI.ENUM;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COUPON")]
    [Index(nameof(Code), Name = "Index_Coupon")]
    public class Coupon
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("c_id")]
        public virtual Guid Id { get; set; }

        [Column("c_code")]
        [Required]
        [MaxLength(30)]
        public virtual String Code { get; set; }

        [Column("c_name")]
        [Required]
        [MaxLength(255)]
        public virtual String Name { get; set; }

        [Column("c_description")]
        [Required]
        [MaxLength(1000)]
        public virtual String Description { get; set; }

        [Column("c_menu_id")]
        [Required]
        public virtual Guid? MenuID { get; set; }
        public virtual Menu? Menu { get; set; }

        [Column("c_value")]
        [Required]
        public virtual double Value { get; set; }

        [Column("c_value_type")]
        [Required]
        public virtual VTypeEnum V_Type { get; set; }

        [Column("c_categorie")]
        [Required]
        public virtual CompanyTypeEnum Categorie { get; set; }

        [Column("c_premium")]
        [Required]
        public virtual PremiumEnum Premium { get; set; }

        public virtual List<CouponUserRel>? UserRel { get; set; }
        public virtual List<CouponCompanyRel> CompanyRel { get; set; }
        public virtual String? Error { get; set; }
    }
}
