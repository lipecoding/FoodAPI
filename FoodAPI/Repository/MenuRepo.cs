using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repository
{
    public class MenuRepo : IMenuRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public MenuRepo(FoodApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MenuModel> AddItem(MenuModel model)
        {
            await _dbContext.Menu.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteItem(int id)
        {
            MenuModel item = await FindItemByID(id);

            _dbContext.Menu.Remove(item);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<MenuModel>> FindAllItens(int companyId)
        {
            List<MenuModel> itemList = await _dbContext.Menu.Where(x => x.CompanyId == companyId).ToListAsync();

            if (itemList == null)
            {
                throw new Exception($"COMPANY ID: {companyId} Unknown!");
            }

            return itemList;
        }

        public async Task<MenuModel> FindItemByID(int id)
        {
            MenuModel item = await _dbContext.Menu.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new Exception($"ITEM ID: {id} Unknown!");
            }
            return item;
        }

        public async Task<List<MenuModel>> FindItensByName(string name)
        {
            return await (from menu in _dbContext.Menu
                          where menu.Name.Contains(name)
                          select menu).ToListAsync();

        }

        public async Task<List<MenuModel>> FindItensByCategorie(string categorie)
        {
            return await (from menu in _dbContext.Menu
                          where menu.Categories.Contains(categorie)
                          select menu).ToListAsync();
        }

        public async Task<MenuModel> UpdateItem(MenuModel model, int id)
        {
            await FindItemByID(id);

            model.Id = id;

            _dbContext.Menu.Update(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }
    }
}
