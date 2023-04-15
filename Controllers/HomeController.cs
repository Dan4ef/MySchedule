using Microsoft.AspNetCore.Mvc;
using MyScheduler.Models;
using System.Diagnostics;

namespace MyScheduler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("http://localhost:3000");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}