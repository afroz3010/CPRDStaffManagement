using StaffManagement.Models.ViewModels;
using StaffManagement.Models;
using StaffManagement.Repositories;

namespace StaffManagement.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;

        public StaffService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<StaffFilterViewModel> GetStaffFilterDataAsync(string selectedGrant = null, bool? isActive = null)
        {
            var grants = await _repository.GetAllGrantsAsync();
            var filteredStaff = selectedGrant != null
                ? await _repository.GetStaffByGrantAndStatusAsync(selectedGrant, isActive)
                : new List<Staff>();
            Console.WriteLine($"filterd staff {filteredStaff}");
            return new StaffFilterViewModel
            {
                Grants = grants,
                SelectedGrant = selectedGrant,
                IsStaffActive = isActive,
                FilteredStaff = filteredStaff
            };
        }
    }
}
