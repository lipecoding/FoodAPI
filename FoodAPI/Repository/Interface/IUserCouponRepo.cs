using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IUserCouponRepo
    {
        Task<List<UserCouponModel>> FindAllCoupon();
        Task<UserCouponModel> FindById(int id);
        Task<CompanyCouponModel> FindByUserId(int userId);
        Task<CompanyCouponModel> FindByType(string type);
        Task<UserCouponModel> FindByCode(string code);
        Task<UserCouponModel> AddCoupon(UserCouponModel Coupon);
        Task<UserCouponModel> UpdateCoupon(UserCouponModel Coupon);
        Task<bool> DeleteCoupon(int id);
    }
}
