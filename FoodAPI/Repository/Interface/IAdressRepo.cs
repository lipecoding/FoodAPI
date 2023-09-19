using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IAdressRepo
    {
        Task<List<Adress>> FindAdress(Guid userId);
        Task<Adress> AddAdress(Adress adress);
        Task<Adress> UpdateAdress(Adress adress, Guid id);
        Task<bool> DeleteAdress(Guid adressId);
        Task<Adress> FindAdressByid(Guid id);
    }
}
