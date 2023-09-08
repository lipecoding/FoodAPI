using FoodAPI.ENUM;

namespace FoodAPI.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public PremiumEnum Premium { get; set; }
        public string? Error { get; set; }
    }
}
