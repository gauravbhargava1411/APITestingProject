using ApiTest.Contracts.Services;
using ApiTest.Entity;
using ApiTest.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace APITest.Testing
{
    public class ProductTest : IDisposable
    {
        private IProductService _productService;

        
        private AppDbContext _appDbContext;
        DbContextOptions<AppDbContext> options = new DbContextOptions<AppDbContext>();

        public void Dispose()
        {
            
        }

        [SetUp]
        public void Setup()
        {
            _appDbContext = new AppDbContext(options);
            _productService = new ProductServices(_appDbContext);

            var mockData = new Product
            {
                Id = 1,
                Name = "LUX",
                Price = 120,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _productService.CreateProduct(mockData);

            var mockData2 = new Product
            {
                Id = 2,
                Name = "LUX1",
                Price = 140,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _productService.CreateProduct(mockData2);
        }

        [Test]
        public void GetProduct()
        {           

            var result = _productService.GetProduct(1);
            Assert.IsNotEmpty(result.Name);
            Assert.Pass("Test case passed.");

        }

        [Test]
        public void GetProducts()
        {
            var result = _productService.GetProducts();
            Assert.IsNotEmpty(result);
            Assert.Pass("Test case passed.");
        }

        [Test]
        public void UpdateProduct()
        {
            var mockData2 = new Product
            {
                Id = 2,
                Name = "LUX12",
                Price = 1400,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            var result = _productService.UpdateProduct(mockData2);
            var result2 = _productService.GetProduct(2);

            Assert.IsTrue(result);
            Assert.IsNotEmpty(result2.Name);
            Assert.AreEqual(1400, result2.Price);
            Assert.Pass("Test case passed.");
        }

        [Test]
        public void DeleteProduct()
        {
            var mockData2 = new Product
            {
                Id = 21,
                Name = "LUX12",
                Price = 1400,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            var result = _productService.CreateProduct(mockData2);
            var result2 = _productService.DeleteProduct(21);
            var result3 = _productService.GetProduct(21);

            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.IsNull(result3);           
            Assert.Pass("Test case passed.");
            
        }



    }
}