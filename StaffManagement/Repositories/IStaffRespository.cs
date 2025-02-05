using StaffManagement.Models;

namespace StaffManagement.Repositories
{
    public interface IStaffRepository
    {
        Task<List<string>> GetAllGrantsAsync();
        Task<List<Staff>> GetStaffByGrantAndStatusAsync(string grantName, bool? isActive);
    }
}
