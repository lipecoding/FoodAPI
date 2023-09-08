using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Model
{
    [Index(nameof(DelivererId), nameof(Renavam), nameof(Placa), Name = "Index_Motorcicle")]
    public class DelivererMotorcicleModel
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Marca { get; set; }
        public int DelivererId { get; set; }
        public virtual DelivererModel Deliverer { get; set; } 
        public string? Error { get; set; }
    }
}