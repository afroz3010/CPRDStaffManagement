using Microsoft.AspNetCore.Mvc.Rendering;

namespace StaffManagement.Models.ViewModels;
public class StaffFilterViewModel
{
    public string SelectedGrant { get; set; }
    public string IsStaffActive { get; set; }
    public IEnumerable<SelectListItem> Grants { get; set; }
}