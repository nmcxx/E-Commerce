using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.SizeService
{
    public interface ISizeService
    {
        Task<ActionResult<IEnumerable<Size>>> GetAllSize();
        Task<ActionResult<Size>> GetSizeByName(string name);
        Task<ActionResult<Size>> GetSizeById(int id);
        Task<ActionResult<Size>> GetSize(Size size);
        Task<IActionResult> DeleteSizeById(int id);
        Task<IActionResult> DeleteSizeByName(string name);
        Task<IActionResult> DeleteSize(Size size);
        Task<ActionResult<Size>> AddSize(Size size);
        Task<IActionResult> EditSizeById(int id, Size size);
        Task<IActionResult> EditSizeByName(string name, Size size);
        bool SizeExistsById(int id);
        bool SizeExistsByName(string name);
    }
}
