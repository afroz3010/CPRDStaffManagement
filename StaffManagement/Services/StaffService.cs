using Microsoft.AspNetCore.Mvc.Rendering;
using StaffManagement.Models;
using StaffManagement.Models.ViewModels;
using StaffManagement.Repositories;

namespace StaffManagement.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<StaffFilterViewModel> GetStaffFilterDataAsync()
        {
            var grants = await _staffRepository.GetActiveGrantsAsync();

            return new StaffFilterViewModel
            {
                Grants = grants.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                }).ToList()
            };
        }

        public async Task<IEnumerable<StaffDetailsViewModel>> GetFilteredStaffListAsync(string selectedGrant, bool? isStaffActive)
        {
            if (!int.TryParse(selectedGrant, out int grantId) || !isStaffActive.HasValue)
                return Enumerable.Empty<StaffDetailsViewModel>();
            Console.WriteLine(grantId);
            var staffList = await _staffRepository.GetFilteredStaffAsync(grantId, isStaffActive.Value);

            return staffList.Select(s => new StaffDetailsViewModel
            {
                StaffId = s.Id,
                Name = s.Name,
                Email = s.Email,
                CertificationDate = s.CertificationDate,
                Grant = s.StaffGrants.Where(sg => sg.GrantId == grantId).Select(sg => new GrantViewModel
                {
                    GrantId = sg.GrantId,
                    GrantName = sg.Grant.Name,
                    StartDate = sg.StartDate,
                    EndDate = sg.EndDate,
                    IsActive = sg.IsActive
                }).FirstOrDefault()
            });
        }

        public async Task<StaffDetailsViewModel> GetStaffDetailsAsync(int staffId, string selectedGrant)
        {
            var staff = await _staffRepository.GetStaffByIdAsync(staffId);
            if (staff == null) return null;
            if (!int.TryParse(selectedGrant, out int grantId)) return null;

                return new StaffDetailsViewModel
            {
                StaffId = staff.Id,
                Name = staff.Name,
                Email = staff.Email,
                CertificationDate = staff.CertificationDate,
                Grant = staff.StaffGrants.Where(sg => sg.GrantId == grantId).Select(sg => new GrantViewModel
                {
                    GrantId = sg.GrantId,
                    GrantName = sg.Grant.Name,
                    StartDate = sg.StartDate,
                    EndDate = sg.EndDate,
                    IsActive = sg.IsActive
                }).FirstOrDefault()
            };
        }

    }
}