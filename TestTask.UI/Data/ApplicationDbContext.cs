using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestTask.UI.Models;

namespace TestTask.UI.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Configuration> Configurations { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}