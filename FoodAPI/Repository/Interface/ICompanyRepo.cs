using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IComapanyRepo
    {
        Task<List<CompanyModel>> FindAllComapanys();
        Task<CompanyModel> FindById(int id);
        Task<CompanyModel> FindByEmail(string email);
        Task<CompanyModel> AddComapany(UserModel user);
        Task<CompanyModel> UpdateComapany(UserModel user);
        Task<bool> DeleteComapany(int id);
        Task<bool> Login(string email, string password);
    }
}
