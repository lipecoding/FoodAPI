using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IAdressRepo
    {
        Task<List<AdressModel>> FindAdress(int userId);
        Task<AdressModel> AddAdress(AdressModel adress);
        Task<AdressModel> UpdateAdress(AdressModel adress, int id);
        Task<bool> DeleteAdress(int adressId);
        Task<AdressModel> FindAdressByid(int id);
    }
}
