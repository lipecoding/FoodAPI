using FoodAPI.Model;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepo _menuRepo;

        public MenuController(IMenuRepo menuRepo)
        {
            _menuRepo = menuRepo;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<Menu>> AddItem(Menu model)
        {
            Menu menuM = await _menuRepo.AddItem(model);

            if(menuM.Error.IsNullOrEmpty())
                return Ok(menuM);
            else
                return BadRequest(menuM.Error);
        }
        [HttpDelete("DeleteItem/{id}")]
        public async Task<ActionResult<bool>> DeleteItem(Guid id)
        {
            bool del = await _menuRepo.DeleteItem(id);

            return Ok(del);
        }
        [HttpGet("FindAllItens/{companyId}")]
        public async Task<ActionResult<List<Menu>>> FindAllItens(Guid companyId)
        {
            List<Menu> menus = await _menuRepo.FindAllItens(companyId);

            return Ok(menus);
        }
        [HttpGet("FindItemByID/{id}")]
        public async Task<ActionResult<Menu>> FindItemByID(Guid id)
        {
            Menu menu = await _menuRepo.FindItemByID(id);

            return Ok(menu);
        }
        [HttpPut("UpdateItem/{id}")]
        public async Task<ActionResult<Menu>> UpdateItem(Menu menu, Guid id)
        {
            Menu menuM = await _menuRepo.UpdateItem(menu, id);

            return Ok(menuM);
        }
        [HttpGet("FindItensByName/{name}")]
        public async Task<ActionResult<List<Menu>>> FindItensByName(string name)
        {
            List<Menu> menus = await _menuRepo.FindItensByName(name);

            return Ok(menus);
        }
        [HttpGet("FindItensByCategorie/{categorie}")]
        public async Task<ActionResult<List<Menu>>> FindItensByCategorie(string categorie)
        {
            List<Menu> menus = await _menuRepo.FindItensByCategorie(categorie);

            return Ok(menus);
        }
    }
}
