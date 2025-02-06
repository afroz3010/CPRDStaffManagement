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

        public async Task<IEnumerable<Grant>> GetActiveGrantsAsync()
        {
            return await _context.Grants
                .Where(g => g.IsActive)
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

        public async Task<bool> UpdateStaffAsync(Staff staff)
        {
            try
            {
                _context.Entry(staff).State = EntityState.Modified;
                foreach (var staffGrant in staff.StaffGrants)
                {
                    _context.Entry(staffGrant).State = staffGrant.StaffId == 0 && staffGrant.GrantId == 0 ? EntityState.Added : EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddStaffAsync(Staff staff)
        {
            try
            {
                await _context.Staff.AddAsync(staff);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteStaffAsync(int staffId)
        {
            try
            {
                var staff = await _context.Staff.Include(s => s.StaffGrants).FirstOrDefaultAsync(s => s.Id == staffId);
                if (staff == null) return false;

                _context.StaffGrants.RemoveRange(staff.StaffGrants);
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}