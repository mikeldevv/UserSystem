namespace UserSystem.Api.Dtos;

public class RegisterUserRequestDto
{
    public string FirstName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}