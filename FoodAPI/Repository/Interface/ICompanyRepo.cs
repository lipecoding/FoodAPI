using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICompanyRepo
    {
        Task<List<Company>> FindAllCompanys();
        Task<Company> FindById(Guid id);
        Task<Company> FindByEmail(string email);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company, Guid id);
        Task<bool> DeleteCompany(Guid id);
        Task<bool> Login(string email, string password);
    }
}
