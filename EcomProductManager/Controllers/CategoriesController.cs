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
    public class CategoriesController : ControllerBase
    {
        private readonly EcomProductManagerDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(EcomProductManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategory()
        {
            List<Category> categories =  await _context.Category.ToListAsync();
            List<CategoryResponse> categoryResponses = new List<CategoryResponse>();
            foreach(var category in categories)
            {
                category.Products = _context.Product.Where( p => p.CategoryId == category.Id).ToList();
                CategoryResponse categoryResponse = new CategoryResponse();
                _mapper.Map(category,categoryResponse);
                categoryResponses.Add(categoryResponse);
            }
            return categoryResponses;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> PutCategory(int id, CategoryRequests categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category category = await _context.Category.FindAsync(id);
            _mapper.Map(categoryRequest, category);
            _context.Category.Update(category);

            await _context.SaveChangesAsync();
            return CreatedAtAction("PutCategory", category); ;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryRequests categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category category = new Category()
            {
                CategoryName = categoryRequest.CategoryName,
                DisplayOrder = categoryRequest.DisplayOrder,
            };
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("DeleteCategory", category);
        }
    }
}
