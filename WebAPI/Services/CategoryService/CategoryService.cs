using Common.Data;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.CategoryService
{
    public class CategoryService : ControllerBase, ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            if (CategoryExistsByName(category.Name))
            {
                return NoContent();
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return Created("test", category);
        }

        public bool CategoryExistsById(int id)
        {
            return _context.Category.Any(e => e.ID == id);
        }

        public bool CategoryExistsByName(string name)
        {
            return _context.Category.Any(e => e.Name.Contains(name));
        }

        public Task<IActionResult> DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public Task<IActionResult> DeleteCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> EditCategoryById(int id, Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExistsById(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public Task<IActionResult> EditCategoryByName(string name, Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            return await _context.Category.ToListAsync();
        }

        public Task<ActionResult<Category>> GetCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        public Task<ActionResult<Category>> GetCategoryByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
