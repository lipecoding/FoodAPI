using System.Text.Json.Serialization;

namespace FoodAPI.Model
{
    public class OrderItensModel
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public virtual MenuModel Menu { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public virtual OrderModel Order { get; set; }
    }
}
