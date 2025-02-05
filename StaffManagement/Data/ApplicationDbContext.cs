using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<StaffGrant> StaffGrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<StaffGrant>()
                .HasKey(sg => new { sg.StaffId, sg.GrantId });

            modelBuilder.Entity<StaffGrant>()
                .HasOne(sg => sg.Staff)
                .WithMany(s => s.StaffGrants)
                .HasForeignKey(sg => sg.StaffId);

            modelBuilder.Entity<StaffGrant>()
                .HasOne(sg => sg.Grant)
                .WithMany(g => g.StaffGrants)
                .HasForeignKey(sg => sg.GrantId);
        }
    }
}