using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ActionResult<IEnumerable<Category>>> GetAllCategory();
        Task<ActionResult<Category>> GetCategoryByName(string name);
        Task<ActionResult<Category>> GetCategoryById(int id);
        Task<ActionResult<Category>> GetCategory(Category category);
        Task<IActionResult> DeleteCategoryById(int id);
        Task<IActionResult> DeleteCategoryByName(string name);
        Task<IActionResult> DeleteCategory(Category category);
        Task<ActionResult<Category>> AddCategory(Category category);
        Task<IActionResult> EditCategoryById(int id, Category category);
        Task<IActionResult> EditCategoryByName(string name, Category category);
        bool CategoryExistsById(int id);
        bool CategoryExistsByName(string name);
    }
}
