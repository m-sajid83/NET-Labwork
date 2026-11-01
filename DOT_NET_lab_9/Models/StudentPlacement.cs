namespace DOT_NET_lab_9.Models;
public class StudentPlacement
{
    public int StudentId { get; set; }
    public string EnrollmentNo { get; set; } = "";
    public string StudentName { get; set; } = "";
    public string Department { get; set; } = "";
    public bool IsPlaced { get; set; }
    public string CompanyName { get; set; } = "-";
    public string JobRole { get; set; } = "-";
    public decimal? PackageLPA { get; set; }
}
