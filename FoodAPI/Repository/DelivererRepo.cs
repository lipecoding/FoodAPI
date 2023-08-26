using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Repository
{
    public class DelivererRepo : IDelivererRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public DelivererRepo (FoodApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DelivererModel> AddDeliverer(DelivererModel model)
        {
            if(_dbContext.Deliverer.Where(x => x.Email == model.Email).Any())
            {
                model.Error = "Already exists one Deliverer with this Email!";
            }
            if (_dbContext.Deliverer.Where(x => x.CPF == model.CPF).Any())
            {
                model.Error = "Already exists one Deliverer with this CPF!";
            }
            if (_dbContext.Deliverer.Where(x => x.CNH == model.CNH).Any())
            {
                model.Error = "Already exists one Deliverer with this CNH!";
            }
            if (_dbContext.Deliverer.Where(x => x.PhoneNumber == model.PhoneNumber).Any())
            {
                model.Error = "Already exists one Deliverer with this PhoneNumber!";
            }
            if(model.Error.IsNullOrEmpty())
            { 
                await _dbContext.Deliverer.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            return model;
        }

        public async Task<bool> DeleteDeliverer(int id)
        {
            DelivererModel model = await FindById(id);

            _dbContext.Deliverer.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DelivererModel>> FindAll()
        {
            return await _dbContext.Deliverer.ToListAsync();
        }

        public async Task<DelivererModel> FindById(int id)
        {
            return await _dbContext.Deliverer.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DelivererModel> UpdateDeliverer(int id, DelivererModel model)
        {
            DelivererModel deliverer = await FindById(id);

            deliverer.Name = model.Name;

            if (_dbContext.Deliverer.Where(x => x.Email == model.Email).Any())
                deliverer.Error = "Already exists one Deliverer with this Email!";
            else
                deliverer.Email = model.Email;

            if (_dbContext.Deliverer.Where(x => x.PhoneNumber == model.PhoneNumber).Any())
                deliverer.Error = "Already exists one Deliverer with this PhoneNumber!";
            else
                deliverer.PhoneNumber = model.PhoneNumber;

            deliverer.Age = model.Age;
            deliverer.CEP = model.CEP;
            deliverer.AdressNumber = model.AdressNumber;
            deliverer.Complement = model.Complement;
            deliverer.Street = model.Street;

            _dbContext.Deliverer.Update(deliverer);
            await _dbContext.SaveChangesAsync();

            return deliverer;
        }
    }
}
