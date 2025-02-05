namespace StaffManagement.Models
{
    public class Grant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // Navigation property for many-to-many
        public virtual ICollection<StaffGrant> StaffGrants { get; set; }
    }
}