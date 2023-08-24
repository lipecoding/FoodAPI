using FoodAPI.Data;
using FoodAPI.ENUM;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Repository
{
    public class CouponRepo : ICouponRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public CouponRepo(FoodApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CouponModel> AddCoupon(CouponModel coupon)
        {
            if (!_dbContext.Coupon.FirstOrDefault(x => x.Code == coupon.Code).ToString().IsNullOrEmpty())
            {
                throw new Exception("Coupon with this code already exists");
            }
            else
            {
                await _dbContext.Coupon.AddAsync(coupon);
                await _dbContext.SaveChangesAsync();
            }
            return coupon;
        }
        
        public async Task<CouponModel> AddCouponToUser(string code, int userId)
        {
            CouponModel coupon = await FindByCode(code);
            CouponUserRelModel couponUserRel = new();

            couponUserRel.CouponId = coupon.Id;
            couponUserRel.UserId = userId;

            await _dbContext.CouponUserRel.AddAsync(couponUserRel);
            await _dbContext.SaveChangesAsync();

            return coupon;
        }

        public async Task<bool> DeleteCoupon(int id)
        {
            CouponModel coupon = await FindById(id);
            _dbContext.Coupon.Remove(coupon);
            return true;
        }

        public async Task<List<CouponModel>> FindAllCoupon()
        {
            return await _dbContext.Coupon.ToListAsync();
        }

        public async Task<CouponModel> FindByCode(string code)
        {
            CouponModel coupon = await _dbContext.Coupon.FirstOrDefaultAsync(x => x.Code == code);

            if (coupon == null)
            {
                throw new Exception($"COUPON CODE: {code} Unknown!");
            }
            return coupon;
        }

        public async Task<List<CouponModel>> FindByCompanyId(int companyId)
        {
            return await (from Coupon in _dbContext.Coupon 
                          join CompanyRel in _dbContext.CouponCompanyRel on Coupon.Id equals CompanyRel.CouponId 
                          where CompanyRel.CompanyId == companyId 
                          select Coupon).ToListAsync();
        }

        public async Task<CouponModel> FindById(int id)
        {
            CouponModel coupon = await _dbContext.Coupon.FirstOrDefaultAsync(x => x.Id == id);

            if (coupon == null)
            {
                throw new Exception($"COUPON ID: {id} Unknown!");
            }
            return coupon;
        }

        public async Task<List<CouponModel>> FindByUserId(int userId)
        {
            return await (from Coupon in _dbContext.Coupon
                          join UserRel in _dbContext.CouponUserRel on Coupon.Id equals UserRel.CouponId
                          where UserRel.UserId == userId
                          select Coupon).ToListAsync();
        }

        public async Task<CouponModel> UpdateCoupon(CouponModel coupon, int id)
        {
            await FindById(id);

            coupon.Id = id;
            coupon.Code = !_dbContext.Coupon.FirstOrDefault(x => x.Code == coupon.Code).ToString().IsNullOrEmpty() ? _dbContext.Coupon.FirstOrDefault(x => x.Id == id).Code : coupon.Code;

            _dbContext.Coupon.Update(coupon);
            await _dbContext.SaveChangesAsync();

            return coupon;


        }
    }
}
