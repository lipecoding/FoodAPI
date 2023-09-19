using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodAPI.Model
{
    [Table("COUPON_COMPANY")]
    [Index(nameof(CompanyId), Name = "Index_CouponCompany")]
    public class CouponCompanyRel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cc_id")]
        public virtual Guid Id { get; set; }
        [Column("cc_coupon_id")]
        [Required]
        public virtual Guid CouponId { get; set; }
        [JsonIgnore]
        public virtual Coupon? Coupon { get; set; }

        [Column("cc_company_id")]
        [Required]
        public virtual Guid CompanyId { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }
    }
}
