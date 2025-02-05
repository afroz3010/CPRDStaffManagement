using Microsoft.AspNetCore.Mvc;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
    }
}
