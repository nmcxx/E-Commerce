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
    public class ColorController 
    {
        private readonly IColorService _service;

        public ColorController(IColorService service)
        {
            _service = service;
        }
        
        

        /// <summary>
        /// 
        /// </summary>
        /// <param></param>
        /// <returns>All color</returns>
        /// <response code="200">Returns all item</response>
        // GET: api/Color
        [HttpGet]
        public Task<ActionResult<IEnumerable<ColorViewModel>>> GetColor()
        {
            return _service.GetAllColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id" hidden="true"></param>
        /// <returns>Returns a single color</returns>
        /// <response code="200">Returns a single color</response>
        /// <response code="404" examples="hide">If id color is not found</response>
        // GET: api/Color/5
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public Task<ActionResult<Color>> GetColor(int id)
        {
            return _service.GetColorById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/Color
        ///     {
        ///         "id": 0,
        ///         "name": "Red"
        ///     }
        /// </remarks>
        /// <param name="id" hide="true"></param>
        /// <param name="color"></param>
        /// <body examples="{'application/json' : {'id' : 0,'name' : 'string'}}"></body>
        /// <returns>A updated color</returns>
        /// <response code="204">if the color has updated</response>
        /// <response code="404" examples="hide">If id color is not found</response>
        /// <response code="400">If the id param is does not match id color</response>
        // PUT: api/Color/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public Task<IActionResult> PutColor(int id, Color color)
        {
            return _service.EditColorById(id, color);
            
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
        /// <param name="color" hidden="true"></param>
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
        public Task<ActionResult<ColorViewModel>> PostColor(Color color)
        {
            return _service.AddColor(color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A deleted color</returns>
        /// <response code="204">if the color has deleted</response>
        /// <response code="404" examples="hide">If id color is not found</response>
        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public Task<IActionResult> DeleteColor(int id)
        {
            return _service.DeleteColorById(id);
        }

    }
}
