using FoodAPI.Model; 

namespace FoodAPI.Repository.Interface
{
    public interface IDelivererMotorcicleRepo
    {
        Task<DelivererMotorcicle> FindById(Guid id);
        Task<DelivererMotorcicle> FindByUserId(Guid userId);
        Task<List<DelivererMotorcicle>> FindAllMotorcicle();
        Task<DelivererMotorcicle> AddDelivererMotorcicle(DelivererMotorcicle model);
        Task<DelivererMotorcicle> UpdateDelivererMotorcicle(Guid id, DelivererMotorcicle model);
        Task<bool> DeleteDelivererMotorcicle(Guid id); 
    }
}