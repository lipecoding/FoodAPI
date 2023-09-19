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
        public async Task<Order> AddOrder(Order order)
        {
            order.Error = null;
            if(_dbContext.Order.Where(x => x.Date == DateTime.Now && x.UserId == order.UserId).Any())
            {
                order.Error = "Already Exists this order.";
            }
            if(order.Error.IsNullOrEmpty())
            {
                order.Date = DateTime.Now;
                await _dbContext.Order.AddAsync(order);
                await _dbContext.SaveChangesAsync();
            }
            return order;
            
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            Order order = await GetOrder(id);
            _dbContext.Order.Remove(order);
            _dbContext.OrderItens.RemoveRange(Itens(id));
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetOrder(Guid id)
        {
            Order order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            return order;
        }

        public async Task<List<Order>> GetOrdersByCompanyId(Guid companyId)
        {
            return await (from Order in _dbContext.Order
                          join Company in _dbContext.Company
                          on Order.Id equals Company.Id
                          where  Company.Id == companyId
                          select Order).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByCouponId(Guid couponId)
        {
            return await(from Order in _dbContext.Order
                         join Coupon in _dbContext.Coupon
                         on Order.Id equals Coupon.Id
                         where Coupon.Id == couponId
                         select Order).ToListAsync();   
        }

        public async Task<List<Order>> GetOrdersByDelivererId(Guid delivererId)
        {
            return await(from Order in _dbContext.Order
                         join Deliverer in _dbContext.Deliverer
                         on Order.Id equals Deliverer.Id
                         where Deliverer.Id == delivererId
                         select Order).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByMenuId(Guid menuId)
        {
            return await(from Order in _dbContext.Order
                         join Menu in _dbContext.Menu
                         on Order.Id equals Menu.Id
                         where Menu.Id == menuId
                         select Order).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(Guid userId)
        {
            return await(from Order in _dbContext.Order
                         join User in _dbContext.User
                         on Order.Id equals User.Id
                         where User.Id == userId
                         select Order).ToListAsync();
        }

        public Task<Order> UpdateOrder(Order order, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderStatus(Guid id, OrderStatusEnum status)
        {
            Order order = await GetOrder(id);
            order.Status = status;
            _dbContext.Order.Update(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        private List<Item> Itens(Guid id)
        {
            return _dbContext.OrderItens.Where(x => x.OrderId == id).ToList();
        }
    }
}
