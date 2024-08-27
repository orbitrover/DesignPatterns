using Core.Data;
using Core.Repo.Data;
using Core.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repo.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ShippingAddress>> GetAddressByCustomerId(string CustomerId, string AddressType)
        {
            var addressList = await _context.ShippingAddress
                 .Where(x => x.CustomerId == CustomerId && x.addressType.ToString() == AddressType)
                 .ToListAsync();
            return addressList;
        }
        public async Task<ShippingAddress> GetAddressDetails(int AddressId)
        {
            var address = await _context.ShippingAddress
                .Where(x => x.Id == AddressId)
                .SingleOrDefaultAsync();
            return address;
        }
        public async Task<ResponseModel> AddAddress(ShippingAddress model)
        {
            _context.ShippingAddress.Add(model);
            await _context.SaveChangesAsync();
            return new ResponseModel { ResponseCode = 200, ResponseMessage="Success" };
        }
        public async Task<ResponseModel> UpdateAddress(int AddressId, ShippingAddress model)
        {
            var address = await _context.ShippingAddress
                .Where(x => x.Id == AddressId)
                .SingleOrDefaultAsync();
            if (address != null)
            {
                _context.ShippingAddress.Update(model);
                await _context.SaveChangesAsync();
            }
            return new ResponseModel { ResponseCode = 200, ResponseMessage = "Success" };
        }
        public async Task<ResponseModel> DeleteAddress(ShippingAddress model)
        {
            var address = await _context.ShippingAddress
                .Where(x => x.Id == model.Id)
                .SingleOrDefaultAsync();
            if (address != null)
            {
                _context.ShippingAddress.Remove(model);
                await _context.SaveChangesAsync();
            }
            return new ResponseModel { ResponseCode = 200, ResponseMessage = "Success" };
        }
    }
}
