using FoodAPI.ENUM;

namespace FoodAPI.Model
{
    public class UserCouponModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ItemID { get; set; }
        public int Value { get; set; }
        public VTypeEnum V_Type { get; set; }
        public CompanyTypeEnum Categorie { get; set; }
        public int? UserID { get; set;}
        public virtual UserModel? User { get; set; }
        public PremiumEnum Premium { get; set; }
    }
}
