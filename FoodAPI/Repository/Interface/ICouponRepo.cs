using FoodAPI.ENUM;
using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICouponRepo
    {
        Task<List<Coupon>> FindAllCoupon();
        Task<Coupon> FindById(Guid id);
        Task<List<Coupon>> FindByUserId(Guid userId);
        Task<List<Coupon>> FindByCompanyId(Guid companyId);
        Task<Coupon> FindByCode(string code);
        Task<Coupon> AddCoupon(Coupon coupon);
        Task<Coupon> UpdateCoupon(Coupon coupon, Guid id);
        Task<Coupon> AddCouponToUser(string code, Guid userId);
        Task<bool> DeleteCoupon(Guid id);
    }
}
