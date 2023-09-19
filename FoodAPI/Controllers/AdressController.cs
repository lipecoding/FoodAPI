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
        public async Task<ActionResult<Adress>> AddAdress(Adress adress)
         {
            Adress adressM = await _adressRepo.AddAdress(adress);

            return Ok(adressM);
        }
        [HttpDelete("DeleteAdress/{id}")]
        public async Task<ActionResult<bool>> DeleteAdress(Guid id)
        {
            bool del = await _adressRepo.DeleteAdress(id);

            return Ok(del);
        }
        [HttpGet("FindAdressByid/{id}")]
        public async Task<ActionResult<Adress>> FindAdressByid(Guid id)
        {
            Adress adress = await _adressRepo.FindAdressByid(id);

            return Ok(adress);
        }
        [HttpPut("UpdateAdress")]
        public async Task<ActionResult<Adress>> UpdateAdress(Adress adress, Guid id)
        {
            Adress adressM = await _adressRepo.UpdateAdress(adress, id);

            return Ok(adressM);
        }
        [HttpGet("FindAdress/{userId}")]
        public async Task<ActionResult<List<Adress>>> FindAdress(Guid userId)
        {
            List<Adress> adress = await _adressRepo.FindAdress(userId);

            return Ok(adress);
        }
    }
}
