using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodAPI.Model
{
    [Table("COUPON_USER")]
    [Index(nameof(UserId), Name = "Index_CouponUser")]
    public class CouponUserRel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cu_id")]
        public virtual Guid Id { get; set; }

        [Column("cu_coupon_id")]
        [Required]
        public virtual Guid CouponId { get; set; }
        [JsonIgnore]
        public virtual Coupon? Coupon { get; set; }

        [Column("cu_user_id")]
        [Required]
        public virtual Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set;}
    }
}
