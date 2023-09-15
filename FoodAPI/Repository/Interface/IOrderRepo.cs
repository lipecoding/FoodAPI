using FoodAPI.Enum;
using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IOrderRepo
    {
        public Task<OrderModel> GetOrder(int id);
        public Task<List<OrderModel>> GetOrdersByUserId(int userId);
        public Task<List<OrderModel>> GetOrdersByCompanyId(int companyId);
        public Task<List<OrderModel>> GetOrdersByCouponId(int couponId);
        public Task<List<OrderModel>> GetOrdersByDelivererId(int delivererId);
        public Task<List<OrderModel>> GetOrdersByMenuId(int menuId);
        public Task<OrderModel> UpdateOrderStatus(int id, OrderStatusEnum status);
        public Task<OrderModel> AddOrder(OrderModel order);
        public Task<OrderModel> UpdateOrder(OrderModel order, int id);
        public Task<bool> DeleteOrder(int id);
    }
}
