namespace FoodAPI.Model
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public virtual CompanyModel Company { get; set; }
        public string? Error { get; set; }
    }
}
