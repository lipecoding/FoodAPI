using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IMenuRepo
    {
        Task<List<MenuModel>> FindAllItens(int companyId);
        Task<MenuModel> FindItemByID(int id);
        Task<MenuModel> FindItemByName(string name);
        Task<List<MenuModel>> FindItensByCategorie(string categorie);
        Task<MenuModel> AddItem(MenuModel model);
        Task<MenuModel> UpdateItem(MenuModel model, int id);
        Task<bool> DeleteItem(int id);
    }
}
