using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;
using Projet_2022.Models.ViewModels;

namespace Projet_2022.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandservice;
        private readonly ICategoryService _categoryservice;

        public BrandController(IBrandService brandservice,ICategoryService categoryservice)
        {
            _brandservice = brandservice;
            _categoryservice = categoryservice;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await _brandservice.GetAllAsync();
            var categories = await _categoryservice.GetAllAsync();
            var brandscategories = new BrandsCategoriesVM() { Brands=brands,Categories=categories};
            return View(brandscategories);
        }
        public async Task<IActionResult> Category(string id)
        {
            var brand = await _brandservice.GetByIdAsync(id);
            var categories = await _categoryservice.GetAllAsync();
            var brandcategories = new BrandCategoriesVM() { Brand = brand, Categories = categories };
            return View(brand);
        }
    }
}
