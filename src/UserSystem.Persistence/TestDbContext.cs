using Microsoft.EntityFrameworkCore;
using UserSystem.Contracts;

namespace UserSystem.Persistence;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}