﻿using System;

namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? CertificationDate { get; set; }

        // Navigation property for many-to-many
        public virtual ICollection<StaffGrant> StaffGrants { get; set; }
    }
}