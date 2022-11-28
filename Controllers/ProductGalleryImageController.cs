using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class ProductImageGalleryController : Controller
    {
        private readonly IProductGalleryImageService _service;

        public ProductImageGalleryController(IProductGalleryImageService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
