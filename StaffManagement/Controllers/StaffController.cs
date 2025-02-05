using Microsoft.AspNetCore.Mvc;
using StaffManagement.Services;

namespace StaffManagement.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _staffService.GetStaffFilterDataAsync();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FilterStaff(string selectedGrant, bool? isStaffActive)
        {
            var viewModel = await _staffService.GetStaffFilterDataAsync(selectedGrant, isStaffActive);
            return PartialView("_FilterStaff",viewModel);
        }
    }
}
