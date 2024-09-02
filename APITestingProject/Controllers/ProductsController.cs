using Microsoft.AspNetCore.Mvc;
using System.Net;
using ApiTest.Contracts.Services;
using ApiTest.Entity.Models;


///<summary>
///APITesting API Controller for product
///</summary>

namespace APITestingProject.Controllers 
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {

        private IProductService _productService;        

        public ProductsController(IProductService productService)
        {            
            this._productService = productService;
        }

        [HttpPost(Name = "CreateProduct")]        
        public ActionResult<HttpResponseMessage> CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("Product should not be null.") };
                }

                var result = _productService.GetProduct(product.Id);

                if (result != null)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("Products is alrady exist.") };
                }

                _productService.CreateProduct(product);
                

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Product has inserted scussfully.")
                };

                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Exception :" + ex.StackTrace)
                };
                return response;
            }
        }

        

        [HttpGet(Name = "GetProduct")]        
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,"id should not be null or zero");
                }
                var result = _productService.GetProduct(id);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No record found.");
                }                

                return Ok(result);    
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Exception :" + ex.StackTrace)
                };
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }



        [HttpGet(Name = "GetProducts")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var result = _productService.GetProducts();

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Product inserted scussfully.")
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Exception :" + ex.StackTrace)
                };
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPatch(Name = "UpdateProduct")]    
        public ActionResult<HttpResponseMessage> UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("Product should not be null") };
                }

                var result = _productService.GetProduct(product.Id);

                if (result == null)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden, Content = new StringContent("Product does not exist.") };
                }

                _productService.UpdateProduct(product);

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Product has updated scussfully.")
                };

                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Exception :" + ex.StackTrace)
                };
                return response;
            }
            
        }


        [HttpDelete(Name = "DeleteProduct")]       
        public ActionResult<HttpResponseMessage> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("Product id should not be null or zero") };
                }

                var result = _productService.GetProduct(id);

                if (result == null)
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden, Content = new StringContent("Products does not exist.") };
                }

                _productService.DeleteProduct(id);

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent("Product updated scussfully.")
                };

                return response;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                {
                    Content = new StringContent("Exception :" + ex.StackTrace)
                };
                return response;
            }

        }

    }
}
