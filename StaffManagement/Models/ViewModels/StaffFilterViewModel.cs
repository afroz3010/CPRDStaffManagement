namespace StaffManagement.Models.ViewModels;
public class StaffFilterViewModel
{
    public List<string> Grants { get; set; }
    public string SelectedGrant { get; set; }
    public bool? IsStaffActive { get; set; }
    public List<Staff> FilteredStaff { get; set; }
}
