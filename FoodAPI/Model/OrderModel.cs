using FoodAPI.Enum;

namespace FoodAPI.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }
        public int CouponId { get; set; }
        public virtual CouponModel Coupon { get; set; }
        public int DelivererId { get; set; }
        public virtual DelivererModel Deliverer { get; set; }
        public int AdressId { get; set; }
        public virtual AdressModel Adress { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public virtual List<OrderItensModel> Itens { get; set; }
        public OrderStatusEnum Status { get; set; }
        public string? Error { get; set; }
    }
}
