using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICompanyRepo
    {
        Task<List<CompanyModel>> FindAllCompanys();
        Task<CompanyModel> FindById(int id);
        Task<CompanyModel> FindByEmail(string email);
        Task<CompanyModel> AddCompany(CompanyModel company);
        Task<CompanyModel> UpdateCompany(CompanyModel company, int id);
        Task<bool> DeleteCompany(int id);
        Task<bool> Login(string email, string password);
    }
}
