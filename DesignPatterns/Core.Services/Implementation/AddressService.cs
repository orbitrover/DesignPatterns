using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using Core.Repo.Data;
using Microsoft.EntityFrameworkCore;
using Core.Repo.Interface;

namespace Core.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        public AddressService(IAddressRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<ShippingAddress>> GetAddressByCustomerId(string CustomerId, string AddressType)
        {
            var addressList = await _repo.GetAddressByCustomerId(CustomerId, AddressType);
            return addressList;
        }
        public async Task<ShippingAddress> GetAddressDetails(int AddressId)
        {
            var address = await _repo.GetAddressDetails(AddressId);
            return address;
        }
        public async Task<ResponseModel> AddAddress(ShippingAddress model)
        {
            return await _repo.AddAddress(model);
        }
        public async Task<ResponseModel> UpdateAddress(int AddressId, ShippingAddress model)
        {
            return await _repo.UpdateAddress(AddressId, model);
        }
        public async Task<ResponseModel> DeleteAddress(ShippingAddress model)
        {
            return await _repo.DeleteAddress(model);
        }
    }
}
