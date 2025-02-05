using StaffManagement.Models.ViewModels;

namespace StaffManagement.Services
{
    public interface IStaffService
    {
        Task<StaffFilterViewModel> GetStaffFilterDataAsync();
        Task<IEnumerable<StaffDetailsViewModel>> GetFilteredStaffListAsync(string selectedGrant, bool? isStaffActive);
        Task<StaffDetailsViewModel> GetStaffDetailsAsync(int staffId, string selectedGrant);
    }
}