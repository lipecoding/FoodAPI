using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IUserRepo
    {
        Task<List<User>> FindAllUsers();
        Task<User> FindById(Guid id);
        Task<User> FindByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user, Guid id);
        Task<bool> DeleteUser(Guid id);
        Task<bool> Login(string email, string password);
    }
}
