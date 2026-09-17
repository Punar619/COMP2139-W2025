using System.ComponentModel.DataAnnotations;

namespace COMP2139_ICE.Models;

public class Project
{
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Project Name is required.")]
    [Display(Name = "Project Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Status")]
    public string Status { get; set; } = "Pending";
}