namespace DOT_NET_lab_9.Models;
public class DashboardViewModel
{
    public int TotalPlaced { get; set; }
    public decimal HighestPackage { get; set; }
    public decimal AveragePackage { get; set; }
    public List<StudentPlacement> Students { get; set; } = new();
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
}
