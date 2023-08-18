using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using UserSystem.Contracts;
using UserSystem.Features;
using UserSystem.Persistence;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
builder.Services.AddDbContextFactory<TestDbContext>(options =>
{
    options.UseNpgsql(config.GetConnectionString(nameof(TestDbContext)));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();