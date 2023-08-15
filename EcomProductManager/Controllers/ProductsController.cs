using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcomProductManager.Data;
using EcomProductManager.Models;
using EcomProductManager.Requests;
using AutoMapper;
using EcomProductManager.Responses;

namespace EcomProductManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcomProductManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(EcomProductManagerDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProduct()
        {
            List<Product> products =  await _context.Product.ToListAsync();
            List<ProductResponse> productResponses = new List<ProductResponse>();
            foreach(var product in products)
            {
                product.Category = await _context.Category.FindAsync(product.Id);
                ProductResponse productResponse = new ProductResponse();
                _mapper.Map(product, productResponse);
                productResponses.Add(productResponse);
            }
            return productResponses;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, ProductRequests productRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product product = await _context.Product.FindAsync(id);
            
            _mapper.Map(productRequest, product);
            _context.Entry(product).State = EntityState.Modified;

             await _context.SaveChangesAsync();
            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductRequests productRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product product = new Product();
            _mapper.Map(productRequest, product);
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, productRequest);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("DeleteProduct", product);
        }
    }
}
