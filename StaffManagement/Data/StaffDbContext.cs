using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.Data
{
    // Data/StaffDBContext.cs
    public class StaffDbContext : DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options)
            : base(options) { }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffGrant> StaffGrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasMany(s => s.StaffGrants)
                .WithOne(sg => sg.Staff)
                .HasForeignKey(sg => sg.StaffId);
        }
    }

}