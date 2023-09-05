using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IDelivererRepo
    {
        Task<DelivererModel> FindById(int id);
        Task<List<DelivererModel>> FindAll();
        Task<DelivererModel> AddDeliverer(DelivererModel model);
        Task<DelivererModel> UpdateDeliverer(int id, DelivererModel model);
        Task<bool> DeleteDeliverer(int id); 
    }
}
