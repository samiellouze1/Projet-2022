using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;
using Projet_2022.Models.ViewModels;

namespace Projet_2022.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, IBrandService brandService, ICategoryService categoryService)
        {
            _service = service;
            _brandService = brandService;
            _categoryService = categoryService;
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
            var categories =await _categoryService.GetAllAsync();
            var brands = await _brandService.GetAllAsync();
            var productscategoriesbrands = new ProductBrandCategoryVM() { Brands = brands, Products = products, Categories = categories };
            return View(productscategoriesbrands);
        }
    }
}
