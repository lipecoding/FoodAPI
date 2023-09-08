using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Model
{
    [Index(nameof(UserId), Name = "Index_CouponUserRel")]
    public class CouponUserRelModel
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set;}
    }
}
