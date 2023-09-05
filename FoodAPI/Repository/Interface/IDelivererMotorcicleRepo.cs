using FoodAPI.Model; 

namespace FoodAPI.Repository.Interface
{
    public interface IDelivererMotorcicleRepo
    {
        Task<DelivererMotorcicleModel> FindById(int id);
        Task<DelivererMotorcicleModel> FindByUserId(int userId);
        Task<List<DelivererMotorcicleModel>> FindAllMotorcicle();
        Task<DelivererMotorcicleModel> AddDelivererMotorcicle(DelivererMotorcicleModel model);
        Task<DelivererMotorcicleModel> UpdateDelivererMotorcicle(int id, DelivererMotorcicleModel model);
        Task<bool> DeleteDelivererMotorcicle(int id); 
    }
}