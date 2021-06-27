using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.CategoryService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param></param>
        /// <returns>All category</returns>
        /// <response code="200">Returns all item</response>
        // GET: api/Category
        [HttpGet]
        public Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return _service.GetAllCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id" hidden="true"></param>
        /// <returns>Returns a single color</returns>
        /// <response code="200">Returns a single category</response>
        /// <response code="404">If id category is not found</response>
        // GET: api/Category/5
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public Task<ActionResult<Category>> GetCategory(int id)
        {
            return _service.GetCategoryById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/Category
        ///     {
        ///         "id": 0,
        ///         "name": "Red"
        ///     }
        /// </remarks>
        /// <param name="id" hide="true"></param>
        /// <param name="category"></param>
        /// <body examples="{'application/json' : {'id' : 0,'name' : 'string'}}"></body>
        /// <returns>A updated color</returns>
        /// <response code="204">if the category has updated</response>
        /// <response code="404" examples="hide">If id category is not found</response>
        /// <response code="400">If the id param is does not match id category</response>
        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public Task<IActionResult> PutCategory(int id, Category category)
        {
            return _service.EditCategoryById(id, category);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Color
        ///     {
        ///         "id" : 0,
        ///         "name": "Shirt"
        ///     }
        /// </remarks>
        /// <param name="category"></param>
        /// <returns>A newly created category</returns>
        /// <response code="201" examples="{'application/json' : {'id' : 0, 'name' : 'string'}}">Returns the newly created item</response>
        /// <response code="204">If name item is exists</response>
        /// <response code="400">If the name field is null or not string</response>
        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public Task<ActionResult<Category>> PostCategory(Category category)
        {
            return _service.AddCategory(category);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">if the category has deleted</response>
        /// <response code="404">If id category is not found</response>
        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public Task<IActionResult> DeleteCategory(int id)
        {
            return _service.DeleteCategoryById(id);
        }
    }
}
