using Core.Data;
using Core.Services.Interfaces;

namespace Core.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductService _repo;

        public ProductService(IProductService repo)
        {
            _repo = repo;
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _repo.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }
    }

}
