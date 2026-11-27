using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers;

public class ServiceRequestsController : Controller
{
    private readonly CampusDbContext db;
    private static readonly string[] AllowedStatuses = { "Pending", "In Progress", "Resolved" };
    public ServiceRequestsController(CampusDbContext context) { db = context; }

    public async Task<IActionResult> Index(string? searchTerm)
    {
        var query = db.ServiceRequests.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = $"%{searchTerm.Trim()}%";
            query = query.Where(request => EF.Functions.Like(request.StudentName, term) ||
                EF.Functions.Like(request.EnrollmentNo, term) || EF.Functions.Like(request.Category, term));
        }
        ViewData["SearchTerm"] = searchTerm;
        var requests = await query.OrderByDescending(request => request.CreatedAt).ToListAsync();
        return View(requests);
    }

    [HttpGet]
    public IActionResult Create() => View(new ServiceRequestInput());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceRequestInput input)
    {
        if (!ModelState.IsValid) return View(input);
        var request = new ServiceRequest
        {
            StudentName = input.StudentName.Trim(), EnrollmentNo = input.EnrollmentNo.Trim().ToUpperInvariant(),
            Category = input.Category, Description = input.Description.Trim(), Status = "Pending", CreatedAt = DateTime.Now
        };
        db.ServiceRequests.Add(request);
        await db.SaveChangesAsync();
        TempData["Message"] = "Service request submitted successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeStatus(int id, string status)
    {
        if (!AllowedStatuses.Contains(status))
        {
            TempData["Message"] = "Please select a valid status.";
            return RedirectToAction(nameof(Index));
        }
        var request = await db.ServiceRequests.FindAsync(id);
        if (request == null) return NotFound();
        request.Status = status;
        await db.SaveChangesAsync();
        TempData["Message"] = $"Request #{id} status updated.";
        return RedirectToAction(nameof(Index));
    }
}
