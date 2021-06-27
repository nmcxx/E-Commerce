using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.DiscountService
{
    public interface IDiscountService
    {
        Task<ActionResult<IEnumerable<Discount>>> GetAllDiscount();
        Task<ActionResult<Discount>> GetDiscountByName(string name);
        Task<ActionResult<Discount>> GetDiscountById(int id);
        Task<ActionResult<Discount>> GetDiscount(Discount discount);
        Task<IActionResult> DeleteDiscountById(int id);
        Task<IActionResult> DeleteDiscountByName(string name);
        Task<IActionResult> DeleteDiscount(Discount discount);
        Task<ActionResult<Discount>> AddDiscount(Discount discount);
        Task<IActionResult> EditDiscountById(int id, Discount discount);
        Task<IActionResult> EditDiscountByName(string name, Discount discount);
        bool DiscountExistsById(int id);
        bool DiscountExistsByName(string name);
    }
}
