namespace StaffManagement.Models.ViewModels;
public class StaffDetailsViewModel
{
    public int StaffId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? CertificationDate { get; set; }
    public GrantViewModel Grant { get; set; }
}
public class GrantViewModel
{
    public int GrantId { get; set; }
    public string GrantName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}