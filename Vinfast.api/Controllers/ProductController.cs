using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vinfast.api.Models;
using Microsoft.AspNetCore.Http;
using Vinfast.models;

namespace Vinfast.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await productRepository.GetProduct(id);
                if (result == null) return NotFound();
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product) 
        {
            try
            {
                if (product == null)
                    return BadRequest();

                var createdProduct = await productRepository.Addproduct(product);

                return CreatedAtAction(nameof(GetProduct),
                    new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Lỗi khi tạo bản ghi mới");
            }
        }
        /*
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                var emp = productRepository.GetProductByName(product.Name);

                if (emp != null)
                {
                    ModelState.AddModelError("Tên", "Tên sản phẩm đã được sử dụng!");
                    return BadRequest(ModelState);
                }

                var createProduct = await productRepository.AddProduct(product);

                return CreatedAtAction(nameof(GetProduct), new { id = createProduct.ProductId },
                    createProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        */
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var productDelete = await productRepository.GetProduct(id);

                if (productDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await productRepository.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
