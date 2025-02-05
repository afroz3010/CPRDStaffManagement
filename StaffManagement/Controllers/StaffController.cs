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
            var staffList = await _staffService.GetFilteredStaffListAsync(selectedGrant, isStaffActive);
            return PartialView("_StaffListItem", staffList);
        }

        [HttpGet]
        public async Task<IActionResult> GetStaffDetails(int staffId, string selectedGrant)
        {
            var staffDetails = await _staffService.GetStaffDetailsAsync(staffId, selectedGrant);
            return Json(staffDetails);
        }
    }
}