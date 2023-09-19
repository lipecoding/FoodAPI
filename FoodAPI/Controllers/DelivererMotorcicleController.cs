using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelivererMotorcicleController : ControllerBase
    {
        private readonly IDelivererMotorcicleRepo _repo;

        public DelivererMotorcicleController(IDelivererMotorcicleRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("FindAllMotorcicle")]
        public async Task<ActionResult<List<DelivererMotorcicle>>> FindAllMotorcicle() 
        {
            List<DelivererMotorcicle> delivererMotorcicle = await _repo.FindAllMotorcicle();

            return Ok(delivererMotorcicle);
        }
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<DelivererMotorcicle>> FindById(Guid id)
        {
            DelivererMotorcicle delivererMotorcicle = await _repo.FindById(id);

            return Ok(delivererMotorcicle);
        }
        [HttpGet("FindByUserId/{delivererId}")]
        public async Task<ActionResult<DelivererMotorcicle>> FindByUserId(Guid DelivererId)
        {
            DelivererMotorcicle delivererMotorcicle = await _repo.FindByUserId(DelivererId);

            return Ok(delivererMotorcicle);
        }
        [HttpPost("AddDelivererMotorcicle")]
        public async Task<ActionResult<DelivererMotorcicle>> AddDelivererMotorcicle(DelivererMotorcicle model)
        {
            DelivererMotorcicle delivererMotorcicle = await _repo.AddDelivererMotorcicle(model);

            if (delivererMotorcicle.Error.IsNullOrEmpty())
                return Ok(delivererMotorcicle);
            else
                return BadRequest(delivererMotorcicle.Error);
        }
        [HttpPut("UpdateDelivererMotorcicle/{id}")]
        public async Task<ActionResult<DelivererMotorcicle>> UpdateDelivererMotorcicle(Guid id, DelivererMotorcicle model)
        {
            DelivererMotorcicle delivererMotorcicle = await _repo.UpdateDelivererMotorcicle(id, model);

            return Ok(delivererMotorcicle);
        }
        [HttpDelete("DeleteDelivererMotorcicle/{id}")]
        public async Task<ActionResult<bool>> DeleteDelivererMotorcicle(Guid id)
        {
            bool del = await _repo.DeleteDelivererMotorcicle(id);

            return Ok(del);
        }

    }
}
