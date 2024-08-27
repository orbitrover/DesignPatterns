using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.StructuralPatterns.Proxy
{
    public interface IProductData
    {
        string GetProductDetails();
    }

    public class RealProductData : IProductData
    {
        private string _productDetails;

        public RealProductData()
        {
            // Simulate expensive operation
            _productDetails = "Detailed product information";
        }

        public string GetProductDetails() => _productDetails;
    }

    public class ProductDataProxy : IProductData
    {
        private RealProductData _realProductData;

        public string GetProductDetails()
        {
            if (_realProductData == null)
            {
                _realProductData = new RealProductData();
            }
            return _realProductData.GetProductDetails();
        }
    }

}
