using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult<User>> FindById(Guid id)
        {
            User user = await _userRepo.FindById(id);

            return Ok(user);
        }
        [HttpGet("FindByEmail/{email}")]
        public async Task<ActionResult<User>> FindByEmail(string email)
        {
            User user = await _userRepo.FindByEmail(email);

            return Ok(user);
        }
        [HttpGet("FindAllUsers")]
        public async Task<ActionResult<User>> FindAllUsers()
        {
            List<User> user = await _userRepo.FindAllUsers();

            return Ok(user);
        }

        [HttpGet("Login/{email}-{password}")]
        public async Task<ActionResult<bool>> Login(string email, string password)
        {
            bool login = await _userRepo.Login(email, password);

            return Ok(login);
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<User>> UpdateUser(User user, Guid id)
        {
            User userm = await _userRepo.UpdateUser(user, id);

            return Ok(userm);
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            User userM = await _userRepo.AddUser(user);
            if(userM.Error.IsNullOrEmpty())
                return Ok(userM);
            else
                return BadRequest(userM.Error);

        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            bool del = await _userRepo.DeleteUser(id);

            return Ok(del);
        }
    }
}
