using System.ComponentModel.DataAnnotations;
namespace SmartCampusPortal.Models;

public class ServiceRequestInput
{
    [Required, StringLength(80, MinimumLength = 2)]
    public string StudentName { get; set; } = string.Empty;

    [Required, StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z0-9/-]+$", ErrorMessage = "Use letters, numbers, / or - only.")]
    public string EnrollmentNo { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(Facilities|IT Support|Library|Transport|Other)$", ErrorMessage = "Select a valid category.")]
    public string Category { get; set; } = string.Empty;

    [Required, StringLength(500, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;
}

public class StatusUpdateInput
{
    [Required]
    [RegularExpression("^(Pending|In Progress|Resolved)$", ErrorMessage = "Status must be Pending, In Progress or Resolved.")]
    public string Status { get; set; } = string.Empty;
}
