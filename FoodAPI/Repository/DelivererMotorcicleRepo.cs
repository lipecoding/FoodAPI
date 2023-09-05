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


        public async Task<DelivererMotorcicleModel> AddDelivererMotorcicle(DelivererMotorcicleModel model)
        {
            if(_dbContext.DelivererMotorcicle.Where(x => x.Marca == model.Marca).Any())
            {
                model.Error = "Already exists one Deliverer with this Email!";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.Modelo == model.Modelo).Any())
            {
                model.Error = "Already exists one Deliverer with this Modelo!";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.Ano == model.Ano).Any())
            {
                model.Error = "Already exists one Deliverer with this Ano!";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.Placa == model.Placa).Any())
            {
                model.Error = "Already exists one Deliverer with this Placa!";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.Renavam == model.Renavam).Any())
            {
                model.Error = "Already exists one Deliverer with this Renavam Code";
            }
            if(_dbContext.DelivererMotorcicle.Where(x => x.DelivererId == model.DelivererId).Any())
            {
                model.Error = "Already exists one Deliverer with this DelivererId";
            }
            if(model.Error.IsNullOrEmpty())
            {
                await _dbContext.DelivererMotorcicle.AddAsync(model);
                await _dbContext.SaveChangesAsync();
            }
            return model;
        }

        public async Task<bool> DeleteDelivererMotorcicle(int id)
        {
            DelivererMotorcicleModel model = await FindById(id);

            _dbContext.DelivererMotorcicle.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<DelivererMotorcicleModel>> FindAllMotorcicle()
        {
            return await _dbContext.DelivererMotorcicle.ToListAsync();
        }

        public async Task<DelivererMotorcicleModel> FindById(int id)
        {
            return await _dbContext.DelivererMotorcicle.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DelivererMotorcicleModel> FindByUserId(int DelivererId)
        {
            return await _dbContext.DelivererMotorcicle.FirstOrDefaultAsync(x => x.DelivererId == DelivererId);
        }

        public async Task<DelivererMotorcicleModel> UpdateDelivererMotorcicle(int id, DelivererMotorcicleModel model)
        {
            DelivererMotorcicleModel DelivererMotorcicle = await FindById(id);

            DelivererMotorcicle.Placa = model.Placa;

            if(_dbContext.DelivererMotorcicle.Where(x => x.Placa == model.Placa).Any())
                DelivererMotorcicle.Error = "Already exists one Motorcicle with this Placa!";
            else
                DelivererMotorcicle.Placa = model.Placa;

            if (_dbContext.DelivererMotorcicle.Where(x => x.Renavam == model.Renavam).Any())   
                DelivererMotorcicle.Error = "Already exists one Motorcicle with this Renavam Code" ;
            else
                DelivererMotorcicle.Renavam = model.Renavam;
                
            DelivererMotorcicle.Ano = model.Ano;
            DelivererMotorcicle.Marca = model.Marca;
            DelivererMotorcicle.Modelo = model.Modelo;

            _dbContext.DelivererMotorcicle.Update(DelivererMotorcicle);
            await _dbContext.SaveChangesAsync();    

            return DelivererMotorcicle;

        }

    }
}