using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICompanyCouponRepo
    {
        Task<List<CompanyCouponModel>> FindAllCoupon();
        Task<CompanyCouponModel> FindById(int id);
        Task<CompanyCouponModel> FindByUserId(int userId);
        Task<CompanyCouponModel> FindByCompanyId(int companyId);
        Task<CompanyCouponModel> FindByType(string type);
        Task<CompanyCouponModel> FindByCode(string code);
        Task<CompanyCouponModel> AddCoupon(CompanyCouponModel coupon);
        Task<CompanyCouponModel> UpdateCoupon(CompanyCouponModel coupon);
        Task<CompanyCouponModel> AddCouponToUser(string code, int userId);
        Task<bool> DeleteCoupon(int id);
    }
}
