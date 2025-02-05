namespace StaffManagement.Models;
public class Staff
{
    public int Id { get; set; }
    public string StaffName { get; set; }
    public string Email { get; set; }
    public DateTime? CertificationDate { get; set; }
    public ICollection<StaffGrant> StaffGrants { get; set; }
}
