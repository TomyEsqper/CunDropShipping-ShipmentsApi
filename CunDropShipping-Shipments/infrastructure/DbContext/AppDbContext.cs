using CunDropShipping_Shipments.infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CunDropShipping_Shipments.infrastructure.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<ShipmentsEntity> Shipments { get; set; }
}
    
