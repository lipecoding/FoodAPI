using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IDelivererRepo
    {
        Task<Deliverer> FindById(Guid id);
        Task<List<Deliverer>> FindAll();
        Task<Deliverer> AddDeliverer(Deliverer model);
        Task<Deliverer> UpdateDeliverer(Guid id, Deliverer model);
        Task<bool> DeleteDeliverer(Guid id); 
    }
}
