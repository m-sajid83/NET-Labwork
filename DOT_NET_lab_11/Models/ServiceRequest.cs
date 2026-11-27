namespace SmartCampusPortal.Models;

public class ServiceRequest
{
    public int Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string EnrollmentNo { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; }
}
