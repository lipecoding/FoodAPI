using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            if(!_dbContext.User.FirstOrDefault(x => x.Email == user.Email).ToString().IsNullOrEmpty())
            {
                throw new Exception("User With this email already exists");
            }
            else if(!_dbContext.User.FirstOrDefault(x => x.CPF == user.CPF).ToString().IsNullOrEmpty())
            {
                throw new Exception("User With this CPF already exists");
            }
            else if (!_dbContext.User.FirstOrDefault(x => x.PhoneNumber == user.PhoneNumber).ToString().IsNullOrEmpty())
            {
                throw new Exception("User With this phoneNumber already exists");
            }
            else
            {
                await _dbContext.User.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel user = await FindById(id);

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> FindByEmail(string email)
        {
            UserModel user = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                throw new Exception($"USER EMAIL: {email} Unknown!");
            }
            return user;
        }

        public async Task<UserModel> FindById(int id)
        {
            UserModel user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception($"USER ID: {id} Unknown!");
            }

            return user;
        }

        public async Task<bool> Login(string email, string password)
        {
            UserModel user = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userM = await FindById(id);

            userM.Name = user.Name;
            userM.Email = !_dbContext.User.FirstOrDefault(x => x.Email == user.Email).ToString().IsNullOrEmpty() ? userM.Email : user.Email;
            userM.Password = user.Password; 
            userM.Age = user.Age;
            userM.PhoneNumber = !_dbContext.User.FirstOrDefault(x => x.PhoneNumber == user.PhoneNumber).ToString().IsNullOrEmpty() ? userM.PhoneNumber : user.PhoneNumber;
            userM.Premium = user.Premium;

            _dbContext.Update(userM);
            _dbContext.SaveChangesAsync();

            return userM;

        }
    }
}
