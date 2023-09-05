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
        public async Task<ActionResult<MenuModel>> AddItem(MenuModel model)
        {
            MenuModel menuM = await _menuRepo.AddItem(model);

            if(menuM.Error.IsNullOrEmpty())
                return Ok(menuM);
            else
                return BadRequest(menuM.Error);
        }
        [HttpDelete("DeleteItem/{id}")]
        public async Task<ActionResult<bool>> DeleteItem(int id)
        {
            bool del = await _menuRepo.DeleteItem(id);

            return Ok(del);
        }
        [HttpGet("FindAllItens/{companyId}")]
        public async Task<ActionResult<List<MenuModel>>> FindAllItens(int companyId)
        {
            List<MenuModel> menus = await _menuRepo.FindAllItens(companyId);

            return Ok(menus);
        }
        [HttpGet("FindItemByID/{id}")]
        public async Task<ActionResult<MenuModel>> FindItemByID(int id)
        {
            MenuModel menu = await _menuRepo.FindItemByID(id);

            return Ok(menu);
        }
        [HttpPut("UpdateItem/{id}")]
        public async Task<ActionResult<MenuModel>> UpdateItem(MenuModel menu, int id)
        {
            MenuModel menuM = await _menuRepo.UpdateItem(menu, id);

            return Ok(menuM);
        }
        [HttpGet("FindItensByName/{name}")]
        public async Task<ActionResult<List<MenuModel>>> FindItensByName(string name)
        {
            List<MenuModel> menus = await _menuRepo.FindItensByName(name);

            return Ok(menus);
        }
        [HttpGet("FindItensByCategorie/{categorie}")]
        public async Task<ActionResult<List<MenuModel>>> FindItensByCategorie(string categorie)
        {
            List<MenuModel> menus = await _menuRepo.FindItensByCategorie(categorie);

            return Ok(menus);
        }
    }
}
