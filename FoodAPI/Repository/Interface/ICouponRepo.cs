using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICouponRepo
    {
        Task<List<CouponModel>> FindAllCoupon();
        Task<CouponModel> FindById(int id);
        Task<CouponModel> FindByUserId(int userId);
        Task<CouponModel> FindByCompanyId(int companyId);
        Task<CouponModel> FindByType(string type);
        Task<CouponModel> FindByCode(string code);
        Task<CouponModel> AddCoupon(CouponModel coupon);
        Task<CouponModel> UpdateCoupon(CouponModel coupon);
        Task<CouponModel> AddCouponToUser(string code, int userId);
        Task<bool> DeleteCoupon(int id);
    }
}
