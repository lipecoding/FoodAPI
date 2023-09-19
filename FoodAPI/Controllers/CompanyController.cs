using FoodAPI.Model;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost("AddCompany")]
        public async Task<ActionResult<Company>> AddCompany(Company company)
        {
            Company companyM = await _companyRepo.AddCompany(company);

            if(companyM.Error.IsNullOrEmpty())
                return Ok(companyM);
            else
                return BadRequest(companyM.Error);
        }
        [HttpDelete("DeleteCompany/{id}")]
        public async Task<ActionResult<bool>> DeleteCompany(Guid id)
        {
            bool del = await _companyRepo.DeleteCompany(id);

            return Ok(del);
        }
        [HttpGet("FindAllCompanys")]
        public async Task<ActionResult<List<Company>>> FindAllCompanys()
        {
            List<Company> companys = await _companyRepo.FindAllCompanys();

            return Ok(companys);
        }
        [HttpGet("FindByEmail/{email}")]
        public async Task<ActionResult<Company>> FindByEmail(string email)
        {
            Company company = await _companyRepo.FindByEmail(email);

            return Ok(company);
        }
        [HttpGet("FindById")]
        public async Task<ActionResult<Company>> FindById(Guid id)
        {
            Company company = await _companyRepo.FindById(id);

            return Ok(company);
        }
        [HttpGet("Login/{email}-{password}")]
        public async Task<ActionResult<bool>> Login(string email, string password)
        {
            bool login = await _companyRepo.Login(email, password);

            return Ok(login);
        }
        [HttpPut("UpdateCompany/{id}")]
        public async Task<ActionResult<Company>> UpdateCompany(Company company, Guid id)
        {
            Company companyM = await _companyRepo.UpdateCompany(company, id);

            return Ok(companyM);
        }
    }
}
