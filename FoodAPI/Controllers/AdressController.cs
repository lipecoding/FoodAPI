using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressRepo _adressRepo;

        public AdressController(IAdressRepo adressRepo)
        {
            _adressRepo = adressRepo;
        }

        [HttpPost("AddAdress")]
        public async Task<ActionResult<AdressModel>> AddAdress(AdressModel adress)
         {
            AdressModel adressM = await _adressRepo.AddAdress(adress);

            return Ok(adressM);
        }
        [HttpDelete("DeleteAdress/{id}")]
        public async Task<ActionResult<bool>> DeleteAdress(int id)
        {
            bool del = await _adressRepo.DeleteAdress(id);

            return Ok(del);
        }
        [HttpGet("FindAdressByid/{id}")]
        public async Task<ActionResult<AdressModel>> FindAdressByid(int id)
        {
            AdressModel adress = await _adressRepo.FindAdressByid(id);

            return Ok(adress);
        }
        [HttpPut("UpdateAdress")]
        public async Task<ActionResult<AdressModel>> UpdateAdress(AdressModel adress, int id)
        {
            AdressModel adressM = await _adressRepo.UpdateAdress(adress, id);

            return Ok(adressM);
        }
        [HttpGet("FindAdress/{userId}")]
        public async Task<ActionResult<List<AdressModel>>> FindAdress(int userId)
        {
            List<AdressModel> adress = await _adressRepo.FindAdress(userId);

            return Ok(adress);
        }
    }
}
