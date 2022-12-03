using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.Cart;
using Projet_2022.Data.IServices;
using Projet_2022.Data.Services;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace Projet_2022.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly Cart _cart;
        private readonly IOrderService _orderService;

        public OrderController(IProductService moviesService, Cart cart, IOrderService ordersService)
        {
            _productService = moviesService;
            _cart = cart;
            _orderService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult Cart()
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

        public async Task<IActionResult> AddToCart(string id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _cart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(Cart));
        }


        public async Task<IActionResult> RemoveItemFromCart(string id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _cart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _cart.GetCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _cart.ClearCartAsync();

            return View("OrderCompleted");
        }
    }
}
