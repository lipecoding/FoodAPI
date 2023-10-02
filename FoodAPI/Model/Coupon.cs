using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COUPON")]
    [Index(nameof(Code), Name = "Index_Coupon")]
    public class Coupon
    {
        public Coupon()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Column("c_id")]
        public virtual Guid? Id { get; set; }

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
        public virtual Decimal Value { get; set; }

        [Column("c_value_type_id")]
        [Required]
        public virtual Guid ValueTypeId { get; set; }
        public virtual CouponValueType ValueType { get; set; }

        [Column("c_company_type_id")]
        [Required]
        public virtual Guid CompanyTypeId { get; set; }
        public virtual CompanyType CompanyType { get; set; }

        [Column("c_plan_id")]
        [Required]
        public virtual Guid PlanId { get; set; }
        public virtual UserPlan Plan { get; set; }

        public virtual List<CouponUserRel>? UserRel { get; set; }
        public virtual List<CouponCompanyRel> CompanyRel { get; set; }
        public virtual String? Error { get; set; }
    }
}
