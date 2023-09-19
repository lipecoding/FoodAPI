using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repository
{
    public class CouponRepo : ICouponRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public CouponRepo(FoodApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            if (_dbContext.Coupon.Where(x => x.Code == coupon.Code).Any())
            {
                coupon.Error = "Coupon with this code already exists";
            }
            else
            {
                await _dbContext.Coupon.AddAsync(coupon);
                await _dbContext.SaveChangesAsync();
            }
            return coupon;
        }
        
        public async Task<Coupon> AddCouponToUser(string code, Guid userId)
        {
            Coupon coupon = await FindByCode(code);
            CouponUserRel couponUserRel = new();

            couponUserRel.CouponId = coupon.Id;
            couponUserRel.UserId = userId;

            await _dbContext.CouponUserRel.AddAsync(couponUserRel);
            await _dbContext.SaveChangesAsync();

            return coupon;
        }

        public async Task<bool> DeleteCoupon(Guid id)
        {
            Coupon coupon = await FindById(id);
            _dbContext.Coupon.Remove(coupon);
            return true;
        }

        public async Task<List<Coupon>> FindAllCoupon()
        {
            return await _dbContext.Coupon.ToListAsync();
        }

        public async Task<Coupon> FindByCode(string code)
        {
            Coupon coupon = await _dbContext.Coupon.FirstOrDefaultAsync(x => x.Code == code);

            if (coupon == null)
            {
                throw new Exception($"COUPON CODE: {code} Unknown!");
            }
            return coupon;
        }

        public async Task<List<Coupon>> FindByCompanyId(Guid companyId)
        {
            return await (from Coupon in _dbContext.Coupon 
                          join CompanyRel in _dbContext.CouponCompanyRel on Coupon.Id equals CompanyRel.CouponId 
                          where CompanyRel.CompanyId == companyId 
                          select Coupon).ToListAsync();
        }

        public async Task<Coupon> FindById(Guid id)
        {
            Coupon coupon = await _dbContext.Coupon.FirstOrDefaultAsync(x => x.Id == id);

            if (coupon == null)
            {
                throw new Exception($"COUPON ID: {id} Unknown!");
            }
            return coupon;
        }

        public async Task<List<Coupon>> FindByUserId(Guid userId)
        {
            return await (from Coupon in _dbContext.Coupon
                          join UserRel in _dbContext.CouponUserRel on Coupon.Id equals UserRel.CouponId
                          where UserRel.UserId == userId
                          select Coupon).ToListAsync();
        }

        public async Task<Coupon> UpdateCoupon(Coupon coupon, Guid id)
        {
            Coupon couponM = await FindById(id);

            coupon.Id = id;
            if(_dbContext.Coupon.Where(x => x.Code == coupon.Code).Any())
            {
                coupon.Code = couponM.Code;
                coupon.Error = "Coupon with this code already exists";
            }


            _dbContext.Coupon.Update(coupon);
            await _dbContext.SaveChangesAsync();

            return coupon;
        }
    }
}
