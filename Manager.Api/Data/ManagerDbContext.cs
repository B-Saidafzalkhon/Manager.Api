using Manager.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manager.Api.Data;

public class ManagerDbContext : DbContext
{
    public ManagerDbContext(DbContextOptions<ManagerDbContext> options) :  base(options) {}
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ManagerDbContext).Assembly);
    }
}