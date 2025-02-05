using Microsoft.EntityFrameworkCore;
using StaffManagement.Data;
using StaffManagement.Models;

namespace StaffManagement.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffDbContext _context;

        public StaffRepository(StaffDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllGrantsAsync()
        {
            return await _context.StaffGrants
                .Select(g => g.GrantName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Staff>> GetStaffByGrantAndStatusAsync(string grantName, bool? isActive)
        {
            var query = _context.StaffGrants
                .Include(sg => sg.Staff)
                .Where(sg => sg.GrantName == grantName);

            if (isActive.HasValue)
            {
                query = isActive.Value
                    ? query.Where(sg => sg.EndDate == null)
                    : query.Where(sg => sg.EndDate != null);
            }

            return await query
                .Select(sg => sg.Staff)
                .Distinct()
                .ToListAsync();
        }
    }
}
