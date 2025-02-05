using StaffManagement.Models;

namespace StaffManagement.Data
{
    // Data/DataSeeder.cs
    public static class DataSeeder
    {
        public static void SeedStaffData(StaffDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if data already exists to prevent duplicate seeding
            if (!context.Staffs.Any())
            {
                // Create staff members with their associated grants
                var staffMembers = new List<Staff>
            {
                new Staff
                {
                    StaffName = "David Baluga",
                    Email = "DavB@CPRD.EDU",
                    CertificationDate = new DateTime(2024, 4, 5),
                    StaffGrants = new List<StaffGrant>
                    {
                        new StaffGrant
                        {
                            GrantName = "ABC",
                            StartDate = new DateTime(2024, 2, 7),
                            EndDate = null
                        },
                        new StaffGrant
                        {
                            GrantName = "FFM",
                            StartDate = new DateTime(2024, 5, 5),
                            EndDate = null
                        },
                        new StaffGrant
                        {
                            GrantName = "MZMSH",
                            StartDate = new DateTime(2024, 5, 5),
                            EndDate = null
                        }
                    }
                },
                new Staff
                {
                    StaffName = "Mishe Smith",
                    Email = "Mish1980@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 7, 8),
                    StaffGrants = new List<StaffGrant>
                    {
                        new StaffGrant
                        {
                            GrantName = "ABC",
                            StartDate = new DateTime(2024, 2, 7),
                            EndDate = null
                        },
                        new StaffGrant
                        {
                            GrantName = "FFM",
                            StartDate = new DateTime(2023, 8, 8),
                            EndDate = new DateTime(2024, 1, 7)
                        }
                    }
                },
                new Staff
                {
                    StaffName = "Bradely Smith",
                    Email = "BSmith55@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 5, 24),
                    StaffGrants = new List<StaffGrant>
                    {
                        new StaffGrant
                        {
                            GrantName = "ABC",
                            StartDate = new DateTime(2023, 5, 25),
                            EndDate = null
                        },
                        new StaffGrant
                        {
                            GrantName = "FFM",
                            StartDate = new DateTime(2023, 5, 25),
                            EndDate = null
                        },
                        new StaffGrant
                        {
                            GrantName = "MZMSH",
                            StartDate = new DateTime(2023, 5, 25),
                            EndDate = null
                        }
                    }
                },
                new Staff
                {
                    StaffName = "Gloria Marshel",
                    Email = "GLSmith356@CPRD.EDU",
                    CertificationDate = new DateTime(2023, 8, 2),
                    StaffGrants = new List<StaffGrant>
                    {
                        new StaffGrant
                        {
                            GrantName = "ABC",
                            StartDate = new DateTime(2023, 8, 8),
                            EndDate = new DateTime(2024, 2, 7)
                        },
                        new StaffGrant
                        {
                            GrantName = "FFM",
                            StartDate = new DateTime(2024, 8, 8),
                            EndDate = null
                        }
                    }
                }
            };

                // Add the staff members to the context
                context.Staffs.AddRange(staffMembers);

                // Save changes to the database
                context.SaveChanges();
            }
        }
    }
}