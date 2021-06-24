using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services.ColorService;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //private readonly ColorService _colorService;
        private readonly IColorService _service;

        public ColorController(ApplicationDbContext context, IColorService service)
        {
            _context = context;
            _service = service;
        }




        // GET: api/Color
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorViewModel>>> GetColor()
        {
            //return await _context.Color.ProjectTo<ColorViewModel>.ToListAsync();
            return await _context.Color
                .Select(x => new ColorViewModel
                {
                    Id = x.ID,
                    Name = x.Name
                }).ToListAsync();
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            var color = await _context.Color.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
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
                if (!ColorExists(id))
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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Color
        ///     {
        ///         "name": "Red"
        ///     }
        /// </remarks>
        /// <param name="color" hide="true"></param>
        /// <returns>A newly created color</returns>
        /// <response code="201" examples="{'application/json' : {'id' : 0, 'name' : 'string'}}">Returns the newly created item</response>
        /// <response code="204">If name item is exists</response>
        /// <response code="400">If the name field is null or not string</response>
        // POST: api/Color
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<ColorViewModel> PostColor(Color color)
        {
            return _service.AddColor(color).Result;
        }

        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
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

        private bool ColorExists(int id)
        {
            return _context.Color.Any(e => e.ID == id);
        }
    }
}
