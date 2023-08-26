using FoodAPI.ENUM;

namespace FoodAPI.Model
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CNPJ { get; set; }
        public CompanyTypeEnum Type { get; set; }
        public CompanyPlanEnum Plan { get; set; }
        public string Error { get; set; }
    }
}
