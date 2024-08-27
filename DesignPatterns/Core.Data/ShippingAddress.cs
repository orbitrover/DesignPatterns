using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class ShippingAddress
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string AddressDetails { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsDefaultAddress { get; set; }
        public AddressType addressType { get; set; }
    }
    public enum AddressType
    {
        Home,
        Office,
        Other
    }
}
