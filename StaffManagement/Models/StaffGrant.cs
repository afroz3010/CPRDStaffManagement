namespace StaffManagement.Models
{
    public class StaffGrant
    {
        public int StaffId { get; set; }
        public int GrantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation properties
        public virtual Staff Staff { get; set; }
        public virtual Grant Grant { get; set; }
    }
}