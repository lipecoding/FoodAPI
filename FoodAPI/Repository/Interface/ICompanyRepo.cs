using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface ICompanyRepo
    {
        Task<List<CompanyModel>> FindAllComapanys();
        Task<CompanyModel> FindById(int id);
        Task<CompanyModel> FindByEmail(string email);
        Task<CompanyModel> AddComapany(CompanyModel company);
        Task<CompanyModel> UpdateComapany(CompanyModel company, int id);
        Task<bool> DeleteComapany(int id);
        Task<bool> Login(string email, string password);
    }
}
