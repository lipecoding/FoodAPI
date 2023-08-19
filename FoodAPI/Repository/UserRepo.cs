using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public UserRepo(FoodApiDBContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel user = await FindById(id);

            if (user == null)
            {
                throw new Exception($"USER ID: {id} Unknown!");
            }

            return true;

        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> FindByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserModel> FindById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userM = await FindById(id);

            if (userM == null)
            {
                throw new Exception($"USER ID: {id} Unknown!");
            }
            userM.Name = user.Name;
            userM.Email = user.Email;
            userM.Password = user.Password; 
            userM.Age = user.Age;
            userM.CPF = user.CPF;
            userM.PhoneNumber = user.PhoneNumber;
            userM.Premium = user.Premium;

            _dbContext.Update(userM);
            _dbContext.SaveChangesAsync();

            return userM;

        }
    }
}
