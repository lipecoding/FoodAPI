using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FoodAPI.Model
{
    [Index(nameof(CompanyId), Name = "Index_CouponCompanyRel")]
    public class CouponCompanyRelModel
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        [JsonIgnore]
        public virtual CouponModel Coupon { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }
    }
}
