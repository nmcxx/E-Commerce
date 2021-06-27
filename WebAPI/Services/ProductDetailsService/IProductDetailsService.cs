using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ProductDetailsService
{
    public interface IProductDetailsService
    {
        Task<ActionResult<IEnumerable<ProductDetails>>> GetAllProductDetails();
        Task<ActionResult<ProductDetails>> GetProductDetailsByName(string name);
        Task<ActionResult<ProductDetails>> GetProductDetailsById(int id);
        Task<ActionResult<ProductDetails>> GetProductDetails(ProductDetails productDetails);
        Task<IActionResult> DeleteProductDetailsById(int id);
        Task<IActionResult> DeleteProductDetailsByName(string name);
        Task<IActionResult> DeleteProductDetails(ProductDetails productDetails);
        Task<ActionResult<ProductDetails>> AddProductDetails(ProductDetails productDetails);
        Task<IActionResult> EditProductDetailsById(int id, ProductDetails productDetails);
        Task<IActionResult> EditProductDetailsByName(string name, ProductDetails productDetails);
        bool ProductDetailsExistsById(int id);
        bool ProductDetailsExistsByName(string name);
    }
}
