using FoodAPI.Data;
using FoodAPI.Model;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repository
{
    public class AddressRepo : IAddressRepo
    {
        private readonly FoodApiDBContext _dbContext;
        public AddressRepo(FoodApiDBContext dBContext) 
        { 
            _dbContext = dBContext;
        }
        public async Task<Address> AddAddress(Address address)
        {
            await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();

            return address;
        }
        public async Task<Address> UpdateAddress(Address address, Guid id)
        {
            Address addressModel = await FindAddressByid(id);
            
            addressModel.Id = id;
            addressModel.CEP = address.CEP;
            addressModel.AddressNumber = address.AddressNumber;
            addressModel.Complement = address.Complement;
            addressModel.Street = address.Street;
            addressModel.ReceiverName = address.ReceiverName;
            
            _dbContext.Update(addressModel);
            _dbContext.SaveChangesAsync();

            return addressModel;
        }

        public async Task<Address> FindAddressByid(Guid id)
        {
            Address addressM = await _dbContext.Address.Where(x => x.Id == id).Include("User").FirstOrDefaultAsync();
            if (addressM == null)
            {
                throw new Exception($"Address ID: {id} Unknown!");
            }
            return addressM;
        }

        public async Task<List<Address>> FindAddress(Guid userId)
        {
            return await _dbContext.Address
                .Where(x => x.UserId == userId)
                .Include("User")
                .ToListAsync();
        }

        public async Task<bool> DeleteAddress(Guid addressId)
        {
            Address addressModel = await FindAddressByid(addressId);

            _dbContext.Address.Remove(addressModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
