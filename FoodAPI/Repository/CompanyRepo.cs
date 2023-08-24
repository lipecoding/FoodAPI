using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Repository
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public CompanyRepo(FoodApiDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<CompanyModel> AddCompany(CompanyModel company)
        {
            if (!_dbContext.Company.FirstOrDefault(x => x.Email == company.Email).ToString().IsNullOrEmpty())
            {
                throw new Exception("Company With this email already exists");
            }
            else if (!_dbContext.Company.FirstOrDefault(x => x.CNPJ == company.CNPJ).ToString().IsNullOrEmpty())
            {
                throw new Exception("Company With this CNPJ already exists");
            }
            else
            {
                await _dbContext.Company.AddAsync(company);
                await _dbContext.SaveChangesAsync();
            }

            return company;
        }

        public async Task<bool> DeleteCompany(int id)
        {
            CompanyModel company = await FindById(id);

            _dbContext.Company.Remove(company);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CompanyModel>> FindAllCompanys()
        {
            return await _dbContext.Company.ToListAsync();
        }

        public async Task<CompanyModel> FindByEmail(string email)
        {
            CompanyModel company = await _dbContext.Company.FirstOrDefaultAsync(x => x.Email == email);
            if (company == null)
            {
                throw new Exception($"Company ID: {email} Unknown!");
            }

            return company;
        }

        public async Task<CompanyModel> FindById(int id)
        {
            CompanyModel company = await _dbContext.Company.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null)
            {
                throw new Exception($"Company ID: {id} Unknown!");
            }

            return company;
        }

        public async Task<bool> Login(string email, string password)
        {
            CompanyModel company = await _dbContext.Company.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (company == null)
            {
                return false;
            }
            return true;
        }

        public async Task<CompanyModel> UpdateCompany(CompanyModel company, int id)
        {
            CompanyModel companyM = await _dbContext.Company.FirstOrDefaultAsync(x => x.Id == id);

            companyM.Type = company.Type;
            companyM.Description = company.Description;
            companyM.Password = company.Password;
            companyM.Name = company.Name;
            companyM.Email = !_dbContext.Company.FirstOrDefault(x => x.Email == company.Email).ToString().IsNullOrEmpty() ? companyM.Email : company.Email;
            companyM.Plan = company.Plan;

            await _dbContext.SaveChangesAsync();

            return companyM;
        }
    }
}
