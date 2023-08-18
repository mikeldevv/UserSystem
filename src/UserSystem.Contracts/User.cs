namespace UserSystem.Contracts;

public class User
{
    public long UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}