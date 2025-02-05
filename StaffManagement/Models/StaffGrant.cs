namespace StaffManagement.Models;
public class StaffGrant
{
    public int Id { get; set; }
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
    public string GrantName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}