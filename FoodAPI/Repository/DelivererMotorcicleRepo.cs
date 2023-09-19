using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodAPI.Repository
{
    public class DelivererMotorcicleRepo : IDelivererMotorcicleRepo
    {
        private readonly FoodApiDBContext _dbContext;

        public DelivererMotorcicleRepo (FoodApiDBContext dBContext){
            
            _dbContext = dBContext;
        }


        public async Task<DelivererMotorcicle> AddDelivererMotorcicle(DelivererMotorcicle model)
        {
            if(_dbContext.DelivererMotorcicle.Where(x => x.Plate == model.Plate).Any())
            {
                model.Error = "Already exists one Motorcicle with this Placa!";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.Renavam == model.Renavam).Any())
            {
                model.Error = "Already exists one Motorcicle with this Renavam Code";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.DelivererId == model.DelivererId).Any())
            {
                model.Error = "Already exists one Motorcicle with this DelivererId";
            }
            if(model.Error.IsNullOrEmpty())
            {
                await _dbContext.DelivererMotorcicle.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            return model;
        }

        public async Task<bool> DeleteDelivererMotorcicle(Guid id)
        {
            DelivererMotorcicle model = await FindById(id);

            _dbContext.DelivererMotorcicle.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DelivererMotorcicle>> FindAllMotorcicle()
        {
            return await _dbContext.DelivererMotorcicle.ToListAsync();
        }

        public async Task<DelivererMotorcicle> FindById(Guid id)
        {
            return await _dbContext.DelivererMotorcicle.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DelivererMotorcicle> FindByUserId(Guid DelivererId)
        {
            return await _dbContext.DelivererMotorcicle.FirstOrDefaultAsync(x => x.DelivererId == DelivererId);
        }

        public async Task<DelivererMotorcicle> UpdateDelivererMotorcicle(Guid id, DelivererMotorcicle model)
        {
            DelivererMotorcicle DelivererMotorcicle = await FindById(id);

            DelivererMotorcicle.Plate = model.Plate;

            if(_dbContext.DelivererMotorcicle.Where(x => x.Plate == model.Plate).Any())
                DelivererMotorcicle.Error = "Already exists one Motorcicle with this Placa!";
            else
                DelivererMotorcicle.Plate = model.Plate;

            if (_dbContext.DelivererMotorcicle.Where(x => x.Renavam == model.Renavam).Any())   
                DelivererMotorcicle.Error = "Already exists one Motorcicle with this Renavam Code" ;
            else
                DelivererMotorcicle.Renavam = model.Renavam;
                
            DelivererMotorcicle.Year = model.Year;
            DelivererMotorcicle.Brand = model.Brand;
            DelivererMotorcicle.Model = model.Model;

            _dbContext.DelivererMotorcicle.Update(DelivererMotorcicle);
            await _dbContext.SaveChangesAsync();    

            return DelivererMotorcicle;

        }

    }
}