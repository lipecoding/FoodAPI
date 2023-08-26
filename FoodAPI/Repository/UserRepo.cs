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
            if (_dbContext.User.Where(x => x.Email == user.Email).Any())
            {
                user.Error = "User With this email already exists";
            }

            if (_dbContext.User.Where(x => x.CPF == user.CPF).Any())
            {
                user.Error = "User With this CPF already exists";
            }

            if (_dbContext.User.Where(x => x.PhoneNumber == user.PhoneNumber).Any())
            {
                user.Error = "User With this phoneNumber already exists";
            }

            if (user.Error.IsNullOrEmpty())
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

            if (_dbContext.User.Where(x => x.Email == user.Email).Any())
                userM.Error = "This Email is already in use.";
            else
                userM.Email = user.Email;

            userM.Password = user.Password; 
            userM.Age = user.Age;

            if (_dbContext.User.Where(x => x.PhoneNumber == user.PhoneNumber).Any())
            {
                if (!userM.Error.IsNullOrEmpty())
                    userM.Error += "\n";

                userM.Error += "This PhoneNumber is already in use.";
            }
            else
                userM.PhoneNumber = user.PhoneNumber;

            userM.Premium = user.Premium;

            _dbContext.Update(userM);
            await _dbContext.SaveChangesAsync();

            return userM;

        }
    }
}
