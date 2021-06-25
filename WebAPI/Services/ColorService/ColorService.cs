using Common.Data;
using Common.Models;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ColorService
{
    public class ColorService : ControllerBase, IColorService
    {
        private readonly  ApplicationDbContext _context;

        public ColorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ColorViewModel>> AddColor(Color color)
        {
            if (ColorExistsByName(color.Name))
            {
                //System.Diagnostics.Debug.WriteLine(GetColorByName(color.Name).Result.Name.ToString());
                return null;
            }
            _context.Color.Add(color);
            await _context.SaveChangesAsync();


            ColorViewModel result = new ColorViewModel
            {
                Id = color.ID,
                Name = color.Name
            };

            return result;
            //return CreatedAtAction("GetColorById", new { id = product.ID }, product);
        }

        public bool ColorExistsById(int id)
        {
            return _context.Color.Any(e => e.ID == id);
        }

        public bool ColorExistsByName(string name)
        {
            return _context.Color.Any(e => e.Name.Contains(name));
        }

        public Task<IActionResult> DeleteColor(Color color)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteColorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteColorByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> EditColorById(int id, Color color)
        {
            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExistsById(id))
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

        public Task<IActionResult> EditColorByName(string name, Color color)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<ColorViewModel>>> GetAllColor()
        {
            return await _context.Color
               .Select(x => new ColorViewModel
               {
                   Id = x.ID,
                   Name = x.Name
               }).ToListAsync();
        }

        public async Task<ActionResult<Color>> GetColor(Color color)
        {
            return await _context.Color.FindAsync(color);
        }

        public async Task<ActionResult<Color>> GetColorById(int id)
        {
            return await _context.Color.FindAsync(id);
        }

        public async Task<ActionResult<Color>> GetColorByName(string name)
        {
            return await _context.Color.Where(c => c.Name.Contains(name)).FirstOrDefaultAsync();
        }
    }
}
