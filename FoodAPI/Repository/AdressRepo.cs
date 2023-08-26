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
        public async Task<AdressModel> AddAdress(AdressModel adress)
        {
            await _dbContext.Adresses.AddAsync(adress);
            await _dbContext.SaveChangesAsync();

            return adress;
        }
        public async Task<AdressModel> UpdateAdress(AdressModel adress, int id)
        {
            AdressModel adressModel = await FindAdressByid(id);
            
            adressModel.Id = id;
            adressModel.CEP = adress.CEP;
            adressModel.AdressNumber = adress.AdressNumber;
            adressModel.Street = adress.Street;
            adressModel.ReceiverName = adress.ReceiverName;
            
            _dbContext.Update(adressModel);
            _dbContext.SaveChangesAsync();

            return adressModel;
        }

        public async Task<AdressModel> FindAdressByid(int id)
        {
            AdressModel adressM = await _dbContext.Adresses.FirstOrDefaultAsync(x => x.Id == id);
            if (adressM == null)
            {
                throw new Exception($"Adress ID: {id} Unknown!");
            }
            return adressM;
        }

        public async Task<List<AdressModel>> FindAdress(int userId)
        {
            return await _dbContext.Adresses
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteAdress(int adressId)
        {
            AdressModel adressModel = await FindAdressByid(adressId);

            _dbContext.Adresses.Remove(adressModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
