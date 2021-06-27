using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<ActionResult<IEnumerable<Product>>> GetAllProduct();
        Task<ActionResult<Product>> GetProductByName(string name);
        Task<ActionResult<Product>> GetProductById(int id);
        Task<ActionResult<Product>> GetProduct(Product product);
        Task<IActionResult> DeleteProductById(int id);
        Task<IActionResult> DeleteProductByName(string name);
        Task<IActionResult> DeleteProduct(Product product);
        Task<ActionResult<Product>> AddProduct(Product product);
        Task<IActionResult> EditProductById(int id, Product product);
        Task<IActionResult> EditProductByName(string name, Product product);
        bool ProductExistsById(int id);
        bool ProductExistsByName(string name);
    }
}
