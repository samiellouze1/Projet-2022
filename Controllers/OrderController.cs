using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.Cart;
using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using System.Linq;

namespace Projet_2022.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly Cart _cart;

        public OrderController(IProductService productService,Cart cart )
        {
            _productService = productService;
            _cart= cart;    

        }
        public IActionResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;
            var response = new CartVM()
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(response);
        }
        
    }
}
