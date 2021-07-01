using AutoMapper;
using Common.Data;
using Common.Models;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ColorService
{
    public class ColorService : ControllerBase, IColorService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ColorService> _logger;
        private readonly IMapper _mapper;

        public ColorService(ApplicationDbContext context, ILogger<ColorService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("Hello world");
        }

        public async Task<ActionResult<ColorViewModel>> AddColor(Color color)
        {

            _logger.LogError("Nlog injected into color service");
            _logger.LogInformation("Hello world");
            _logger.LogWarning("test warning");
            _logger.LogTrace("hehe");
            if (ColorExistsByName(color.Name))
            {
                return NoContent();
            }
            _context.Color.Add(color);
            await _context.SaveChangesAsync();

            ColorViewModel result = _mapper.Map<ColorViewModel>(color);

            return Created("test",result);
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

        public async Task<IActionResult> DeleteColorById(int id)
        {
            var color = await _context.Color.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Color.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public Task<IActionResult> DeleteColorByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> EditColorById(int id, Color color)
        {
            if (id != color.ID)
            {
                return BadRequest();
            }

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
            _logger.LogError("error log");
            _logger.LogInformation("info log");
            _logger.LogWarning("warning log");
            _logger.LogTrace("trace log");
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
            var result = await _context.Color.FindAsync(id);
            if (result == null)
                return NotFound();
            return result;
        }

        public async Task<ActionResult<Color>> GetColorByName(string name)
        {
            return await _context.Color.Where(c => c.Name.Contains(name)).FirstOrDefaultAsync();
        }
    }
}
