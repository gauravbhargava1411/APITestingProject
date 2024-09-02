using ApiTest.Entity.Models;
using ApiTest.Entity;

namespace ApiTest.Contracts.Services
{
    public class ProductServices : IProductService
    {
        private readonly AppDbContext _context;
        public ProductServices(AppDbContext appDbContext) 
        {
            this._context = appDbContext;
        }

        public bool CreateProduct(Product product)
        {
            _context.Insert(product);
            return true;
        }
        

        public Product GetProduct(int id)
        {
            return _context.Get(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.GetAll();
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            _context.Delete(id);
            return true;
        }
    }
}
