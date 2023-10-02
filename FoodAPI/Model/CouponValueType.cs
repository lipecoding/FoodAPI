using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Model
{
    [Table("COUPON_VALUE_TYPE")]
    public class CouponValueType
    {
        public CouponValueType()
        {
            Id = Guid.NewGuid();
        }
        [Column("cvt_id")]
        [Key]
        public virtual Guid Id { get; set; }
        [Column("cvt_name")]
        [Required]
        public virtual String Name { get; set; }
    }
}
