using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Models;
namespace SmartCampusPortal.Data;

public class CampusDbContext : DbContext
{
    public CampusDbContext(DbContextOptions<CampusDbContext> options) : base(options) { }
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(request => request.Id);
            entity.HasIndex(request => request.EnrollmentNo);
            entity.Property(request => request.StudentName).HasMaxLength(80).IsRequired();
            entity.Property(request => request.EnrollmentNo).HasMaxLength(20).IsRequired();
            entity.Property(request => request.Category).HasMaxLength(40).IsRequired();
            entity.Property(request => request.Description).HasMaxLength(500).IsRequired();
            entity.Property(request => request.Status).HasMaxLength(20).IsRequired();
        });
    }
}
