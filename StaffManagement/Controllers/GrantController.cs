using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    public class GrantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
