using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.Controllers;

[ApiController]
[Route("api/service-requests")]
public class ServiceRequestsApiController : ControllerBase
{
    private readonly CampusDbContext db;
    public ServiceRequestsApiController(CampusDbContext context) { db = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetAll()
    {
        var requests = await db.ServiceRequests.AsNoTracking()
            .OrderByDescending(request => request.CreatedAt).ToListAsync();
        return Ok(requests);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceRequest>> GetById(int id)
    {
        var request = await db.ServiceRequests.AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
        return request == null ? NotFound(new { message = "Service request not found." }) : Ok(request);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> Create(ServiceRequestInput input)
    {
        var request = new ServiceRequest
        {
            StudentName = input.StudentName.Trim(),
            EnrollmentNo = input.EnrollmentNo.Trim().ToUpperInvariant(),
            Category = input.Category,
            Description = input.Description.Trim(),
            Status = "Pending",
            CreatedAt = DateTime.Now
        };
        db.ServiceRequests.Add(request);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, StatusUpdateInput input)
    {
        var request = await db.ServiceRequests.FindAsync(id);
        if (request == null) return NotFound(new { message = "Service request not found." });
        request.Status = input.Status;
        await db.SaveChangesAsync();
        return Ok(request);
    }
}
