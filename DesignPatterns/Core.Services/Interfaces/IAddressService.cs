using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Data;

namespace Core.Services.Interfaces
{
    public interface IAddressService
    {
        Task<List<ShippingAddress>> GetAddressByCustomerId(string CustomerId, string AddressType);
        Task<ShippingAddress> GetAddressDetails(int AddressId);
        Task<ResponseModel> AddAddress(ShippingAddress model);
        Task<ResponseModel> UpdateAddress(int AddressId, ShippingAddress model);
        Task<ResponseModel> DeleteAddress(ShippingAddress model);
    }
}
