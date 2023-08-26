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
        public async Task<ActionResult<CompanyModel>> AddCompany(CompanyModel company)
        {
            CompanyModel companyM = await _companyRepo.AddCompany(company);

            if(companyM.Error.IsNullOrEmpty())
                return Ok(companyM);
            else
                return BadRequest(companyM.Error);
        }
        [HttpDelete("DeleteCompany/{id}")]
        public async Task<ActionResult<bool>> DeleteCompany(int id)
        {
            bool del = await _companyRepo.DeleteCompany(id);

            return Ok(del);
        }
        [HttpGet("FindAllCompanys")]
        public async Task<ActionResult<List<CompanyModel>>> FindAllCompanys()
        {
            List<CompanyModel> companys = await _companyRepo.FindAllCompanys();

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
        [HttpPut("UpdateCompany")]
        public async Task<ActionResult<CompanyModel>> UpdateCompany(CompanyModel company, int id)
        {
            CompanyModel companyM = await _companyRepo.UpdateCompany(company, id);

            return Ok(companyM);
        }
    }
}
