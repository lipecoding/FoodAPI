namespace FoodAPI.Model
{
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