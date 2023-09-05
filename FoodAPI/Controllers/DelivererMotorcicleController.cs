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
        public async Task<ActionResult<List<DelivererMotorcicleModel>>> FindAllMotorcicle() 
        {
            List<DelivererMotorcicleModel> delivererMotorcicle = await _repo.FindAllMotorcicle();

            return Ok(delivererMotorcicle);
        }
        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<DelivererMotorcicleModel>> FindById(int id)
        {
            DelivererMotorcicleModel delivererMotorcicle = await _repo.FindById(id);

            return Ok(delivererMotorcicle);
        }
        [HttpGet("FindByUserId/{delivererId}")]
        public async Task<ActionResult<DelivererMotorcicleModel>> FindByUserId(int DelivererId)
        {
            DelivererMotorcicleModel delivererMotorcicle = await _repo.FindByUserId(DelivererId);

            return Ok(delivererMotorcicle);
        }
        [HttpPost("AddDelivererMotorcicle")]
        public async Task<ActionResult<DelivererMotorcicleModel>> AddDelivererMotorcicle(DelivererMotorcicleModel model)
        {
            DelivererMotorcicleModel delivererMotorcicle = await _repo.AddDelivererMotorcicle(model);

            if (delivererMotorcicle.Error.IsNullOrEmpty())
                return Ok(delivererMotorcicle);
            else
                return BadRequest(delivererMotorcicle.Error);
        }
        [HttpPut("UpdateDelivererMotorcicle/{id}")]
        public async Task<ActionResult<DelivererMotorcicleModel>> UpdateDelivererMotorcicle(int id, DelivererMotorcicleModel model)
        {
            DelivererMotorcicleModel delivererMotorcicle = await _repo.UpdateDelivererMotorcicle(id, model);

            return Ok(delivererMotorcicle);
        }
        [HttpDelete("DeleteDelivererMotorcicle/{id}")]
        public async Task<ActionResult<bool>> DeleteDelivererMotorcicle(int id)
        {
            bool del = await _repo.DeleteDelivererMotorcicle(id);

            return Ok(del);
        }

    }
}
