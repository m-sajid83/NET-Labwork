using Microsoft.AspNetCore.Mvc;
using DOT_NET_lab_9.Data;
using DOT_NET_lab_9.Models;
namespace DOT_NET_lab_9.Controllers;
public class DashboardController : Controller
{
    public IActionResult Index(int page=1)
    {
        const int size=5;
        var stats=PlacementDb.Overview();
        int pages=Math.Max(1,(int)Math.Ceiling(PlacementDb.StudentCount()/(double)size));
        page=Math.Clamp(page,1,pages);
        return View(new DashboardViewModel { TotalPlaced=stats.total,HighestPackage=stats.high,AveragePackage=stats.avg,Students=PlacementDb.Students(page,size),PageNumber=page,TotalPages=pages });
    }
    public IActionResult CompanyDetails()
    {
        ViewBag.CompanySummary=PlacementDb.Companies();
        ViewBag.PlacedStudents=PlacementDb.PlacedStudents();
        return View();
    }
}
