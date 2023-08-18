using UserSystem.Contracts;
using UserSystem.Persistence;

namespace UserSystem.Features;

public class UserService : IUserService
{
    private readonly TestDbContext _dbContext;

    public UserService(TestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateUser(string firstName, string emailAddress)
    {
        _dbContext.Users.Add(new User
        {
            FirstName = firstName,
            EmailAddress = emailAddress,
        });
        
        await _dbContext.SaveChangesAsync();
    }
}