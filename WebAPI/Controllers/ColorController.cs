using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Common.Data;
using Common.Models;
using Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.ColorService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorController(IColorService service)
        {
            _service = service;
        }

        // GET: api/Color
        [HttpGet]
        public Task<ActionResult<IEnumerable<ColorViewModel>>> GetColor()
        {
            return _service.GetAllColor();
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public ActionResult<Color> GetColor(int id)
        {
            var color = _service.GetColorById(id);

            if (color.Result == null)
                return NotFound();

            return color.Result;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutColor(int id, Color color)
        {
            return null;
            //if (id != color.ID)
            //{
            //    return BadRequest();
            //}

            //var result = _service.EditColorById(id, color);
            //if (result.Result == false)
            //    return NotFound();
            //return NoContent();
            
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
        /// <response code="201" examples="{'application/json' : {'name' : 'string'}}">Returns the newly created item</response>
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
        public IActionResult DeleteColor(int id)
        {
            //var result = _service.DeleteColorById(id);
            //if (!result.Result)
            //    return NotFound();
            //return NoContent();
            return null;
            //var color = await _context.Color.FindAsync(id);
            //if (color == null)
            //{
            //    return NotFound();
            //}

            //_context.Color.Remove(color);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

    }
}
