using ApiTest.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiTest.Entity
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //specify your connection
            Products = new List<Product>();
        }        

        public IList<Product> Products { get; set; }


        public Product Get(int id)
        {
            return Products.FirstOrDefault(itm => itm.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public bool Insert(Product product)
        {
            product.CreatedDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            Products.Add(product);
            return true;
        }

        public void Update(Product product)
        {
            var result = Products.Where(itm => itm.Id == product.Id).FirstOrDefault();
            result.Name = product.Name;
            result.Price = product.Price;
            product.UpdatedDate = DateTime.Now;            
        }

        public bool Delete(int id)
        {
            Products.Remove(Get(id));
            return true;
        }
        
    }
}
