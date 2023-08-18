using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UserSystem.Persistence;

public class TestDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
{
    public TestDbContext CreateDbContext(string[] args)
    {
        Env.TraversePath().Load();
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();
        string? connectionString = config.GetConnectionString(nameof(TestDbContext));

        DbContextOptionsBuilder<TestDbContext> builder = new DbContextOptionsBuilder<TestDbContext>();

        builder.UseNpgsql(connectionString);

        return new TestDbContext(builder.Options);
    }
}