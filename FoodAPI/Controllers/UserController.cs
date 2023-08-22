using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo) 
        { 
            _userRepo = userRepo;
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {
            UserModel user = await _userRepo.FindById(id);

            return Ok(user);
        }
        [HttpGet("FindByEmail/{email}")]
        public async Task<ActionResult<UserModel>> FindByEmail(string email)
        {
            UserModel user = await _userRepo.FindByEmail(email);

            return Ok(user);
        }
        [HttpGet("FindAllUsers")]
        public async Task<ActionResult<UserModel>> FindAllUsers()
        {
            List<UserModel> user = await _userRepo.FindAllUsers();

            return Ok(user);
        }

        [HttpGet("Login/{email}-{password}")]
        public async Task<ActionResult<bool>> Login(string email, string password)
        {
            bool login = await _userRepo.Login(email, password);

            return Ok(login);
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel user, int id)
        {
            UserModel userm = await _userRepo.UpdateUser(user, id);

            return Ok(userm);
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {
            await _userRepo.AddUser(user);

            return Ok(user);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool del = await _userRepo.DeleteUser(id);

            return Ok(del);
        }
    }
}
