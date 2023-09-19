using FoodAPI.Model;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepo _couponRepo;

        public CouponController(ICouponRepo couponRepo) 
        { 
            _couponRepo = couponRepo;
        }

        [HttpPost("AddCoupon")]
        public async Task<ActionResult<Coupon>> AddCoupon(Coupon coupon)
        {
            Coupon couponm = await _couponRepo.AddCoupon(coupon);

            if (couponm.Error.IsNullOrEmpty())
                return Ok(couponm);
            else
                return BadRequest(couponm.Error);
        }
        [HttpPost("AddCouponToUser/{code}-{userid}")]
        public async Task<ActionResult<Coupon>> AddCouponToUser(string code, Guid userid)
        {
            Coupon coupon = await _couponRepo.AddCouponToUser(code, userid);

            return Ok(coupon);
        }
        [HttpDelete("DeleteCoupon/{id}")]
        public async Task<ActionResult<Coupon>> DeleteCoupon(Guid id)
        {
            bool del = await _couponRepo.DeleteCoupon(id);

            return Ok(del);
        }
        [HttpGet("FindAllCoupon")]
        public async Task<ActionResult<List<Coupon>>> FindAllCoupon()
        {
            List<Coupon> coupons = await _couponRepo.FindAllCoupon();

            return Ok(coupons);
        }
        [HttpGet("FindByCode/{code}")]
        public async Task<ActionResult<Coupon>> FindByCode(string code)
        {
            Coupon coupon = await _couponRepo.FindByCode(code);

            return Ok(coupon);
        }
        [HttpGet("FindByCompanyId/{id}")]
        public async Task<ActionResult<List<Coupon>>> FindByCompanyId(Guid companyid)
        {
            List<Coupon> coupons = await _couponRepo.FindByCompanyId(companyid);

            return Ok(coupons);
        }
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<Coupon>> FindById(Guid id)
        {
            Coupon coupon = await _couponRepo.FindById(id);

            return Ok(coupon);
        }
        [HttpGet("FindByUserId/{userid}")]
        public async Task<ActionResult<List<Coupon>>> FindByUserId(Guid userid)
        {
            var coupons = await _couponRepo.FindByUserId(userid);

            return Ok(coupons);
        }
        [HttpPut("UpdateCoupon")]
        public async Task<ActionResult<Coupon>> UpdateCoupon(Coupon coupon, Guid id)
        {
            Coupon couponm = await _couponRepo.UpdateCoupon(coupon, id);

            return Ok(couponm);
        }
    }
}
