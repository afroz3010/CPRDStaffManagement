using StaffManagement.Models;

namespace StaffManagement.Repositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Grant>> GetGrantsListAsync();
        Task<IEnumerable<Staff>> GetFilteredStaffAsync(int grantId, bool isActive);
        Task<Staff> GetStaffByIdAsync(int staffId);
    }
}