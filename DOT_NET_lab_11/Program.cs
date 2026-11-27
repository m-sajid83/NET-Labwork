using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CampusDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CampusDatabase")));

var app = builder.Build();
if (!app.Environment.IsDevelopment()) app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=ServiceRequests}/{action=Index}/{id?}");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusDbContext>();
    db.Database.EnsureCreated();
    if (!db.ServiceRequests.Any())
    {
        db.ServiceRequests.AddRange(
        new ServiceRequest
        {
            StudentName = "Harshil Trivedi",
            EnrollmentNo = "CE24018",
            Category = "Transport",
            Description = "College bus did not arrive at the scheduled stop.",
            Status = "Pending",
            CreatedAt = DateTime.Now.AddHours(-3)
        },
        new ServiceRequest
        {
            StudentName = "Mahi Desai",
            EnrollmentNo = "CE24026",
            Category = "Facilities",
            Description = "Water cooler near the ground floor is not working.",
            Status = "In Progress",
            CreatedAt = DateTime.Now.AddDays(-1)
        },
        new ServiceRequest
        {
            StudentName = "Yash Parmar",
            EnrollmentNo = "IT24031",
            Category = "IT Support",
            Description = "Unable to log in to the college computer system.",
            Status = "Resolved",
            CreatedAt = DateTime.Now.AddDays(-2)
        },
        new ServiceRequest
        {
            StudentName = "Krupa Vyas",
            EnrollmentNo = "CE24044",
            Category = "Library",
            Description = "Request for replacement of a damaged library book.",
            Status = "Pending",
            CreatedAt = DateTime.Now.AddHours(-5)
        },
        new ServiceRequest
        {
            StudentName = "Meet Solanki",
            EnrollmentNo = "CE24052",
            Category = "Other",
            Description = "Need assistance with college ID card replacement.",
            Status = "In Progress",
            CreatedAt = DateTime.Now.AddDays(-4)
        }
    );
    db.SaveChanges();
    }
}
app.Run();
