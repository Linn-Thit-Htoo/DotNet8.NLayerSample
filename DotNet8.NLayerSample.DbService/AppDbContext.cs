using DotNet8.NLayerSample.DbService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.NLayerSample.DbService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Tbl_Blog> Blogs { get; set; }
}