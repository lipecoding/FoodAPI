﻿using FoodAPI.Enum;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;
        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            Order orderM = await _orderRepo.AddOrder(order);

            return Ok(orderM);
        }
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            Order orderM = await _orderRepo.GetOrder(id);

            return Ok(orderM);
        }
        [HttpGet("GetOrdersByUserId/{userid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByUserId(Guid userid)
        {
            List<Order> orderM = await _orderRepo.GetOrdersByUserId(userid);

            return Ok(orderM);
        }
        [HttpGet("GetOrdersByCompanyId/{companyid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByCompanyId(Guid companyid)
        {
            List<Order> orderM = await _orderRepo.GetOrdersByCompanyId(companyid);

            return Ok(orderM);
        }
        [HttpGet("GetOrdersByCouponId/{couponid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByCouponId(Guid couponid)
        {
            List<Order> orderM = await _orderRepo.GetOrdersByCouponId(couponid);

            return Ok(orderM);
        }
        [HttpGet("GetOrdersByDelivererId/{delivererid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByDelivererId(Guid delivererid)
        {
            List<Order> orderM = await _orderRepo.GetOrdersByDelivererId(delivererid);

            return Ok(orderM);
        }
        [HttpGet("GetOrdersByDelivererId/{menuid}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByMenuId(Guid menuid)
        {
            List<Order> orderM = await _orderRepo.GetOrdersByMenuId(menuid);

            return Ok(orderM);
        }
        [HttpPut("UpdateOrderStatus/{id}")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(Guid id, OrderStatusEnum status)
        {
            Order orderM = await _orderRepo.UpdateOrderStatus(id, status);

            return Ok(orderM);
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(Guid id, OrderStatusEnum status)
        {
            bool del = await _orderRepo.DeleteOrder(id);

            return Ok(del);
        }
    }
}
