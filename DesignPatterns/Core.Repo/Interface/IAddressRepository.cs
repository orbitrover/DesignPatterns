using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repo.Interface
{
    public interface IAddressRepository
    {
        Task<List<ShippingAddress>> GetAddressByCustomerId(string CustomerId, string AddressType);
        Task<ShippingAddress> GetAddressDetails(int AddressId);
        Task<ResponseModel> AddAddress(ShippingAddress model);
        Task<ResponseModel> UpdateAddress(int AddressId, ShippingAddress model);
        Task<ResponseModel> DeleteAddress(ShippingAddress model);
    }
}
