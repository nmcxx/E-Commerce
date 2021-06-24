using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly  ApplicationDbContext _context;

        public ColorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ColorViewModel> AddColor(Color color)
        {
            //color.ID = 0;
            if(!ColorExistsByName(color.Name))
            {
                return null;
            }
            System.Diagnostics.Debug.WriteLine(GetColorByName(color.Name).Result.Name.ToString().Length==0);
            _context.Color.Add(color);
            await _context.SaveChangesAsync();


            ColorViewModel result = new ColorViewModel
            {
                Id = color.ID,
                Name = color.Name
            };

            return result;
        }

        public bool ColorExistsById(int id)
        {
            return _context.Color.Any(e => e.ID == id);
        }

        public bool ColorExistsByName(string name)
        {
            var a = _context.Color.Any(e => e.Name.Contains(name));
            return a;
        }

        public Task<bool> DeleteColor(Color color)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteColorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteColorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Color> EditColorById(int id, Color color)
        {
            throw new NotImplementedException();
        }

        public Task<Color> EditColorByName(string name, Color color)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Color>> GetAllColor()
        {
            throw new NotImplementedException();
        }

        public Task<Color> GetColor(Color color)
        {
            throw new NotImplementedException();
        }

        public Task<Color> GetColorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Color> GetColorByName(string name)
        {
            var color = await _context.Color.Where(c => c.Name.Contains(name)).FirstOrDefaultAsync();

            return color;
            //throw new NotImplementedException();
        }
    }
}
