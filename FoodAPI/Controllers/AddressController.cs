using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo _addressRepo;

        public AddressController(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }

        [HttpPost("AddAddress")]
        public async Task<ActionResult<Address>> AddAddress(Address address)
         {
            Address addressM = await _addressRepo.AddAddress(address);

            return Ok(addressM);
        }
        [HttpDelete("DeleteAddress/{id}")]
        public async Task<ActionResult<bool>> DeleteAddress(Guid id)
        {
            bool del = await _addressRepo.DeleteAddress(id);

            return Ok(del);
        }
        [HttpGet("FindAddressByid/{id}")]
        public async Task<ActionResult<Address>> FindAddressByid(Guid id)
        {
            Address address = await _addressRepo.FindAddressByid(id);

            return Ok(address);
        }
        [HttpPut("UpdateAddress")]
        public async Task<ActionResult<Address>> UpdateAddress(Address address, Guid id)
        {
            Address addressM = await _addressRepo.UpdateAddress(address, id);

            return Ok(addressM);
        }
        [HttpGet("FindAddress/{userId}")]
        public async Task<ActionResult<List<Address>>> FindAddress(Guid userId)
        {
            List<Address> address = await _addressRepo.FindAddress(userId);

            return Ok(address);
        }
    }
}
