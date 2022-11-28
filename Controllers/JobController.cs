using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _service;

        public JobController(IJobService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
