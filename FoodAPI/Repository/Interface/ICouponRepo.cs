using FoodAPI.ENUM;
using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICouponRepo
    {
        Task<List<CouponModel>> FindAllCoupon();
        Task<CouponModel> FindById(int id);
        Task<List<CouponModel>> FindByUserId(int userId);
        Task<List<CouponModel>> FindByCompanyId(int companyId);
        Task<CouponModel> FindByCode(string code);
        Task<CouponModel> AddCoupon(CouponModel coupon);
        Task<CouponModel> UpdateCoupon(CouponModel coupon, int id);
        Task<CouponModel> AddCouponToUser(string code, int userId);
        Task<bool> DeleteCoupon(int id);
    }
}
