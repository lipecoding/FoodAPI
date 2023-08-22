using FoodAPI.Model;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<CouponModel>> AddCoupon(CouponModel coupon)
        {
            CouponModel couponm = await _couponRepo.AddCoupon(coupon);

            return Ok(couponm);
        }
        [HttpPost("AddCouponToUser/{code}-{userid}")]
        public async Task<ActionResult<CouponModel>> AddCouponToUser(string code, int userid)
        {
            CouponModel coupon = await _couponRepo.AddCouponToUser(code, userid);

            return Ok(coupon);
        }
        [HttpDelete("DeleteCoupon/{id}")]
        public async Task<ActionResult<CouponModel>> DeleteCoupon(int id)
        {
            bool del = await _couponRepo.DeleteCoupon(id);

            return Ok(del);
        }
        [HttpGet("FindAllCoupon")]
        public async Task<ActionResult<List<CouponModel>>> FindAllCoupon()
        {
            List<CouponModel> coupons = await _couponRepo.FindAllCoupon();

            return Ok(coupons);
        }
        [HttpGet("FindByCode/{code}")]
        public async Task<ActionResult<CouponModel>> FindByCode(string code)
        {
            CouponModel coupon = await _couponRepo.FindByCode(code);

            return Ok(coupon);
        }
        [HttpGet("FindByCompanyId/{id}")]
        public async Task<ActionResult<List<CouponModel>>> FindByCompanyId(int companyid)
        {
            List<CouponModel> coupons = await _couponRepo.FindByCompanyId(companyid);

            return Ok(coupons);
        }
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<CouponModel>> FindById(int id)
        {
            CouponModel coupon = await _couponRepo.FindById(id);

            return Ok(coupon);
        }
        [HttpGet("FindByUserId/{userid}")]
        public async Task<ActionResult<List<CouponModel>>> FindByUserId(int userid)
        {
            var coupons = await _couponRepo.FindByUserId(userid);

            return Ok(coupons);
        }
        [HttpPut("UpdateCoupon")]
        public async Task<ActionResult<CouponModel>> UpdateCoupon(CouponModel coupon, int id)
        {
            CouponModel couponm = await _couponRepo.UpdateCoupon(coupon, id);

            return Ok(couponm);
        }
    }
}
