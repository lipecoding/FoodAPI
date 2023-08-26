namespace FoodAPI.Model
{
    public class AdressModel
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public int AdressNumber { get; set; }
        public string? Complement { get; set; }
        public string ReceiverName { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
