using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelivererController : ControllerBase
    {
        private readonly IDelivererRepo _repo;

        public DelivererController(IDelivererRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("FindAll")]
        public async Task<ActionResult<List<Deliverer>>> FindAll() 
        {
            List<Deliverer> deliverer = await _repo.FindAll();

            return Ok(deliverer);
        }
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<Deliverer>> FindById(Guid id)
        {
            Deliverer deliverer = await _repo.FindById(id);

            return Ok(deliverer);
        }
        [HttpPost("AddDeliverer")]
        public async Task<ActionResult<Deliverer>> AddDeliverer(Deliverer model)
        {
            Deliverer deliverer = await _repo.AddDeliverer(model);

            if (deliverer.Error.IsNullOrEmpty())
                return Ok(deliverer);
            else
                return BadRequest(deliverer.Error);
        }
        [HttpPut("UpdateDeliverer/{id}")]
        public async Task<ActionResult<Deliverer>> UpdateDeliverer(Guid id, Deliverer model)
        {
            Deliverer deliverer = await _repo.UpdateDeliverer(id, model);

            return Ok(deliverer);
        }
        [HttpDelete("DeleteDeliverer/{id}")]
        public async Task<ActionResult<bool>> DeleteDeliverer(Guid id)
        {
            bool del = await _repo.DeleteDeliverer(id);

            return Ok(del);
        }

    }
}
