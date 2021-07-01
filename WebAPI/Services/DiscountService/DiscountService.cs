using Common.Data;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.DiscountService
{
    public class DiscountService : ControllerBase, IDiscountService
    {
        private readonly ApplicationDbContext _context;

        public DiscountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult<Discount>> AddDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteDiscountByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool DiscountExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DiscountExistsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditDiscountById(int id, Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditDiscountByName(string name, Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Discount>>> GetAllDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Discount>> GetDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Discount>> GetDiscountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Discount>> GetDiscountByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
