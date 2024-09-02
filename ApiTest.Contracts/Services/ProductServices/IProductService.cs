using ApiTest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Contracts.Services
{
    public interface IProductService
    {
        public bool CreateProduct(Product product);
        public Product GetProduct(int id);
        public IEnumerable<Product> GetProducts();
        public bool UpdateProduct(Product product);

        public bool DeleteProduct(int id);
    }
}
