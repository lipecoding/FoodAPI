using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IUserRepo
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindById(int id);
        Task<UserModel> FindByEmail(string email);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
        Task<bool> Login(string email, string password);
    }
}
