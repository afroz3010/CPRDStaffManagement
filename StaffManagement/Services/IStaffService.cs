using StaffManagement.Models.ViewModels;

namespace StaffManagement.Services
{
    public interface IStaffService
    {
        Task<StaffFilterViewModel> GetStaffFilterDataAsync(string selectedGrant = null, bool? isActive = null);
        
    }
}
