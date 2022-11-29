using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductDetail(string id)
        {
            var product=await _service.GetByIdAsync(id);
            return View(product);
        }
        public async Task<IActionResult> AllProducts()
        {
            var products = await _service.GetAllAsync();
            return View(products);
        }
    }
}
