namespace FoodAPI.Model
{
    public class CouponCompanyRelModel
    {
        public int Id { get; set; }
        public int CouponId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }
        public string Error { get; set; }
    }
}
