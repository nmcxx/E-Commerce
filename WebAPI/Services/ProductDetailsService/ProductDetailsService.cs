using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ProductDetailsService
{
    public class ProductDetailsService : ControllerBase, IProductDetailsService
    {
        public Task<ActionResult<ProductDetails>> AddProductDetails(ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProductDetails(ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProductDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProductDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditProductDetailsById(int id, ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> EditProductDetailsByName(string name, ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<ProductDetails>>> GetAllProductDetails()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ProductDetails>> GetProductDetails(ProductDetails productDetails)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ProductDetails>> GetProductDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ProductDetails>> GetProductDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool ProductDetailsExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ProductDetailsExistsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
