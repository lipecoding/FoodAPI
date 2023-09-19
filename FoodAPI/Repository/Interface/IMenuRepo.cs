using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IMenuRepo
    {
        Task<List<Menu>> FindAllItens(Guid companyId);
        Task<Menu> FindItemByID(Guid id);
        Task<List<Menu>> FindItensByName(string name);
        Task<List<Menu>> FindItensByCategorie(string categorie);
        Task<Menu> AddItem(Menu model);
        Task<Menu> UpdateItem(Menu model, Guid id);
        Task<bool> DeleteItem(Guid id);
    }
}
