using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using System.Linq;

namespace Projet_2022.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyOrder()
        {
            return View();
        }
    }
}
