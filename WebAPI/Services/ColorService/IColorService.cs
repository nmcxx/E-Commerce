using Common.Models;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ColorService
{
    public interface IColorService
    {
        Task<ActionResult<IEnumerable<ColorViewModel>>> GetAllColor();
        Task<ActionResult<Color>> GetColorByName(string name);
        Task<ActionResult<Color>> GetColorById(int id);
        Task<ActionResult<Color>> GetColor(Color color);
        Task<IActionResult> DeleteColorById(int id);
        Task<IActionResult> DeleteColorByName(string name);
        Task<IActionResult> DeleteColor(Color color);
        Task<ActionResult<ColorViewModel>> AddColor(Color color);
        Task<IActionResult> EditColorById(int id, Color color);
        Task<IActionResult> EditColorByName(string name, Color color);
        bool ColorExistsById(int id);
        bool ColorExistsByName(string name);
    }
}
