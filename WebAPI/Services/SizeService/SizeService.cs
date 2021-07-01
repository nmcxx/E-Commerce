using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.SizeService
{
    public class SizeService : ISizeService
    {
        public Task<ActionResult<Size>> AddSize(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteSize(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteSizeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteSizeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditSizeById(int id, Size size)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditSizeByName(string name, Size size)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Size>>> GetAllSize()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Size>> GetSize(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Size>> GetSizeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Size>> GetSizeByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool SizeExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SizeExistsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
