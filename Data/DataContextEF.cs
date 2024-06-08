using DotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPI.Data;

public class DataContextEF : DbContext
{
    private readonly IConfiguration _config;

    public DataContextEF(IConfiguration config)
    {
        _config = config;
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserSalary> UserSalaries { get; set; }
    public virtual DbSet<UserJobInfo> UserJobInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                _config.GetConnectionString("DefaultConnection"), 
                optionsBuilderArg => optionsBuilderArg.EnableRetryOnFailure()
                );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TutorialAppSchema");
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("t_user", "TutorialAppSchema");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Active).HasColumnName("active");
        });

        modelBuilder.Entity<UserSalary>(entity =>
        {
            entity.ToTable("t_user_salary", "TutorialAppSchema");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.AvgSalary).HasColumnName("avg_salary");
        });
        
        modelBuilder.Entity<UserJobInfo>(entity =>
        {
            entity.ToTable("t_user_job_info", "TutorialAppSchema");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.JobTitle).HasColumnName("job_title");
            entity.Property(e => e.Department).HasColumnName("department");
        });
    }
}
