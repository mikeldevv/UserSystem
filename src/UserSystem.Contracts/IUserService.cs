namespace UserSystem.Contracts;

public interface IUserService
{
    Task CreateUser(string firstName, string emailAddress);
}