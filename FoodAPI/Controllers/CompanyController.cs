using FoodAPI.Model;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepo _companyRepo;

        public CompanyController(ICompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpPost("AddComapany")]
        public async Task<ActionResult<CompanyModel>> AddComapany(CompanyModel company)
        {
            await _companyRepo.AddComapany(company);

            return Ok(company);
        }
        [HttpDelete("DeleteComapany/{id}")]
        public async Task<ActionResult<bool>> DeleteComapany(int id)
        {
            bool del = await _companyRepo.DeleteComapany(id);

            return Ok(del);
        }
        [HttpGet("FindAllComapanys")]
        public async Task<ActionResult<List<CompanyModel>>> FindAllComapanys()
        {
            List<CompanyModel> companys = await _companyRepo.FindAllComapanys();

            return Ok(companys);
        }
        [HttpGet("FindByEmail/{email}")]
        public async Task<ActionResult<CompanyModel>> FindByEmail(string email)
        {
            CompanyModel company = await _companyRepo.FindByEmail(email);

            return Ok(company);
        }
        [HttpGet("FindById")]
        public async Task<ActionResult<CompanyModel>> FindById(int id)
        {
            CompanyModel company = await _companyRepo.FindById(id);

            return Ok(company);
        }
        [HttpGet("Login/{email}-{password}")]
        public async Task<ActionResult<bool>> Login(string email, string password)
        {
            bool login = await _companyRepo.Login(email, password);

            return Ok(login);
        }
        [HttpPut("UpdateComapany")]
        public async Task<ActionResult<CompanyModel>> UpdateComapany(CompanyModel company, int id)
        {
            CompanyModel companyM = await _companyRepo.UpdateComapany(company, id);

            return Ok(companyM);
        }
    }
}
