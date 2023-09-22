using FoodAPI.Model;

namespace FoodAPI.Repository.Interface
{
    public interface IAddressRepo
    {
        Task<List<Address>> FindAddress(Guid userId);
        Task<Address> AddAddress(Address address);
        Task<Address> UpdateAddress(Address address, Guid id);
        Task<bool> DeleteAddress(Guid addressId);
        Task<Address> FindAddressByid(Guid id);
    }
}
