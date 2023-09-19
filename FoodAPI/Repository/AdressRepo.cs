using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repository
{
    public class AdressRepo : IAdressRepo
    {
        private readonly FoodApiDBContext _dbContext;
        public AdressRepo(FoodApiDBContext dBContext) 
        { 
            _dbContext = dBContext;
        }
        public async Task<Adress> AddAdress(Adress adress)
        {
            await _dbContext.Adresses.AddAsync(adress);
            await _dbContext.SaveChangesAsync();

            return adress;
        }
        public async Task<Adress> UpdateAdress(Adress adress, Guid id)
        {
            Adress adressModel = await FindAdressByid(id);
            
            adressModel.Id = id;
            adressModel.CEP = adress.CEP;
            adressModel.AdressNumber = adress.AdressNumber;
            adressModel.Street = adress.Street;
            adressModel.ReceiverName = adress.ReceiverName;
            
            _dbContext.Update(adressModel);
            _dbContext.SaveChangesAsync();

            return adressModel;
        }

        public async Task<Adress> FindAdressByid(Guid id)
        {
            Adress adressM = await _dbContext.Adresses.FirstOrDefaultAsync(x => x.Id == id);
            if (adressM == null)
            {
                throw new Exception($"Adress ID: {id} Unknown!");
            }
            return adressM;
        }

        public async Task<List<Adress>> FindAdress(Guid userId)
        {
            return await _dbContext.Adresses
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteAdress(Guid adressId)
        {
            Adress adressModel = await FindAdressByid(adressId);

            _dbContext.Adresses.Remove(adressModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
