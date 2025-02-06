using Microsoft.EntityFrameworkCore;
using StaffManagement.Data;
using StaffManagement.Models;

namespace StaffManagement.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grant>> GetGrantsListAsync()
        {
            return await _context.Grants
                .OrderBy(g => g.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Staff>> GetFilteredStaffAsync(int grantId, bool isActive)
        {
            return await _context.Staff
                .Include(s => s.StaffGrants)
                    .ThenInclude(sg => sg.Grant)
                .Where(s => s.StaffGrants.Any(sg =>
                    sg.GrantId == grantId &&
                    (isActive ? sg.EndDate == null : sg.EndDate != null))) 
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int staffId)
        {
            return await _context.Staff
                .Include(s => s.StaffGrants)
                .ThenInclude(sg => sg.Grant)
                .FirstOrDefaultAsync(s => s.Id == staffId);
        }

    }
}