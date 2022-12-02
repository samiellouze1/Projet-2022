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
        public async Task<IActionResult> ProductDetail(string id)
        {
            var product=await _service.GetByIdAsync(id);
            var categories = await _categoryService.GetAllAsync();
            var brands= await _brandService.GetAllAsync();
            var productcategoriesbrands = new ProductCategoriesBrands()
            {
                Product = product,
                Brands = brands,
                Categories = categories
            };
            return View(productcategoriesbrands);
        }
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            var categories =await _categoryService.GetAllAsync();
            var brands = await _brandService.GetAllAsync();
            var productscategoriesbrands = new ProductsBrandsCategoriesVM() { Brands = brands, Products = products, Categories = categories };
            return View(productscategoriesbrands);
        }
    }
}
