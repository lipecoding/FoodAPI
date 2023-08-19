using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IAdressRepo
    {
        Task<List<AdressModel>> GetAdresses(string userId);
        Task<AdressModel> AddAdress(AdressModel adress);
        Task<AdressModel> UpdateAdress(AdressModel adress);
        Task<AdressModel> DeleteAdress(string adressId);
    }
}
