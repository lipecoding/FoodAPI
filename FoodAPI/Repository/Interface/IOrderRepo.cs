using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IOrderRepo
    {
        public Task<Order> GetOrder(Guid id);
        public Task<List<Order>> GetOrdersByUserId(Guid userId);
        public Task<List<Order>> GetOrdersByCompanyId(Guid companyId);
        public Task<List<Order>> GetOrdersByCouponId(Guid couponId);
        public Task<List<Order>> GetOrdersByDelivererId(Guid delivererId);
        public Task<List<Order>> GetOrdersByMenuId(Guid menuId);
        public Task<Order> UpdateOrderStatus(Guid id, Guid status);
        public Task<Order> AddOrder(Order order);
        public Task<Order> UpdateOrder(Order order, Guid id);
        public Task<bool> DeleteOrder(Guid id);
    }
}
