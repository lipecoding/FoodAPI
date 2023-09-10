using FoodAPI.Data;
using FoodAPI.Enum;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design;

namespace FoodAPI.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly FoodApiDBContext _dbContext;
        public OrderRepo(FoodApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrderModel> AddOrder(OrderModel order, List<OrderItensModel> itens)
        {
            if(_dbContext.Order.Where(x => x.Date == DateTime.Now && x.UserId == order.UserId).Any())
            {
                order.Error = "Already Exists this order.";
            }
            if(order.Error.IsNullOrEmpty())
            {
                order.Date = DateTime.Now;
                await _dbContext.Order.AddAsync(order);
                await _dbContext.OrderItens.AddRangeAsync(itens);
                await _dbContext.SaveChangesAsync();
            }
            return order;
            
        }

        public async Task<bool> DeleteOrder(int id)
        {
            OrderModel order = await GetOrder(id);
            _dbContext.Order.Remove(order);
            _dbContext.OrderItens.RemoveRange(order.Itens);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            OrderModel order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            return order;
        }

        public async Task<List<OrderModel>> GetOrdersByCompanyId(int companyId)
        {
            return await (from Order in _dbContext.Order
                          join Company in _dbContext.Company
                          on Order.Id equals Company.Id
                          where  Company.Id == companyId
                          select Order).ToListAsync();
        }

        public async Task<List<OrderModel>> GetOrdersByCouponId(int couponId)
        {
            return await(from Order in _dbContext.Order
                         join Coupon in _dbContext.Coupon
                         on Order.Id equals Coupon.Id
                         where Coupon.Id == couponId
                         select Order).ToListAsync();   
        }

        public async Task<List<OrderModel>> GetOrdersByDelivererId(int delivererId)
        {
            return await(from Order in _dbContext.Order
                         join Deliverer in _dbContext.Deliverer
                         on Order.Id equals Deliverer.Id
                         where Deliverer.Id == delivererId
                         select Order).ToListAsync();
        }

        public async Task<List<OrderModel>> GetOrdersByMenuId(int menuId)
        {
            return await(from Order in _dbContext.Order
                         join Menu in _dbContext.Menu
                         on Order.Id equals Menu.Id
                         where Menu.Id == menuId
                         select Order).ToListAsync();
        }

        public async Task<List<OrderModel>> GetOrdersByUserId(int userId)
        {
            return await(from Order in _dbContext.Order
                         join User in _dbContext.User
                         on Order.Id equals User.Id
                         where User.Id == userId
                         select Order).ToListAsync();
        }

        public Task<OrderModel> UpdateOrder(OrderModel order, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> UpdateOrderStatus(int id, OrderStatusEnum status)
        {
            OrderModel order = await GetOrder(id);
            order.Status = status;
            _dbContext.Order.Update(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }
    }
}
