using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManagement.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            if (await context.Grants.AnyAsync() || await context.Staff.AnyAsync())
                return;

            // Add Grants
            var grants = new List<Grant>
            {
                new Grant { Name = "ABC" },
                new Grant { Name = "FFM" },
                new Grant { Name = "MZMSH" }
            };

            await context.Grants.AddRangeAsync(grants);
            await context.SaveChangesAsync();

            // Add Staff
            var staffList = new List<Staff>
            {
                new Staff
                {
                    Name = "David Baluga",
                    Email = "DavB@CPRD.EDU",
                    CertificationDate = new DateTime(2024, 4, 5)
                },
                new Staff
                {
                    Name = "Mishe Smith",
                    Email = "Mish1980@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 7, 8)
                },
                new Staff
                {
                    Name = "Bradely Smith",
                    Email = "BSmith55@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 5, 24)
                },
                new Staff
                {
                    Name = "Gloria Marshel",
                    Email = "GLSmith356@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 8, 2)
                }
            };

            await context.Staff.AddRangeAsync(staffList);
            await context.SaveChangesAsync();

            // Get references for relationships
            var abcGrant = await context.Grants.FirstAsync(g => g.Name == "ABC");
            var ffmGrant = await context.Grants.FirstAsync(g => g.Name == "FFM");
            var mzmshGrant = await context.Grants.FirstAsync(g => g.Name == "MZMSH");

            var davidBaluga = await context.Staff.FirstAsync(s => s.Email == "DavB@CPRD.EDU");
            var misheSmith = await context.Staff.FirstAsync(s => s.Email == "Mish1980@CPRD.EDU");
            var bradelySmith = await context.Staff.FirstAsync(s => s.Email == "BSmith55@CPRD.EDU");
            var gloriaMarshel = await context.Staff.FirstAsync(s => s.Email == "GLSmith356@CPRD.EDU");

            // Add StaffGrants relationships
            var staffGrants = new List<StaffGrant>
            {
                // David Baluga
                new StaffGrant
                {
                    StaffId = davidBaluga.Id,
                    GrantId = abcGrant.Id,
                    StartDate = new DateTime(2024, 2, 7),
                    EndDate = null
                },
                new StaffGrant
                {
                    StaffId = davidBaluga.Id,
                    GrantId = ffmGrant.Id,
                    StartDate = new DateTime(2024, 5, 5),
                    EndDate = null
                },
                new StaffGrant
                {
                    StaffId = davidBaluga.Id,
                    GrantId = mzmshGrant.Id,
                    StartDate = new DateTime(2024, 5, 5),
                    EndDate = null
                },

                // Mishe Smith
                new StaffGrant
                {
                    StaffId = misheSmith.Id,
                    GrantId = abcGrant.Id,
                    StartDate = new DateTime(2024, 2, 7),
                    EndDate = null
                },
                new StaffGrant
                {
                    StaffId = misheSmith.Id,
                    GrantId = ffmGrant.Id,
                    StartDate = new DateTime(2023, 8, 8),
                    EndDate = new DateTime(2024, 1, 7)
                },

                // Bradely Smith
                new StaffGrant
                {
                    StaffId = bradelySmith.Id,
                    GrantId = abcGrant.Id,
                    StartDate = new DateTime(2023, 5, 25),
                    EndDate = null
                },
                new StaffGrant
                {
                    StaffId = bradelySmith.Id,
                    GrantId = ffmGrant.Id,
                    StartDate = new DateTime(2023, 5, 25),
                    EndDate = null
                },
                new StaffGrant
                {
                    StaffId = bradelySmith.Id,
                    GrantId = mzmshGrant.Id,
                    StartDate = new DateTime(2023, 5, 25),
                    EndDate = null
                },

                // Gloria Marshel
                new StaffGrant
                {
                    StaffId = gloriaMarshel.Id,
                    GrantId = abcGrant.Id,
                    StartDate = new DateTime(2023, 8, 8),
                    EndDate = new DateTime(2024, 2, 7)
                },
                new StaffGrant
                {
                    StaffId = gloriaMarshel.Id,
                    GrantId = ffmGrant.Id,
                    StartDate = new DateTime(2024, 8, 8),
                    EndDate = null
                }
            };

            await context.StaffGrants.AddRangeAsync(staffGrants);
            await context.SaveChangesAsync();
        }
    }
}